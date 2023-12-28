using Avalonia.Media.Imaging;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace Librarian.Models
{
	public class Book
	{
		[JsonIgnore] public string Title { get => Entry.items[0].volumeInfo.title; }
		[JsonIgnore] public string Description { get => Entry.items[0].volumeInfo.description; }
		[JsonIgnore] public Bitmap Image { get => GetImage(); }
		[JsonIgnore] public string ImageLink { get => Entry.items[0].volumeInfo.imageLinks.smallThumbnail.Replace("&edge=curl", ""); }
		public Entry Entry { get; private set; }

		[JsonConstructor]
		public Book(Entry entry)
        {
			Entry = entry;
		}

		public Bitmap GetImage()
		{
			//https://books.google.com/books/content?id=EBcqEAAAQBAJ&printsec=frontcover&img=1&zoom=7
			using (var httpClient = new HttpClient())
			{
				var imageBytesTask = httpClient.GetByteArrayAsync(ImageLink);
				imageBytesTask.Wait();
				var imageBytes = imageBytesTask.Result;
				using (var ms = new MemoryStream(imageBytes))
				{
					return new Bitmap(ms);
				}
			}
		}
	}
}
