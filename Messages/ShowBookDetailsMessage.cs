using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarian.Messages
{
	public class ShowBookDetailsMessage : ValueChangedMessage<string>
	{
		public ShowBookDetailsMessage(string value) : base(value)
		{

		}
	}
}
