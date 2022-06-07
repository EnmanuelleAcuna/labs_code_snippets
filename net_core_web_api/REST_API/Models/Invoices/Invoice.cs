namespace REST_API.Models.Invoices;

public class Invoice
{
	protected Invoice(Guid id)
	{
		Id = id;
	}

	public Guid Id { get; protected set; }
	public DateTime Date { get; protected set; }
	public decimal Amount { get; protected set; }
	public string Payee { get; protected set; } = string.Empty;
	public string Detail { get; protected set; } = string.Empty;

	public void FillInvoice(DateTime date, decimal amount, string payee, string detail)
	{
		Date = date;
		Amount = amount;
		Payee = payee;
		Detail = detail;
	}
}