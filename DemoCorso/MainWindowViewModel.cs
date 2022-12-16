using DemoCorso.Customers;
using DemoCorso.StartupHelpers;
using System.ComponentModel;
using System;
using DemoCorso.Models;

namespace DemoCorso;

public class MainWindowViewModel : MyViewModelBase
{
    private readonly ICustomersRepository _customerRepository;
    private readonly IOrderRepository _orderRepository;
    private MyViewModelBase _currentViewModel;
    private CustomerListViewModel _customerListViewModel;
    private OrderListViewModel _orderListViewModel;



    public MyViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        set { SetProperty(ref _currentViewModel, value); }

    }
    public MainWindowViewModel(ICustomersRepository customerRepository, IOrderRepository orderRepository)
    {
        if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            return;
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _customerListViewModel = new CustomerListViewModel(customerRepository);
        _orderRepository = orderRepository;
        _orderListViewModel = new OrderListViewModel(_orderRepository);
        NavigateTo = new RelayCommand<string>(OnNavigateTo, CanNavigateTo);

        _customerListViewModel.PlaceOrderRequested += PlaceOrder;
        _customerListViewModel.EditCustomerRequested += EditCustomer;


        CurrentViewModel = _customerListViewModel;
    }

    private void EditCustomer(Customer obj)
    {
        throw new NotImplementedException();
    }

    private void PlaceOrder(Guid obj)
    {
        throw new NotImplementedException();
    }



    #region Command
    public RelayCommand<string> NavigateTo { get; set; }



    private bool CanNavigateTo(string arg)
    {
        return true;
    }



    private void OnNavigateTo(string arg)
    {
        if (arg.ToLower() == "customers")
            CurrentViewModel = _customerListViewModel;
        else if (arg.ToLower() == "orders")
            CurrentViewModel = _orderListViewModel;
    }
    #endregion



}