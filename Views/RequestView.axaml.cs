using Avalonia.Controls;
using Librarian.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Librarian.Views
{
	public partial class RequestView : UserControl
	{
		public RequestView()
		{
			InitializeComponent();
			DataContext = App.Current.Services.GetService<RequestViewModel>();
		}
	}
}
