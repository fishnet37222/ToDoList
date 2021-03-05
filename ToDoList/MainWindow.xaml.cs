using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ToDoList
{
	public partial class MainWindow
	{
		public static readonly DependencyProperty ToDoItemsProperty = DependencyProperty.Register("ToDoItems",
			typeof(ObservableCollection<ToDoItem>), typeof(MainWindow), new FrameworkPropertyMetadata());

		private ObservableCollection<ToDoItem> ToDoItems
		{
			get => (ObservableCollection<ToDoItem>)GetValue(ToDoItemsProperty);

			init => SetValue(ToDoItemsProperty, value);
		}

		public MainWindow()
		{
			InitializeComponent();
			this.ToDoItems = new ObservableCollection<ToDoItem>
			{
				new ToDoItem
				{
					Name = "Test Item",
					DueDate = DateTime.Today.AddDays(10),
					Details = "This is just a test item.",
					IsDone = false
				},
				new ToDoItem
				{
					Name = "Test Item 2",
					DueDate = DateTime.Today.AddDays(5),
					Details = "This is another test item.",
					IsDone = true
				}
			};
			this.lvwToDoItems.ItemsSource = this.ToDoItems;
		}

		private void LvwToDoItems_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
		}

		private void BtnRemoveItem_OnClick(object sender, RoutedEventArgs e)
		{
			this.ToDoItems.RemoveAt(this.lvwToDoItems.SelectedIndex);
		}

		private void BtnNewItem_OnClick(object sender, RoutedEventArgs e)
		{
			var dlg = new NewItemWindow { Owner = this };
			var result = dlg.ShowDialog();
			if (result ?? false)
			{
				this.ToDoItems.Add(dlg.NewItem);
			}
		}
	}
}
