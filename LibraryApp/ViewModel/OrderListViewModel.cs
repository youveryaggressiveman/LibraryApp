using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LibraryApp.Controllers;
using LibraryApp.Model;
using LibraryApp.View.Windows;
using ReactiveUI;

namespace LibraryApp.ViewModel
{
    public class OrderListViewModel : ReactiveObject
    {
        private readonly OrderListViewModelController _controller;
        private readonly Client _selectedClient;

        private Order _selectedOrder;

        private ObservableCollection<OrderStatus> _orderStatusList;
        private ObservableCollection<Order> _orderList;
        private ObservableCollection<Book> _bookList;

        public delegate void LoadAllInfo();
        public event LoadAllInfo Load;

        public ObservableCollection<OrderStatus> OrderStatusList
        {
            get => _orderStatusList;
            set => this.RaiseAndSetIfChanged(ref _orderStatusList, value, nameof(OrderStatusList));
        }

        public ObservableCollection<Book> BookList
        {
            get => _bookList;
            set => this.RaiseAndSetIfChanged(ref _bookList, value, nameof(BookList));
        }

        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedOrder, value, nameof(SelectedOrder));

                LoadBookListBySelectedOrder();
            }
        }

        public ObservableCollection<Order> OrderList
        {
            get => _orderList;
            set => this.RaiseAndSetIfChanged(ref _orderList, value, nameof(OrderList));
        }

        public ReactiveCommand<Unit, Unit> CreateNewOrder { get; }

        public OrderListViewModel(Client selectedClient)
        {
            _selectedClient = selectedClient;

            CreateNewOrder = ReactiveCommand
                .CreateFromObservable(ExecuteNewOrder);

            _controller = new OrderListViewModelController();

            RouteEvent(new List<LoadAllInfo>(){LoadOrderClientID});
        }

        private void RouteEvent(List<LoadAllInfo> action)
        {
            foreach (var item in action)
            {
                Load += item;
                Load.DynamicInvoke();
                Load -= item;
            }
        }

        private IObservable<Unit> ExecuteNewOrder()
        {
            RouteEvent(new List<LoadAllInfo>(){OpenWindowByCreateNewOrder});

            return Observable.Return(Unit.Default);
        }

        private void OpenWindowByCreateNewOrder()
        {
            foreach (var order in OrderList)
            {
                if (order.OrderStatus.Value == "Просрочено" || order.OrderStatus.Value == "В процессе чтения")
                {
                    MessageBox.Show(
                        $"Вы не можете оформить данному клиенту новый заказ, так как его заказ под номером {order.Id} еще не завершен",
                        "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                    return;
                }
            }

            CreateNewOrderWindow createNewOrder = new CreateNewOrderWindow(_selectedClient);
            createNewOrder.ShowDialog();

            RouteEvent(new List<LoadAllInfo>() { LoadOrderClientID });
        }

        private async void LoadOrderClientID()
        {
            OrderList = new ObservableCollection<Order>();

            IEnumerable<Order> orderList;

            try
            {
                orderList = await _controller.GetOrderBySelectedClientID(_selectedClient.Id);

                if (orderList == null)
                {
                    return;
                }

                orderList.ToList().ForEach(OrderList.Add);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private async void LoadBookListBySelectedOrder()
        {
            BookList = new ObservableCollection<Book>();
            OrderStatusList = new ObservableCollection<OrderStatus>();

            foreach (var book in SelectedOrder.OrderOfBooks)
            {
                BookList.Add(book.Book);
            }

            var statusList = await _controller.GetOrderStatusList();
            statusList.ToList().ForEach(OrderStatusList.Add);
        }
    }

}
