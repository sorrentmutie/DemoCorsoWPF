using DemoCorso.Library;
using DemoCorso.Models;
using DemoCorso.StartupHelpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Documents;

namespace DemoCorso;

public partial class MainWindow : Window  // , INotifyPropertyChanged
{
    private readonly IConfiguration configuration;

    //private readonly ILogger<MainWindow> logger;
    //private readonly IDataAccess dataAccess;
    //private readonly IAbstractFactory<ChildForm> abstractFactory;

    //private Customer? customer;

    //public event PropertyChangedEventHandler? PropertyChanged;

    //public Customer? Customer { 
    //    get { return customer; }
    //    set { if(customer !=value) {
    //            customer = value;
    //            NotifyPropertyChanged();
    //        } 
    //    }
    //}
    //public ObservableCollection<Customer>? Customers { get; set; } 

    public MainWindow(ILogger<MainWindow> logger,  IDataAccess dataAccess, 
        IAbstractFactory<ChildForm> abstractFactory, IConfiguration configuration)
    {
        InitializeComponent();
        this.configuration = configuration;

        var x = configuration["Customer:Name"];

        //Customer = new Customer
        //{
        //    Name = "Mario",
        //    Surname = "Rossi",
        //    PhoneNumber = "1234"
        //};

        //Customers = new ObservableCollection<Customer>(new CustomersData().Customers);
        //Customer = Customers[0];
        //Customer.BeginEdit();
        //this.logger = logger;
        //this.dataAccess = dataAccess;
        //this.abstractFactory = abstractFactory;
        //MyGrid.DataContext = this;
        //MyCombo.SelectedIndex = 0;
    }

    //private void ConfButton_Click(object sender, RoutedEventArgs e)
    //{
    //    ConfButton.Content = $"{configuration["Customer:Name"]} - {configuration["Customer:Surname"]}";
    //}

    //private void ChangeButton_Click(object sender, RoutedEventArgs e)
    //{
    //    Customer!.Name = "xxxxx";
    //    Customers!.Add(new Customer { Name = "Salvatore", Surname = "Sorrentino", PhoneNumber = "yyyy" });
    //}

    //private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    //{
    //    Customer = MyCombo.SelectedItem as Customer;
    //}

    //private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    //{
    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //}

    //private void SaveButton_Click(object sender, RoutedEventArgs e)
    //{
    //    Customer?.EndEdit();
    //}

    //private void CancelButton_Click(object sender, RoutedEventArgs e)
    //{
    //    Customer?.CancelEdit();
    //}
}
