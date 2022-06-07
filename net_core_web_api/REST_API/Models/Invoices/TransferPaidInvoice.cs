using REST_API.Extras;

namespace REST_API.Models.Invoices;

public class TransferPaidInvoice : Invoice
{
	public TransferPaidInvoice(Guid id) : base(id) { }
}