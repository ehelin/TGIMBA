using Shared;
using Shared.Interfaces;
using CommonServiceCode;

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

            ITgimbaService service = new TgimbaService();
            string base64UserName = Utilities.EncodeClientBase64String(BaseViewModel.userName);
            string base64Token = Utilities.EncodeClientBase64String(BaseViewModel.token);
            string base64SortString = string.Empty; // TODO - edit when sorting starts

            string[] bucketListItems = service.GetBucketListItems(base64UserName, base64SortString, base64Token);

            return bucketListItems;
        }
    }
}
