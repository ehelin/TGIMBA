namespace TgimbaWpfClient.ViewModels
{
    public class MenuModel : BaseViewModel
    {
        public void LogOut()
        {
            this.token = string.Empty;
        }
    }
}
