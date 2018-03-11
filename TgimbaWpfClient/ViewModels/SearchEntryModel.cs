namespace TgimbaWpfClient.ViewModels
{
    public class SearchEntryModel : BaseViewModel
    {
        public SearchEntryModel() { }

        public void SetSearchTerm(string srchTerm)
        {
            BaseViewModel.srchTerm = srchTerm;
        }
    }
}
