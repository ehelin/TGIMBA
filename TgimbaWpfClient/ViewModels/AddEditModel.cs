namespace TgimbaWpfClient.ViewModels
{
    public class AddEditModel : BaseViewModel
    {
        private TgimbaApi tgimbaApi = null;

        public AddEditModel()
        {
            tgimbaApi = new TgimbaApi();
        }

        public bool AddBucketListItem(string name, string date, string category, bool achieved)
        {
            if (!BaseViewModel.IsLoggedIn())
            {
                return false; 
            }

            string newBucketListItem = PackageBucketListItem(name, date, category, achieved);

            var result = tgimbaApi.UpsertBucketListItem(newBucketListItem, BaseViewModel.userName, BaseViewModel.token);

            return HandleReturn(result);
        }
        public bool DeleteBucketListItem(string dbId)
        {
            if (!BaseViewModel.IsLoggedIn())
            {
                return false;
            }

            var result = tgimbaApi.DeleteBucketListItem(dbId, BaseViewModel.userName, BaseViewModel.token);

            return HandleReturn(result);
        }
        public bool EditBucketListItem(string[] bucketListItem)
        {
            if (!BaseViewModel.IsLoggedIn())
            {
                return false;
            }

            string[] bucketListItemWUserName = this.AddUserNameToBucketListItem(bucketListItem);
            string singleLineBucketListItem = FlattenBucketListItemArray(bucketListItemWUserName);

            var result = tgimbaApi.UpsertBucketListItem(singleLineBucketListItem, BaseViewModel.userName, BaseViewModel.token);

            return HandleReturn(result);
        }
        private string PackageBucketListItem(string name, string date, string category, bool achieved)
        {
            string[] newBucketListItem = new string[6];

            newBucketListItem[0] = name;
            newBucketListItem[1] = date;
            newBucketListItem[2] = category;

            if (achieved)
            {
                newBucketListItem[3] = "1";
            }
            else
            {
                newBucketListItem[3] = "0";
            }

            newBucketListItem[4] = "0";
            newBucketListItem[5] = BucketListModel.userName;

            string singleLineBucketListItem = FlattenBucketListItemArray(newBucketListItem);

            return singleLineBucketListItem;
        }
        private string FlattenBucketListItemArray(string[] bucketListItem)
        {
            string singleLineBucketListItem = "";

            foreach (string bucketListItemEntry in bucketListItem)
            {
                singleLineBucketListItem += "," + bucketListItemEntry;
            }

            return singleLineBucketListItem;
        }
        private bool HandleReturn(string[] result)
        {
            if (result != null && result.Length == 1 && result[0] == "TokenValid")
            {
                return true;
            }

            return false;
        }
    }
}
