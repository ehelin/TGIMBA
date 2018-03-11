using System.Windows;
using System.Windows.Controls;
using TgimbaWpfClient.ViewModels;

namespace TgimbaWpfClient.Views
{
    public partial class LoginView : UserControl
    {
        private LoginModel loginModel = null;

        public LoginView()
        {
            InitializeComponent();

            loginModel = new LoginModel();
            clearFields();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string userName = tbUserName.Text;
            string passWord = tbPassword.Password;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord)) {
                MessageBox.Show("Please enter a user name and password", "Login", MessageBoxButton.OK);
            } else
            {
                if (!loginModel.Login(userName, passWord))
                {
                    MessageBox.Show("Login failed.  Please try again", "Login", MessageBoxButton.OK);
                    clearFields();
                }
                else
                {
                    clearFields();
                    MainWindow.Instance.SetCurrentPanel(UseControls.BucketList);
                }
            }
        }

        private void clearFields()
        {
            tbUserName.Text = string.Empty;
            tbPassword.Password = string.Empty;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.SetCurrentPanel(UseControls.Registration);
        }
    }
}
