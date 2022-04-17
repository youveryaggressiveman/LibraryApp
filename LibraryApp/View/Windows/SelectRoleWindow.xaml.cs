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
using LibraryApp.Model;
using LibraryApp.ViewModel;
using ReactiveUI;

namespace LibraryApp.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для SelectRoleWindow.xaml
    /// </summary>
    public partial class SelectRoleWindow : Window, IViewFor<SelectRoleViewModel>
    {
        private static readonly DependencyProperty SelectRoleViewModelProperty =
            DependencyProperty.Register(nameof(ViewModel), typeof(SelectRoleViewModel), typeof(SelectRoleWindow));

        public SelectRoleWindow(List<Role> roleList)
        {
            InitializeComponent();

            ViewModel = new SelectRoleViewModel(roleList);

            this.Owner = Application.Current.MainWindow;

            this.WhenActivated(disposable =>
            {
                this.BindCommand(this.ViewModel, command => command.ClientCommand, command => command.clientButton)
                    .DisposeWith(disposable);
                this.Bind(this.ViewModel, visibility => visibility.ClientVisibility,
                        visibility => visibility.clientButton.Visibility)
                    .DisposeWith(disposable);
                this.BindCommand(this.ViewModel, command => command.EmployeeCommand, command => command.employeeButton)
                    .DisposeWith(disposable);
                this.Bind(this.ViewModel, visibility => visibility.EmployeeVisibility,
                        visibility => visibility.employeeButton.Visibility)
                    .DisposeWith(disposable);
                this.BindCommand(this.ViewModel, command => command.AdminCommand, command => command.adminButton)
                    .DisposeWith(disposable);
                this.Bind(this.ViewModel, visibility => visibility.AdminVisibility,
                        visibility => visibility.adminButton.Visibility)
                    .DisposeWith(disposable);

            });
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (SelectRoleViewModel)value;
        }

        public SelectRoleViewModel ViewModel
        {
            get => (SelectRoleViewModel)GetValue(SelectRoleViewModelProperty);
            set => SetValue(SelectRoleViewModelProperty, value);
        }
    }
}
