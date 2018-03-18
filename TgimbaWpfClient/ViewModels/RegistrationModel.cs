namespace TgimbaWpfClient.ViewModels
{
    public class RegistrationModel : BaseViewModel
    {
        private TgimbaApi tgimbaApi = null;

        public RegistrationModel()
        {
            tgimbaApi = new TgimbaApi();
        }

        public bool Register(string userName, string email, string passWord)
        {
            if (!Utilities.ValidUserToRegistration(userName, email, passWord)) {
                return false;
            }

            if (tgimbaApi.ProcessUserRegistration(userName, email, passWord)) {
                return true;
            } else {
                return false;
            }
        }
    }
}