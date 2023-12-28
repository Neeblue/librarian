using CommunityToolkit.Mvvm.ComponentModel;
using Librarian.Models;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using Avalonia.Media.Imaging;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Diagnostics;
using Avalonia.Controls;

namespace Librarian.ViewModels
{
	public partial class BooksViewModel : ViewModelBase
	{
		[ObservableProperty]
		private ObservableCollection<Book> books = new ObservableCollection<Book>();

		[ObservableProperty] private Book selectedBook;

		[ObservableProperty]
		private int slider = 200;

		[ObservableProperty] private int imageWidth = 200;

		[ObservableProperty] private int imageHeight = 300;

		partial void OnSliderChanged(int value)
		{
			if (value == 0) return;

			ImageWidth = value;

			ImageHeight = (int)(ImageWidth * 1.5);
		}

		[RelayCommand]
		void DeleteBook()
		{
			Books.Remove(SelectedBook);
		}
	}
}
