using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Model;
using ReactiveUI;

namespace LibraryApp.ViewModel
{
    public class CreateNewOrderViewModel :ReactiveObject
    {
        private Client _selectedClient;

        public Client SelectedClient
        {
            get => _selectedClient;
            set => this.RaiseAndSetIfChanged(ref _selectedClient, value, nameof(SelectedClient));
        }

        public CreateNewOrderViewModel(Client selectedClient)
        {
            SelectedClient = selectedClient;
        }
    }
}
