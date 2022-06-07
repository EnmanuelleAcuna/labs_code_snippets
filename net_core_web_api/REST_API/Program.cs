using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using REST_API.DataAccess;
using REST_API.DataAccess.EntityFramework;
using DomainModel = REST_API.Models.Invoices;

namespace REST_API;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddControllers();
		builder.Services.AddDbContext<ToDoContext>(options => options.UseInMemoryDatabase("ToDoList"));
		builder.Services.AddDbContext<InvoicesDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		// builder.Services.AddSwaggerGen();

		builder.Services.AddScoped<ICRUDBase<DomainModel.Invoice>, InvoicesDAO>();

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
			// app.UseSwagger();
			// app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}