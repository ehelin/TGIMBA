using System.Windows;
using System.Windows.Controls;
using TgimbaWpfClient.ViewModels;

namespace TgimbaWpfClient.Views
{
    public partial class RegistrationView : UserControl
    {
        private RegistrationModel registrationModel = null;

        public RegistrationView()
        {
            InitializeComponent();

            registrationModel = new RegistrationModel();
            clearFields();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string userName = tbUserName.Text;
            string email = tbEmail.Text;
            string passWord = tbPassword.Password;
            string confirmPassword = tbConfirmPassword.Password;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord) || (passWord != confirmPassword))
            {
                MessageBox.Show("Please enter a username, email and matching passwords", "Registration", MessageBoxButton.OK);
            }
            else
            {
                if (!registrationModel.Register(userName, email, passWord))
                {
                    MessageBox.Show("Registration failed.  Please try again", "Registration", MessageBoxButton.OK);
                    clearFields();
                }
                else
                {
                    clearFields();
                    MainWindow.Instance.SetCurrentPanel(UseControls.Login);
                }
            }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.SetCurrentPanel(UseControls.Login);
        }
        private void clearFields()
        {
            tbUserName.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbPassword.Password = string.Empty;
            tbConfirmPassword.Password = string.Empty;
        }
    }
}
