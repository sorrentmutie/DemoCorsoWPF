using DemoCorso.Library;
using DemoCorso.StartupHelpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Windows;

namespace DemoCorso;

public partial class App : Application
{
    public static IHost? AppHost { get; private set; }
	public IConfiguration Configuration;

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

               }
			)
			.Build();
	}
    protected override async void OnStartup(StartupEventArgs e)
    {
		await AppHost!.StartAsync();

		var builder = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appSettings.json", optional: false, reloadOnChange: true);

		Configuration = builder.Build();

	//	var x = Configuration["Prova"];


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
