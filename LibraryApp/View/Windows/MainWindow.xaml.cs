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
using LibraryApp.Core;
using LibraryApp.ViewModel;
using ReactiveUI;

namespace LibraryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IViewFor<MainViewModel>
    {
        public static readonly DependencyProperty MainViewModelProperty =
            DependencyProperty.Register(nameof(ViewModel), typeof(MainViewModel), typeof(MainWindow));

        public MainWindow(string roleName)
        {
            InitializeComponent();

            ViewModel = new MainViewModel(roleName);

            FrameManager.MainFrame = mainFrame;
            FrameManager.SetSource(ViewModel.LoadFrame());

            this.WhenActivated(disposable =>
            {
                this.OneWayBind(this.ViewModel, fullName => fullName.FullName,
                        fullName => fullName.fullNameTextBlock.Text)
                    .DisposeWith(disposable);
                this.OneWayBind(this.ViewModel, role => role.RoleName, role => role.roleTextBlock.Text)
                    .DisposeWith(disposable);
                this.Bind(this.ViewModel, userInfo => userInfo.VisibilityUserInfo,
                        userInfo => userInfo.userInfoStackPanel.Visibility)
                    .DisposeWith(disposable);
            });
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (MainViewModel)value;
        }

        public MainViewModel ViewModel
        {
            get => (MainViewModel)GetValue(MainViewModelProperty); 
            set => SetValue(MainViewModelProperty, value); 

        }
    }
}
