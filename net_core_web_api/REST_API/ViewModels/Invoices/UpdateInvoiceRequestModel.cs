using REST_API.Extras;
using REST_API.Models.Invoices;

namespace REST_API.Models;

public class UpdateInvoiceRequestModel
{
	public string Id { get; set; }
	public string PaymentMethod { get; set; }
	public string Date { get; set; }
	public decimal Amount { get; set; }
	public string Payee { get; set; }
	public string Detail { get; set; }
	public string Secret { get; set; }

	public Invoice ToDomainModel()
	{
		Invoice invoice = InvoiceFactory.GetInvoice(PaymentMethod.ToPaymentMethod(), new Guid(Id));
		invoice.FillInvoice(Date.ToDateTime(), Amount, Payee, Detail);
		return invoice;
	}
}