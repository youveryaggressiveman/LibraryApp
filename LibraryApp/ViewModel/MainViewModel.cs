using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LibraryApp.Core;
using LibraryApp.Model;
using ReactiveUI;

namespace LibraryApp.ViewModel
{
    public class MainViewModel : ReactiveObject
    {
        private readonly ObservableAsPropertyHelper<string> _fullName;
        private string _role;

        public string FullName => _fullName.Value;

        public User ThisUser { get; set; }

        public string Role
        {
            get => _role;
            set
            {
                this.RaiseAndSetIfChanged(ref _role, value, nameof(Role));
            }
        }

        public MainViewModel()
        {
            ThisUser = UserSingleton.User;

            _fullName = this
                .WhenAnyValue(x => x.ThisUser.SecondName + " " + x.ThisUser.FirstName + "."
                                   + (x.ThisUser.LastName != null ? x.ThisUser.LastName[0] + "." : ""))
                .Select(name => name.ToString())
                .ToProperty(this, nameof(FullName));
        }
    }
}
