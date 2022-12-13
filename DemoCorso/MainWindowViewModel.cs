using DemoCorso.Customers;

namespace DemoCorso.ViewModels;

public class MainWindowViewModel
{
	public MainWindowViewModel()
	{
        CurrentViewModel = new CustomersListViewModel();
    }
    public object CurrentViewModel { get; set; }
}
