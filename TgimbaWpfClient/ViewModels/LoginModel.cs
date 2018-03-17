namespace TgimbaWpfClient.ViewModels
{
    public class LoginModel : BaseViewModel
    {
        private TgimbaApi tgimbaApi = null;

        public LoginModel()
        {
            tgimbaApi = new TgimbaApi();
        }

        public bool Login(string userName, string passWord) {
            bool loggedIn = false;

            var token = tgimbaApi.ProcessUser(userName, passWord);

            if (!string.IsNullOrEmpty(token))
            {
                loggedIn = true;

                BaseViewModel.token = token;
                BaseViewModel.userName = userName;
            } 

            return loggedIn;
        }
    }
}
