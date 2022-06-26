using REST_API.Extras;

namespace REST_API.Models.Invoices;

public class InvoiceFactory
{
	public static Invoice GetNewInvoice(PaymentMethods paymentMethod)
	{
		switch (paymentMethod)
		{
			case PaymentMethods.Transfer:
				return new TransferPaidInvoice(Guid.NewGuid());
			case PaymentMethods.DebitCard:
				return new DebitCardPaidInvoice(Guid.NewGuid());
			default:
				return new CashPaidInvoice(Guid.NewGuid());
		}
	}

	public static Invoice GetInvoice(PaymentMethods paymentMethod, Guid id)
	{
		switch (paymentMethod)
		{
			case PaymentMethods.Transfer:
				return new TransferPaidInvoice(id);
			case PaymentMethods.DebitCard:
				return new DebitCardPaidInvoice(id);
			default:
				return new CashPaidInvoice(id);
		}
	}
}