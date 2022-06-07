using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace REST_API.DataAccess.EntityFramework
{
	public partial class InvoicesDBContext : DbContext
	{
		public InvoicesDBContext() { }

		public InvoicesDBContext(DbContextOptions<InvoicesDBContext> options) : base(options) { }

		public virtual DbSet<Invoice> Invoices { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Invoice>(entity =>
			{
				entity.ToTable("invoices");

				entity.Property(e => e.Id)
					.HasMaxLength(100)
					.HasColumnName("id");

				entity.Property(e => e.Amount).HasColumnName("amount");

				entity.Property(e => e.Detail)
					.HasMaxLength(4000)
					.HasColumnName("detail");

				entity.Property(e => e.InvoiceDate)
					.HasColumnType("timestamp without time zone")
					.HasColumnName("invoice_date");

				entity.Property(e => e.Payee)
					.HasMaxLength(100)
					.HasColumnName("payee");

				entity.Property(e => e.PaymentMethod)
					.HasMaxLength(100)
					.HasColumnName("payment_method");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}