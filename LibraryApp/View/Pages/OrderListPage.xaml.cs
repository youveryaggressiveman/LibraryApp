using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibraryApp.Model;
using LibraryApp.ViewModel;
using ReactiveUI;

namespace LibraryApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderListPage.xaml
    /// </summary>
    public partial class OrderListPage : Page, IViewFor<OrderListViewModel>
    {
        private static readonly DependencyProperty OrderListViewModelProperty =
            DependencyProperty.Register(nameof(ViewModel), typeof(OrderListViewModel), typeof(OrderListPage));

        public OrderListPage(Client selectedClient)
        {
            InitializeComponent();

            ViewModel = new OrderListViewModel(selectedClient);

            this.WhenActivated(disposable =>
            {
                this.Bind(this.ViewModel, orderList => orderList.OrderList,
                        orderList => orderList.orderListView.ItemsSource)
                    .DisposeWith(disposable);
                this.Bind(this.ViewModel, order => order.SelectedOrder, order => order.orderListView.SelectedItem)
                    .DisposeWith(disposable);
                this.BindCommand(this.ViewModel, command => command.CreateNewOrder,
                        command => command.createOrderButton)
                    .DisposeWith(disposable);
            });
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel =(OrderListViewModel)value;
        }

        public OrderListViewModel ViewModel
        {
            get => (OrderListViewModel)GetValue(OrderListViewModelProperty);
            set => SetValue(OrderListViewModelProperty, value);
        }
    }
}
