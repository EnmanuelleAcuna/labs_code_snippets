using REST_API.Extras;
using REST_API.Models.Invoices;

namespace REST_API.Models;

public class InvoiceResponseModel
{
	public InvoiceResponseModel(Invoice invoice)
	{
		Id = invoice.Id.ToString();
		PaymentMethod = invoice.GetPaymentMethod().ToString();
		Date = invoice.Date.ToString("dd/MM/yyyy");
		Amount = invoice.Amount;
		Payee = invoice.Payee;
		Detail = invoice.Detail;
	}

	public string Id { get; }
	public string PaymentMethod { get; }
	public string Date { get; }
	public decimal Amount { get; }
	public string Payee { get; }
	public string Detail { get; }
}