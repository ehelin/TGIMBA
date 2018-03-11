using Shared.Interfaces;
using Shared;
using CommonServiceCode;

namespace TgimbaWpfClient.ViewModels
{
    public class LoginModel : BaseViewModel
    {
        private ITgimbaService service = null;

        public LoginModel()
        {
            service = new TgimbaService();
        }

        public bool Login(string userName, string passWord) {
            bool loggedIn = false;
            string base64UserName = Utilities.EncodeClientBase64String(userName);
            string base64Password = Utilities.EncodeClientBase64String(passWord);

            var token = service.ProcessUser(base64UserName, base64Password);

            if (!string.IsNullOrEmpty(token))
            {
                loggedIn = true;
                this.token = token;
            } 

            return loggedIn;
        }
    }
}
