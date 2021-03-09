using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using ToDoList.Annotations;

namespace ToDoList
{
	public sealed partial class MainWindow : INotifyPropertyChanged
	{
		public static readonly DependencyProperty ToDoItemsProperty = DependencyProperty.Register("ToDoItems",
			typeof(ObservableCollection<ToDoItem>), typeof(MainWindow), new FrameworkPropertyMetadata());

		// ReSharper disable once MemberCanBePrivate.Global
		public ObservableCollection<ToDoItem> ToDoItems
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

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator, UsedImplicitly, System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Pending>")]
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
