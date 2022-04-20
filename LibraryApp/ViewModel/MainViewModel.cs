using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LibraryApp.Controllers;
using LibraryApp.Core;
using LibraryApp.Core.Singleton;
using LibraryApp.Model;
using LibraryApp.View.Pages;
using ReactiveUI;

namespace LibraryApp.ViewModel
{
    public class MainViewModel : ReactiveObject
    {
        private readonly ObservableAsPropertyHelper<string> _fullName;

        private Visibility _visibilityUserInfo = Visibility.Visible;
        private string _roleName;

        public string FullName => _fullName.Value;

        public delegate void LoadAllInfo();
        public event LoadAllInfo Load;

        public User ThisUser { get; set; }

        public Visibility VisibilityUserInfo
        {
            get => _visibilityUserInfo;
            set => this.RaiseAndSetIfChanged(ref _visibilityUserInfo, value, nameof(VisibilityUserInfo));
        }

        public string RoleName
        {
            get => _roleName;
            set
            {
                this.RaiseAndSetIfChanged(ref _roleName, value, nameof(RoleName));
            }
        }

        public MainViewModel(string roleName)
        {
            if (roleName == null && UserSingleton.User == null)
            {
                VisibilityUserInfo = Visibility.Collapsed;
            }
            else
            {
                RoleName = roleName;
                ThisUser = UserSingleton.User;
                
            }
            _fullName = this.WhenAnyValue(x => x.ThisUser)
                .Select(name => (name?.FirstName != null ? name.FirstName + " " : "")
                                + (name?.SecondName != null ? name.SecondName[0] + "." : "")
                                + (name?.LastName != null ? name.LastName[0] + "." : ""))
                .ToProperty(this, nameof(FullName));
        }

        private void RouteEvent(List<LoadAllInfo> action)
        {
            foreach (var item in action)
            {
                Load += item;
                Load.Invoke();
                Load -= item;
            }
        }

        public Page LoadFrame()
        {
            if (RoleName == "Клиент" || RoleName == null)
            {
                return new ClientPage();
            }

            if (RoleName == "Сотрудник")
            {
                return new EmployeePage();
            }

            return new AdminPage();
        }
    }
}
