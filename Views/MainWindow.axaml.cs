using Avalonia.Controls;
using Librarian.Models;
using Librarian.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Librarian.Views
{
	public partial class MainWindow : Window
	{

		public MainWindow()
		{
			InitializeComponent();
			DataContext = App.Current.Services.GetService<MainWindowViewModel>();

			RestoreBooks();
		}

		public void RestoreBooks()
		{
			var viewModel = App.Current.Services.GetService<BooksViewModel>();

			if (File.Exists("Books.json") && new FileInfo("Books.json").Length > 2)
			{
				JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
				ObservableCollection<Book> books = JsonSerializer.Deserialize<ObservableCollection<Book>>(File.ReadAllText("Books.json"), options);
				foreach (Book book in books)
				{
					if (!viewModel.Books.Any(s => s.Title == book.Title))
					{
						viewModel.Books.Add(book);
					}
				}
			}
		}

		public void Window_Closing(object sender, CancelEventArgs e)
		{
			var viewModel = App.Current.Services.GetService<BooksViewModel>();

			JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
			string json = JsonSerializer.Serialize(viewModel.Books, options);
			File.WriteAllText("Books.json", json);
		}
	}
}
