using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Librarian.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace Librarian.ViewModels
{
	public partial class RequestViewModel : ViewModelBase
	{
		[ObservableProperty]
		private string bookName;

		[ObservableProperty]
		private string requestResponse;

		[RelayCommand]
		public void RequestButton()
		{
			Book book = GrabBook();
			
			if (book != null) 
			{
				if (AddBookToUI(book) == true)
				{
					Task.Run(() =>
					{
						RequestResponse = "Added!";
						Thread.Sleep(3000);
						RequestResponse = "";

					});
					
				}
				else 
				{
					Task.Run(() =>
					{
						RequestResponse = "Not added!";
						Thread.Sleep(3000);
						RequestResponse = "";

					});
				}
			}

		}
		private Book GrabBook()
		{
			try
			{
				HttpClient httpClient = new HttpClient();
				HttpRequestMessage request = new HttpRequestMessage();
				request.RequestUri = new Uri($"https://www.googleapis.com/books/v1/volumes?langRestrict=en&q={BookName}&printType=books&orderBy=relevance&projection=full&maxResults=1");
				request.Method = HttpMethod.Get;
				request.Headers.Add("api_key", Security.API_Key.Key);

				Task<HttpResponseMessage> responseTask = httpClient.SendAsync(request);
				responseTask.Wait();

				HttpResponseMessage response = responseTask.Result;
				Task<string> responseStringTask = response.Content.ReadAsStringAsync();
				responseStringTask.Wait();

				var responseString = responseStringTask.Result;
				var statusCode = response.StatusCode;

				Entry a = JsonConvert.DeserializeObject<Entry>(responseString);
				BookName = "";
				return new Book(a);
			}
			catch { return null; }
		}
		private bool AddBookToUI(Book book)
		{
			try
			{
				var booksViewModel = App.Current.Services.GetService<BooksViewModel>();
				var viewModel = booksViewModel as BooksViewModel;

				if (!viewModel.Books.ToList().Any(s => s.Title == book.Title))
				{
					//TODO: Change to weakreference message?
					viewModel.Books.Add(book);
					return true;
				}
				else return false;
			}
			catch { return false; }
		}
	}
}
