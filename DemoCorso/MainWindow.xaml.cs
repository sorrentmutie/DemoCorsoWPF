using Microsoft.Extensions.Configuration;
using System.Windows;

namespace DemoCorso;

public partial class MainWindow : Window
{
    private readonly IConfiguration configuration;

    public MainWindow(IConfiguration configuration)
	{
		InitializeComponent();
        this.configuration = configuration;
        var x = configuration["Prova"];
    }

    
}
