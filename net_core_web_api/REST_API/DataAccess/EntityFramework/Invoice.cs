using System;
using System.Collections.Generic;

namespace REST_API.DataAccess.EntityFramework
{
	public partial class Invoice
	{
		public string Id { get; set; } = null!;
		public DateTime InvoiceDate { get; set; }
		public decimal Amount { get; set; }
		public string PaymentMethod { get; set; } = null!;
		public string Payee { get; set; } = null!;
		public string Detail { get; set; } = null!;
	}
}