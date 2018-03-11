using System.Windows.Controls;
using TgimbaWpfClient.ViewModels;

namespace TgimbaWpfClient.Views
{
    public partial class MenuView : UserControl
    {
        private MenuModel menuModel = null;

        public MenuView()
        {
            InitializeComponent();

            menuModel = new MenuModel();
        }

        private void btnAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.Instance.SetCurrentPanel(UseControls.AddEdit);
        }

        private void btnLogout_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            menuModel.LogOut();
            MainWindow.Instance.SetCurrentPanel(UseControls.Login);
        }

        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.Instance.SetCurrentPanel(UseControls.BucketList);
        }

        private void btnSearch_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.Instance.SetCurrentPanel(UseControls.SearchEntry);
        }
    }
}
