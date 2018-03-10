using System.Windows;
using System.Windows.Controls;
using TgimbaWpfClient;

namespace TgimbaWpfClient.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.SetCurrentPanel(UseControls.BucketList);
        }
    }
}
