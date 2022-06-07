using REST_API.Extras;

namespace REST_API.Models.Invoices;

public class InvoiceFactory
{
	public static Invoice GetNewInvoice(PaymentMethod paymentMethod)
	{
		switch (paymentMethod)
		{
			case PaymentMethod.Transfer:
				return new TransferPaidInvoice(Guid.NewGuid());
			case PaymentMethod.DebitCard:
				return new DebitCardPaidInvoice(Guid.NewGuid());
			default:
				return new CashPaidInvoice(Guid.NewGuid());
		}
	}

	public static Invoice GetInvoice(PaymentMethod paymentMethod, Guid id)
	{
		switch (paymentMethod)
		{
			case PaymentMethod.Transfer:
				return new TransferPaidInvoice(id);
			case PaymentMethod.DebitCard:
				return new DebitCardPaidInvoice(id);
			default:
				return new CashPaidInvoice(id);
		}
	}
}