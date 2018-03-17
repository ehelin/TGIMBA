namespace TgimbaWpfClient.ViewModels
{
    public class BucketListModel : BaseViewModel
    {
        public BucketListModel() {}
        public string[] GetBucketListItems()
        {
            return BaseViewModel.GetBucketListItems();
        }
    }
}
