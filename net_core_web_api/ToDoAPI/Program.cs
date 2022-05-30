using Invoices.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace ToDoAPI
{
	public class programm
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			builder.Services.AddDbContext<ToDoContext>(options => options.UseInMemoryDatabase("ToDoList"));
			builder.Services.AddDbContext<InvoicesDBContext>(options => options.UseNpgsql());
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			// builder.Services.AddSwaggerGen();

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
}
