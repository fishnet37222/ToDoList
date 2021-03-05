using System;
using System.Windows;

namespace ToDoList
{
	public partial class NewItemWindow
	{
		public static readonly DependencyProperty NewItemProperty = DependencyProperty.Register("NewItem", typeof(ToDoItem), typeof(NewItemWindow), new FrameworkPropertyMetadata());

		public ToDoItem NewItem
		{
			get => GetValue(NewItemProperty) as ToDoItem;
			set => SetValue(NewItemProperty, value);
		}

		public NewItemWindow()
		{
			InitializeComponent();
			this.NewItem = new ToDoItem { Name = "", DueDate = DateTime.Today, Details = "", IsDone = false };
			this.DataContext = this.NewItem;
		}

		private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
			this.Close();
		}
	}
}
