using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LibraryApp.Controllers;
using LibraryApp.Core;
using LibraryApp.Core.Helper;
using LibraryApp.Core.Singleton;
using LibraryApp.Model;
using LibraryApp.Model.DataVIewModel;
using LibraryApp.View.Windows;
using ReactiveUI;

namespace LibraryApp.ViewModel
{
    public class AuthViewModel : ReactiveObject
    {
        private readonly AuthController _controller;
        private readonly AuthHelper _authHelper;

        private string _login;
        private string _password;

        public delegate void LoadAll();

        public event LoadAll Load;

        public string Login
        {
            get => _login;
            set => this.RaiseAndSetIfChanged(ref _login, value, nameof(Login));
        }

        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value, nameof(Password));
        }

        public ReactiveCommand<Unit, Unit> OpenRegistration { get; }
        public ReactiveCommand<Unit, Unit> AuthCommand { get; }

        public AuthViewModel()
        {
            _authHelper = new AuthHelper();
            _controller = new AuthController();

            OpenRegistration = ReactiveCommand
                .CreateFromObservable(ExecuteOpenWindow);
            AuthCommand = ReactiveCommand
                .CreateFromObservable(ExecuteAuth);

        }

        private IObservable<Unit> ExecuteOpenWindow()
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window is AuthWindow)
                {
                    window.Close();
                }
            }

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

        private IObservable<Unit> ExecuteAuth()
        {
            RouteEvent(new List<LoadAll>(){CheckInfo});

            return Observable.Return(Unit.Default);
        }

        private async void CheckInfo()
        {
            var user = new User(Login, Password);
            var context = new ValidationContext(user);
            var results = new List<ValidationResult>();

            if (Validator.TryValidateObject(user, context, results, true))
            {
                if (await _authHelper.AuthHelp(user))
                {
                    if (UserSingleton.User.RoleOfUsers.Count == 1)
                    {
                        try
                        {
                            if (await  _controller.Authorize(new AuthorizeUser()
                                    { Login = "admin", Password = "admin", RoleID = 1 }))
                            {
                                UserSingleton.User = null;

                                MainWindow mainWindow = new MainWindow();
                                mainWindow.Show();

                                foreach (Window window in Application.Current.Windows)
                                {
                                    if (window is AuthWindow)
                                    {
                                        window.Close();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Произошла ошибка при авторизации, повторите попытку позже.", "Ошибка",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Произошла ошибка подключения.", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        
                    }
                    //Будет работать при наличии нескольких ролей у пользователя
                    else
                    {
                        SelectRoleWindow selectRoleWindow = new SelectRoleWindow();
                        selectRoleWindow.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь не найден", "Информация", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
            else
            {
                foreach (var error in results)
                {
                    MessageBox.Show(error.ErrorMessage);
                }
            }
        }
    }
}
