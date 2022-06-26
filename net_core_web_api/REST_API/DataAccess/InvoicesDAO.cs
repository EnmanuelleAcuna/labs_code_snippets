using Microsoft.EntityFrameworkCore;
using REST_API.DataAccess.EntityFramework;
using REST_API.Extras;
using DomainModel = REST_API.Models.Invoices;

namespace REST_API.DataAccess;

public class InvoicesDAO : ICRUDBase<DomainModel.Invoice>
{
	private readonly InvoicesDBContext _context;

	public InvoicesDAO(InvoicesDBContext context)
	{
		_context = context;
	}

	public async Task<IList<DomainModel.Invoice>> ReadAll()
	{
		if (_context.Invoices == null) throw new NullReferenceException();

		return await _context.Invoices.Select(i => ToDomainModel(i)).ToListAsync();
	}

	public async Task<DomainModel.Invoice> ReadById(Guid id)
	{
		if (_context.Invoices == null) throw new NullReferenceException();

		Invoice invoiceDB = await _context.Invoices.FindAsync(id.ToString());

		if (invoiceDB == null) throw new NullReferenceException();

		return ToDomainModel(invoiceDB);
	}

	public async Task Create(DomainModel.Invoice invoice)
	{
		if (_context.Invoices == null) throw new NullReferenceException("Entity set 'InvoicesDBContext.Invoices'  is null.");

		_context.Invoices.Add(ToDBModel(invoice));
		await _context.SaveChangesAsync();
	}

	public async Task Update(DomainModel.Invoice invoice)
	{
		try
		{
			Invoice invoiceDB = await _context.Invoices.FindAsync(invoice.Id.ToString());

			if (invoiceDB == null) throw new NullReferenceException();

			invoiceDB.InvoiceDate = invoice.Date;
			invoiceDB.Amount = invoice.Amount;
			invoiceDB.PaymentMethod = invoice.GetPaymentMethod().ToString();
			invoiceDB.Payee = invoice.Payee;
			invoiceDB.Detail = invoice.Detail;

			_context.Entry(invoiceDB).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException) when (!InvoiceExists(invoice.Id.ToString()))
		{
			throw new NullReferenceException();
		}
	}

	public async Task Delete(Guid id)
	{
		if (_context.Invoices == null) throw new NullReferenceException();

		Invoice invoice = await _context.Invoices.FindAsync(id.ToString());

		if (invoice == null) throw new NullReferenceException();

		_context.Invoices.Remove(invoice);
		await _context.SaveChangesAsync();
	}

	private static DomainModel.Invoice ToDomainModel(Invoice invoiceDB)
	{
		PaymentMethods paymentMethod = invoiceDB.PaymentMethod.ToPaymentMethod();
		DomainModel.Invoice invoice = DomainModel.InvoiceFactory.GetInvoice(paymentMethod, new Guid(invoiceDB.Id));
		invoice.FillInvoice(invoiceDB.InvoiceDate, invoiceDB.Amount, invoiceDB.Payee, invoiceDB.Detail);
		return invoice;
	}

	private static Invoice ToDBModel(DomainModel.Invoice invoice)
	{
		Invoice invoiceDB = new Invoice
		{
			Id = invoice.Id.ToString(),
			InvoiceDate = invoice.Date,
			Amount = invoice.Amount,
			PaymentMethod = invoice.GetPaymentMethod().ToString(),
			Payee = invoice.Payee,
			Detail = invoice.Detail
		};

		return invoiceDB;
	}

	private bool InvoiceExists(string id)
	{
		return (_context.Invoices?.Any(e => e.Id == id)).GetValueOrDefault();
	}
}