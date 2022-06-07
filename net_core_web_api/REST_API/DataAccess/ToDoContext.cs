using Microsoft.EntityFrameworkCore;
using REST_API.Models.ToDoList;

namespace REST_API.DataAccess;

public class ToDoContext : DbContext
{
	public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

	public DbSet<ToDoItem> ToDoItems { get; set; } = null!;
}