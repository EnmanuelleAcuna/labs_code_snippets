namespace Invoices.Models
{
	public class Invoice
	{
		public Guid Id { get; private set; }
		public DateTime Date { get; private set; }
		public decimal Amount { get; private set; }
		public PaymentMethod PaymentMethod { get; private set; }
		public string Payee { get; private set; }
		public string Detail { get; set; }
	}
}