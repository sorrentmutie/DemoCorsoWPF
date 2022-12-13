using DemoCorso.Models;
using DemoMVVM;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace DemoCorso.Customers;

public class CustomersListViewModel
{
    private  ICustomersRepository repository
        = new MockCustomersRepository();

    public ObservableCollection<DemoCustomer> Customers { get; set; }
        = new ObservableCollection<DemoCustomer>();

    public RelayCommand DeleteCommand { get; private set; }
    private DemoCustomer? selectedCustomer;
    public DemoCustomer? SelectedCustomer { 
        get
        {
            return selectedCustomer;
        }
        set
        {
            selectedCustomer = value;
            DeleteCommand.RaiseCanExecuteChanged();
        }
    }

    public CustomersListViewModel()
	{
        DeleteCommand = new RelayCommand(OnDelete, CanExecuteDelete);
    }

    private bool CanExecuteDelete()
    {
        return SelectedCustomer != null;
    }

    private void OnDelete()
    {
        if(SelectedCustomer != null)
        {
            Customers.Remove(SelectedCustomer);
        }
    }

    public async void LoadCustomers()
    {
        if (DesignerProperties.GetIsInDesignMode(
            new System.Windows.DependencyObject())) return;

        var customers = await (repository.GetCustomers());
        foreach (var customer in customers)
        {
            Customers.Add(customer);
        }
    }

}
