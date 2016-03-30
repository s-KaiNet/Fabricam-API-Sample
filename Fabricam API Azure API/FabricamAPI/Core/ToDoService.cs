using System.Collections.Generic;

namespace FabricamAPI.Core
{
	public static class ToDoService
	{
		private static readonly List<string> _todos = new List<string> { "Do smth useful", "Buy milk" };

		public static List<string> Get()
		{
			return _todos;
		}

		public static string Get(int index)
		{
			return _todos[index];
		}

		public static int Add(string todo)
		{
			_todos.Add(todo);

			return _todos.Count - 1;
		}

		public static void Delete(int id)
		{
			_todos.RemoveAt(id);
		}
	}
}