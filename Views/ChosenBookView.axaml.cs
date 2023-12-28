using Avalonia.Controls;
using Librarian.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Librarian.Views
{
	public partial class ChosenBookView : UserControl
	{
		public ChosenBookView()
		{
			InitializeComponent();
			DataContext = App.Current.Services.GetService<ChosenBookViewModel>();
		}
	}
}
