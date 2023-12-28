// Define a shared service interface
using Librarian.Models;
using System.Collections.Generic;
using System;

public interface IBookService
{
	bool ContainsBook(Book book);
	void AddBook(Book book);
	event EventHandler<Book> BookAdded;
}

// Implement the shared service
public class BookService : IBookService
{
	private readonly List<Book> _books = new List<Book>();
	public bool ContainsBook(Book book) => _books.Contains(book);
	public void AddBook(Book book)
	{
		if (!_books.Contains(book))
		{
			_books.Add(book);
			BookAdded?.Invoke(this, book);
		}
	}
	public event EventHandler<Book> BookAdded;
}

// In the BookViewModel, add a book and call the shared service
//public void AddBook(Book book)
//{
//	_bookService.AddBook(book);
//}

// In the AddBookViewModel, subscribe to the BookAdded event
//_bookService.BookAdded += (sender, book) => {
//	// Handle the book added event
//};