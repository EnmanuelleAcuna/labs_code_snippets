using System;
using System.Collections.Generic;

namespace Invoices.Models.EntityFramework
{
	public partial class Invoice
	{
		public string Id { get; set; } = null!;
		public DateOnly InvoiceDate { get; set; }
		public decimal Amount { get; set; }
		public string Paymentmethod { get; set; } = null!;
		public string Payee { get; set; } = null!;
		public string Detail { get; set; } = null!;
	}
}
