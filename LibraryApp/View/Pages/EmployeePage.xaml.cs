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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibraryApp.ViewModel;
using ReactiveUI;

namespace LibraryApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page, IViewFor<EmployeeViewModel>
    {
        private static readonly DependencyProperty EmployeeViewModelProperty =
            DependencyProperty.Register(nameof(ViewModel), typeof(EmployeeViewModel), typeof(EmployeePage));

        public EmployeePage()
        {
            InitializeComponent();

            ViewModel = new EmployeeViewModel();

            this.WhenActivated(disposable =>
            {
                this.Bind(this.ViewModel, list => list.ClientList, list => list.dataGrid.ItemsSource)
                    .DisposeWith(disposable);
            });
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (EmployeeViewModel)value;
        }

        public EmployeeViewModel ViewModel
        {
            get => (EmployeeViewModel)GetValue(EmployeeViewModelProperty);
            set => SetValue(EmployeeViewModelProperty, value);
        }
    }
}
