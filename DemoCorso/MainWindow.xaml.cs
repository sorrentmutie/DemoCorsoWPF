using DemoCorso.Library;
using DemoCorso.StartupHelpers;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace DemoCorso;

public partial class MainWindow : Window
{
    private readonly ILogger<MainWindow> logger;
    private readonly IDataAccess dataAccess;
    private readonly IAbstractFactory<ChildForm> abstractFactory;

    public MainWindow(ILogger<MainWindow> logger,  IDataAccess dataAccess, 
        IAbstractFactory<ChildForm> abstractFactory)
    {
        InitializeComponent();
        this.logger = logger;
        this.dataAccess = dataAccess;
        this.abstractFactory = abstractFactory;
    }

    private void getData_Click(object sender, RoutedEventArgs e)
    {
       logger.LogCritical("Qualcuno ha cliccato");
       data.Text = dataAccess.GetData();
    }

    private void openChildForm_Click(object sender, RoutedEventArgs e)
    {
        abstractFactory.Create().Show();
    }
}
