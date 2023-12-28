using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Librarian.ViewModels;
using Librarian.Views;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Librarian
{
	public partial class App : Application
	{
		public override void Initialize()
		{
			AvaloniaXamlLoader.Load(this);

			ConfigureServices();

			var mainWindowView = new MainWindow();
			mainWindowView.Show();
		}
		public override void OnFrameworkInitializationCompleted()
		{
			if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
			{
				// Line below is needed to remove Avalonia data validation.
				// Without this line you will get duplicate validations from both Avalonia and CT
				ExpressionObserver.DataValidators.RemoveAll(x => x is DataAnnotationsValidationPlugin);
			}

			base.OnFrameworkInitializationCompleted();
		}

		//Dependency injection using Microsofts DI extension
		public static new App Current => (App)Application.Current;
		public IServiceProvider Services { get; private set; }
		private void ConfigureServices()
		{
			Services = new ServiceCollection()
				.AddSingleton<MainWindowViewModel>()
				.AddSingleton<BooksViewModel>()
				.AddSingleton<RequestViewModel>()
				.AddTransient<ChosenBookViewModel>()
				.BuildServiceProvider();
		}		
	}
}