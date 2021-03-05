using System;

namespace ToDoList
{
	public class ToDoItem
	{
		public DateTime DueDate { get; set; }
		public string Name { get; set; }
		public string Details { get; set; }
		public bool? IsDone { get; set; }
	}
}
