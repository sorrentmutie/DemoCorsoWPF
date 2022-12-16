using DemoCorso.StartupHelpers;

namespace DemoCorso
{
    internal class OrderListViewModel: MyViewModelBase
    {
        private IOrderRepository orderRepository;

        public OrderListViewModel(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
    }
}