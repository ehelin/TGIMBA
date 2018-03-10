using System.Windows;
using Shared.Interfaces;
using CommonServiceCode;
using TgimbaWpfClient;

namespace TgimbaWpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Test();
            Instance = this;
        }
        public static MainWindow Instance;

        private void Test()
        {
            ITgimbaService service = new TgimbaService();
            var result = service.GetDashboard();
            int test = 1;
            var tesft = ucBucketList.ActualHeight;
        }

        public void SetCurrentPanel(UseControls userControl)
        {
            HideAllUserControls();

            if (userControl == UseControls.Login) 
            {
                ucLogin.Visibility = Visibility.Visible;
            }
            else if (userControl == UseControls.BucketList)
            {
                ucBucketList.Visibility = Visibility.Visible;
            }
        }

        private void HideAllUserControls() {
            ucLogin.Visibility = Visibility.Hidden;
            ucBucketList.Visibility = Visibility.Hidden;
        }
    }
}
