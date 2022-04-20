using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mime;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using DynamicData.Binding;
using LibraryApp.Controllers;
using LibraryApp.Core;
using LibraryApp.Model;
using LibraryApp.View.Pages;
using ReactiveUI;

namespace LibraryApp.ViewModel
{
    public class EmployeeViewModel :ReactiveObject
    {
        private readonly EmployeeViewModelController _controller;

        private Client _selectedClient;
        private ObservableCollection<Client> _clientList;

        public delegate void LoadAll();
        public event LoadAll Load;

        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedClient, value, nameof(SelectedClient));
            }
        }

        public ObservableCollection<Client> ClientList
        {
            get => _clientList;
            set => this.RaiseAndSetIfChanged(ref _clientList, value, nameof(ClientList));
        }

        public ReactiveCommand<Unit,Unit> CheckOrderListCommand { get; }

        public EmployeeViewModel()
        {
            _controller = new EmployeeViewModelController();

            CheckOrderListCommand = ReactiveCommand
                .CreateFromObservable(ExecuteOrderList);

            DispatcherTimer dispatcherTimer = new();
            dispatcherTimer.Interval = TimeSpan.FromMinutes(1);
            dispatcherTimer.Tick += (sender, args) =>
            {
                RouteEvent(new List<LoadAll>() { LoadClientInfo });
            };
            dispatcherTimer.Start();

            RouteEvent(new List<LoadAll>() {LoadClientInfo});
        }

        private IObservable<Unit> ExecuteOrderList()
        {
            RouteEvent(new List<LoadAll>(){OpenSelectedUserOrderPage});

            return Observable.Return(Unit.Default);
        }

        private void RouteEvent(List<LoadAll> action)
        {
            foreach (var item in action)
            {
                Load += item;
                Load.Invoke();
                Load -= item;
            }
        }

        private void OpenSelectedUserOrderPage()
        {
            if (SelectedClient == null)
            {
                MessageBox.Show("Необходимо выбрать клиента, для просмотра его заказов", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                return;
            }

            FrameManager.SetSource(new OrderListPage(SelectedClient));
        }

        private async void LoadClientInfo()
        {
            ClientList = new ObservableCollection<Client>();

            var clientList = await _controller.GetClientList();
            clientList.ToList().ForEach(ClientList.Add);
        }
    }
}
