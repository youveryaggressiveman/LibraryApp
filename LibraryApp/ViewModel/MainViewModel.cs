using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LibraryApp.Controllers;
using LibraryApp.Core;
using LibraryApp.Model;
using ReactiveUI;

namespace LibraryApp.ViewModel
{
    public class MainViewModel : ReactiveObject
    {
        private readonly MainViewModelController _controller;

        private readonly ObservableAsPropertyHelper<string> _fullName;
        private string _roleName;

        public string FullName => _fullName.Value;

        public delegate void LoadAllInfo();
        public event LoadAllInfo Load;

        public User ThisUser { get; set; }

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
            _controller = new MainViewModelController();

            RoleName = roleName;

            RouteEvent(new List<LoadAllInfo>(){LoadUser});

            _fullName = this
                .WhenAnyValue(x => x.ThisUser.SecondName + " " + x.ThisUser.FirstName + "."
                                   + (x.ThisUser.LastName != null ? x.ThisUser.LastName[0] + "." : ""))
                .Select(name => name.ToString())
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

        private async void LoadUser()
        {
            ThisUser = await _controller.GetUser();
        }
    }
}
