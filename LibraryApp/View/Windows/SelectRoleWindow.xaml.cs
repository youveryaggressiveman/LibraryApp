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

        public SelectRoleWindow()
        {
            InitializeComponent();

            ViewModel = new SelectRoleViewModel();

            this.WhenActivated(disposable =>
            {
                
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
