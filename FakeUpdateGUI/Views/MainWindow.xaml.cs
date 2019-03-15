using FakeUpdate.Models;
using FakeUpdate.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace FakeUpdate.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel ViewModel { get; } = new MainViewModel();
        public MainWindow(bool enableUnsafe)
        {
            DataContext = ViewModel;
            InitializeComponent();
            if (!enableUnsafe)
            {
                Command.IsEnabled = false;
            }
            else
            {
                Title += " (Unsafe mode)";
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if(ViewModel.SelectedUpdate.Progress < 0 || ViewModel.SelectedUpdate.Progress > 90)
            {
                MessageBox.Show("Progress must start from 0 to 90", "Invalid parameters", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }

            if (ViewModel.SelectedUpdate.Seconds < 1 || ViewModel.SelectedUpdate.Seconds > 10)
            {
                MessageBox.Show("Duration must be from the range of 1 to 10", "Invalid parameters", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(!string.IsNullOrWhiteSpace(ViewModel.SelectedUpdate.Command))
            {
                MessageBoxResult result = MessageBox.Show("Using a CMD command can be dangerous. By using a wrong command you can potentially destroy your PC! I will not be reponsible for any damage caused by using the wrong command. Please check again to make sure what you're intended:"
                    + Environment.NewLine + Environment.NewLine + ViewModel.SelectedUpdate.Command +
                    Environment.NewLine + Environment.NewLine + "If you are running what you're intended, you can click Yes, otherwise click No",
                    "Be careful!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if(result == MessageBoxResult.No)
                {
                    return;
                }
            }
            ViewModel.SelectedUpdate.ShowView();
        }
    }
}
