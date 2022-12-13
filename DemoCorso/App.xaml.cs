using DemoCorso.Customers;
using DemoCorso.Library;
using DemoCorso.StartupHelpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace DemoCorso;

public partial class App : Application
{
    public static IHost? AppHost { get; private set; }

	public App()
	{
		AppHost = Host.CreateDefaultBuilder()
			.ConfigureServices(
			   (context, services) =>
			   {
				   services.AddLogging(configure => configure.AddConsole());
				   services.AddSingleton<MainWindow>();
				   services.AddTransient<IDataAccess, DataAccess>();
				   services.AddWindowFactory<ChildForm>();
				   services.AddSingleton<Customers.ICustomersRepository, MockCustomersRepository>();

               }
			)
			.Build();
	}
    protected override async void OnStartup(StartupEventArgs e)
    {
		await AppHost!.StartAsync();
		var startUpForm = AppHost.Services.GetRequiredService<MainWindow>();
		startUpForm.Show();
        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
		await AppHost!.StopAsync();
        base.OnExit(e);
    }


}
