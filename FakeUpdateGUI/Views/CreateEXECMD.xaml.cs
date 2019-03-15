using System.IO;
using System.Windows;

namespace FakeUpdate.Views
{
    /// <summary>
    /// Interaction logic for CreateEXECMD.xaml
    /// </summary>
    public partial class CreateEXECMD : Window
    {
        public CreateEXECMD(string cmd)
        {
            InitializeComponent();
            Loaded += (sender, args) => {
                FileName.Text = "Self-triggering Update.exe";
                CommandBox.Text = cmd;
            };
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
