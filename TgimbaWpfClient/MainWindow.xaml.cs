using System.Windows;

namespace TgimbaWpfClient
{
    public partial class MainWindow : Window
    {
        public static MainWindow Instance;

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
        }

        public void SetCurrentPanel(UseControls userControl)
        {
            HideAllUserControls();

            switch (userControl) {
                case UseControls.AddEdit:
                    ucAditEdit.Visibility = Visibility.Visible;
                    break;
                case UseControls.BucketList:
                    ucBucketList.Visibility = Visibility.Visible;
                    break;
                case UseControls.Menu:
                    ucMenu.Visibility = Visibility.Visible;
                    break;
                case UseControls.Registration:
                    ucRegistration.Visibility = Visibility.Visible;
                    break;
                case UseControls.SearchEntry:
                    ucSearchEntry.Visibility = Visibility.Visible;
                    break;
                case UseControls.SeachResults:
                    ucSearchResults.Visibility = Visibility.Visible;
                    break;
                default:
                    ucLogin.Visibility = Visibility.Visible;
                    break;
            }
        }
        private void HideAllUserControls() {
            ucAditEdit.Visibility = Visibility.Hidden;
            ucBucketList.Visibility = Visibility.Hidden;
            ucLogin.Visibility = Visibility.Hidden;
            ucMenu.Visibility = Visibility.Hidden;
            ucRegistration.Visibility = Visibility.Hidden;
            ucSearchEntry.Visibility = Visibility.Hidden;
            ucSearchResults.Visibility = Visibility.Hidden;
        }
    }
}
