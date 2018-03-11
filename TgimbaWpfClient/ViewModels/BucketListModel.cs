using Shared.Interfaces;
using CommonServiceCode;

namespace TgimbaWpfClient.ViewModels
{
    public class BucketListModel : BaseViewModel
    {
        private ITgimbaService service = null;

        public BucketListModel()
        {
            service = new TgimbaService();
        }

        public string[] GetBucketListItems()
        {
            return BaseViewModel.GetBucketListItems();
        }
    }
}
