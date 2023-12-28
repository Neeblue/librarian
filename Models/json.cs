using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Librarian.Models
{
	public class Entry
	{
		public Items[] items { get; set; }
	}
	public class Items
	{
		public Volumeinfo volumeInfo { get; set; }
	}
	public class Volumeinfo
	{
		public string title { get; set; }
		public string subtitle { get; set; }
		public string[] authors { get; set; }
		public string publisher { get; set; }
		public string publishedDate { get; set; }
		public string description { get; set; }
		public int pageCount { get; set; }
		public Imagelinks imageLinks { get; set; }
	}
	public class Imagelinks
	{
		public string smallThumbnail { get; set; }
		public string thumbnail { get; set; }
	}
}
