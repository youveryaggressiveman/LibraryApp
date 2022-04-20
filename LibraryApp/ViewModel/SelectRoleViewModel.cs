using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LibraryApp.Core.Singleton;
using LibraryApp.Model;
using LibraryApp.View.Windows;
using ReactiveUI;

namespace LibraryApp.ViewModel
{
    public class SelectRoleViewModel : ReactiveObject
    {
        private Visibility _clientVisibility = Visibility.Collapsed;
        private Visibility _employeeVisibility = Visibility.Collapsed;
        private Visibility _adminVisibility = Visibility.Collapsed;

        public delegate void LoadAll(Role role);

        public event LoadAll Load;
        
        public Visibility ClientVisibility
        {
            get => _clientVisibility;
            set => this.RaiseAndSetIfChanged(ref _clientVisibility, value, nameof(ClientVisibility));
        }

        public Visibility EmployeeVisibility
        {
            get => _employeeVisibility;
            set => this.RaiseAndSetIfChanged(ref _employeeVisibility, value, nameof(EmployeeVisibility));
        }

        public Visibility AdminVisibility
        {
            get => _adminVisibility;
            set => this.RaiseAndSetIfChanged(ref _adminVisibility, value, nameof(AdminVisibility));
        }

        public ReactiveCommand<Unit, Unit> ClientCommand { get; }
        public ReactiveCommand<Unit, Unit> EmployeeCommand { get; }
        public ReactiveCommand<Unit, Unit> AdminCommand { get; }

        public SelectRoleViewModel(List<Role> userRoleList)
        {
            ClientCommand = ReactiveCommand
                .CreateFromObservable(ExecuteClient);
            EmployeeCommand = ReactiveCommand
                .CreateFromObservable(ExecuteEmployee);
            AdminCommand = ReactiveCommand
                .CreateFromObservable(ExecuteAdmin);

            SetAction(SetVisibility, userRoleList);
        }

        private IObservable<Unit> ExecuteAdmin()
        {
            OpenMainWindow("Администратор");

            return Observable.Return(Unit.Default);
        }

        private IObservable<Unit> ExecuteEmployee()
        {
            OpenMainWindow("Сотрудник");

            return Observable.Return(Unit.Default);
        }

        private IObservable<Unit> ExecuteClient()
        {
            OpenMainWindow("Клиент");

            return Observable.Return(Unit.Default);
        }

        private void OpenMainWindow(string roleName)
        {
            MainWindow mainWindow = new MainWindow(roleName);
            mainWindow.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window is SelectRoleWindow)
                {
                    window.Close();
                }
            }
        }

        private void SetAction(LoadAll action, List<Role> roleList)
        {
            Load += action;

            foreach (var item in roleList)
            {
                Load(item);
            }

            Load -= action;
        }

        private void SetVisibility(Role role)
        {
            if (role.Value == "Клиент")
            {
                ClientVisibility = Visibility.Visible;
            }

            if (role.Value == "Сотрудник")
            {
                EmployeeVisibility = Visibility.Visible;
            }

            if (role.Value == "Администратор")
            {
                AdminVisibility = Visibility.Visible;
            }
        }
    }
}
