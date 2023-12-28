using Avalonia.Controls;
using Librarian.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Avalonia.Media;
using System;

namespace Librarian.Views
{
	public partial class BooksView : UserControl
	{
		public BooksView()
		{
			InitializeComponent();
			DataContext = App.Current.Services.GetService<BooksViewModel>();
		}
	}
}
