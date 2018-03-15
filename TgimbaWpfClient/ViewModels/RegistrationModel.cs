using Shared.Interfaces;
using Shared;
using CommonServiceCode;

namespace TgimbaWpfClient.ViewModels
{
    public class RegistrationModel : BaseViewModel
    {
        private ITgimbaService service = null;

        public RegistrationModel()
        {
            service = new TgimbaService();
        }

        public bool Register(string userName, string email, string passWord)
        {
            if (!Shared.Utilities.ValidUserToRegistration(userName, email, passWord)) {
                return false;
            }

            string base64UserName = Shared.Utilities.EncodeClientBase64String(userName);
            string base64Email = Shared.Utilities.EncodeClientBase64String(email);
            string base64Password = Shared.Utilities.EncodeClientBase64String(passWord);

            if (service.ProcessUserRegistration(base64UserName, base64Email, base64Password)) {
                return true;
            } else {
                return false;
            }
        }
    }
}