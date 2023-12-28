using CommunityToolkit.Mvvm.Messaging.Messages;
using Librarian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarian.Messages
{
	internal class AddBookMessage : ValueChangedMessage<Book>
	{
		public AddBookMessage(Book value) : base(value)
		{

		}
	}
}
