using CommunityToolkit.Mvvm.Messaging.Messages;
using Librarian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarian.Messages
{
	internal class BookAddedMessage : ValueChangedMessage<string>
	{
		public BookAddedMessage(string value) : base(value)
		{

		}
	}
}
