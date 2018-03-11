namespace TgimbaWpfClient.ViewModels
{
    public class MenuModel : BaseViewModel
    {
        public void LogOut()
        {
            BaseViewModel.token = string.Empty;
            BaseViewModel.userName = string.Empty;
        }
    }
}
