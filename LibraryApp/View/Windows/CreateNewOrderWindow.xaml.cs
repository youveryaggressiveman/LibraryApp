using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для CreateNewOrderWindow.xaml
    /// </summary>
    public partial class CreateNewOrderWindow : Window, IViewFor<CreateNewOrderViewModel>
    {
        public static readonly DependencyProperty CreateNewOrderViewModelProperty =
            DependencyProperty.Register(nameof(ViewModel), typeof(CreateNewOrderViewModel), typeof(CreateNewOrderWindow)); 

        public CreateNewOrderWindow(Client selectedClient)
        {
            InitializeComponent();

            this.Owner = App.Current.MainWindow;

            ViewModel = new CreateNewOrderViewModel(selectedClient);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (CreateNewOrderViewModel)value;
        }

        public CreateNewOrderViewModel ViewModel
        {
            get => (CreateNewOrderViewModel)GetValue(CreateNewOrderViewModelProperty); 
            set => SetValue(CreateNewOrderViewModelProperty, value);
        }
    }
}
