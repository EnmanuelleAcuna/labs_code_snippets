using System.Text.Json;
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
}