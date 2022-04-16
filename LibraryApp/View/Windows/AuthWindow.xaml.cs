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
using LibraryApp.Core;
using LibraryApp.View.Pages;
using LibraryApp.ViewModel;
using ReactiveUI;

namespace LibraryApp.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {

        public AuthWindow()
        {
            InitializeComponent();

            FrameMangaer.MainFrame = loginFrame;
            FrameMangaer.SetSource(new LoginPage());

            //this.WhenActivated(disposable =>
            //{
            //    this.Bind(this.ViewModel, user => user.Login, user =>user.loginFrame)
            //        .DisposeWith(disposable);
            //    this.BindCommand(this.ViewModel, command => command.AuthCommand, command => command.authButton)
            //        .DisposeWith(disposable);
            //});
        }
    }
}
