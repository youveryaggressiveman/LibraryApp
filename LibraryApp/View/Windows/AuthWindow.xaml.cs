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
using System.Windows.Shapes;
using LibraryApp.ViewModel;
using ReactiveUI;

namespace LibraryApp.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window, IViewFor<AuthViewModel>
    {
        public static readonly DependencyProperty AuthViewModelProperty =
            DependencyProperty.Register(nameof(ViewModel), typeof(AuthViewModel), typeof(AuthWindow));

        public AuthWindow()
        {
            InitializeComponent();

            ViewModel = new AuthViewModel();

            this.WhenActivated(disposable =>
            {
                this.Bind(this.ViewModel, user => user.Login, user => user.loginTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(this.ViewModel, user => user.Password, user => user.pswBox.Password)
                    .DisposeWith(disposable);
                this.BindCommand(this.ViewModel, command => command.AuthCommand, command => command.authButton)
                    .DisposeWith(disposable);
            });
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (AuthViewModel)value;
        }

        public AuthViewModel ViewModel
        {
            get => (AuthViewModel)GetValue(AuthViewModelProperty);
            set => SetValue(AuthViewModelProperty, value);
        }
    }
}
