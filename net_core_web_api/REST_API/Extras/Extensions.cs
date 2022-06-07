using System.Text.Json;
using REST_API.Models.Invoices;
using REST_API.Models.ToDoList;

namespace REST_API.Extras;

public static class Extensions
{
	public static string ToMyString(this ToDoItem toDoItem)
	{
		return JsonSerializer.Serialize(toDoItem);
	}

	public static string ToString(this PaymentMethod paymentMethod)
	{
		switch (paymentMethod)
		{
			case PaymentMethod.Cash:
				return "Cash";
			case PaymentMethod.DebitCard:
				return "DebitCard";
			case PaymentMethod.Transfer:
				return "Transfer";
			default:
				return string.Empty;
		}
	}

	public static PaymentMethod ToPaymentMethod(this string paymentMethod)
	{
		return (PaymentMethod)Enum.Parse(typeof(PaymentMethod), paymentMethod);

		// switch (paymentMethod.ToLower())
		// {
		// 	case "cash":
		// 		return PaymentMethod.Cash;
		// 	case "debitcard":
		// 		return PaymentMethod.DebitCard;
		// 	case "transfer":
		// 		return PaymentMethod.Transfer;
		// 	default:
		// 		return PaymentMethod.Cash;
		// }
	}

	public static PaymentMethod GetPaymentMethod(this Invoice invoice)
	{
		PaymentMethod paymentMethod = PaymentMethod.Cash;

		if (invoice is DebitCardPaidInvoice) paymentMethod = PaymentMethod.DebitCard;
		if (invoice is TransferPaidInvoice) paymentMethod = PaymentMethod.Transfer;

		return paymentMethod;
	}

	public static DateTime ToDateTime(this string dateTime)
	{
		// Expected format: 28/05/2022
		int day = Convert.ToInt16(dateTime.Substring(0, 2));
		int month = Convert.ToInt16(dateTime.Substring(3, 2));
		int year = Convert.ToInt16(dateTime.Substring(6, 4));
		return new DateTime(year, month, day);
	}
}