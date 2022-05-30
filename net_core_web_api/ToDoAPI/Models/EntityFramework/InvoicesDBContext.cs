using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Invoices.Models.EntityFramework
{
	public partial class InvoicesDBContext : DbContext
	{
		public InvoicesDBContext()
		{
		}

		public InvoicesDBContext(DbContextOptions<InvoicesDBContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Invoice> Invoices { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
				optionsBuilder.UseNpgsql("Host=217.71.206.171;Database=mydb;Username=postgres;Password=Amelie2406.");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Invoice>(entity =>
			{
				entity.HasNoKey();

				entity.ToTable("invoices");

				entity.Property(e => e.Amount).HasColumnName("amount");

				entity.Property(e => e.Detail)
					.HasMaxLength(4000)
					.HasColumnName("detail");

				entity.Property(e => e.Id)
					.HasMaxLength(100)
					.HasColumnName("id");

				entity.Property(e => e.InvoiceDate).HasColumnName("invoice_date");

				entity.Property(e => e.Payee)
					.HasMaxLength(100)
					.HasColumnName("payee");

				entity.Property(e => e.Paymentmethod)
					.HasMaxLength(100)
					.HasColumnName("paymentmethod");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
