namespace TgimbaWpfClient.ViewModels
{
    public class BaseViewModel
    {
        protected static string token = string.Empty;
        protected static string userName = string.Empty;
        protected static string srchTerm = string.Empty;

        protected static bool IsLoggedIn()
        {
            // TODO - make call to verify token has not timed out
            if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(userName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected static string[] GetBucketListItems()
        {
            if (!BaseViewModel.IsLoggedIn())
            {
                return null; // TODO - future states will require returning no items
            }

            TgimbaApi tgimbaApi = new TgimbaApi();
            string sortString = string.Empty; // TODO - edit when sorting starts

            string[] bucketListItems = tgimbaApi.GetBucketListItems(BaseViewModel.userName, sortString, BaseViewModel.token);

            return bucketListItems;
        }
        protected string[] AddUserNameToBucketListItem(string[] bucketListItem)
        {
            string[] bucketListItemWUserName = new string[bucketListItem.Length+1];

            for (int i = 0; i < bucketListItem.Length; i++)
            {
                bucketListItemWUserName[i] = bucketListItem[i];
            }
            bucketListItemWUserName[bucketListItem.Length] = BaseViewModel.userName;

            return bucketListItemWUserName;
        }
    }
}
