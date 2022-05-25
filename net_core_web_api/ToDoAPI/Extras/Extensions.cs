using System.Text.Json;
using ToDoAPI.Models;

namespace ToDoAPI.Extras
{
	public static class Extensions
	{
		public static string ToMyString(this ToDoItem toDoItem)
		{
			return JsonSerializer.Serialize(toDoItem);
		}
	}
}
