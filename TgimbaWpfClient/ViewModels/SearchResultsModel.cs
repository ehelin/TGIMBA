using System.Collections.Generic;

namespace TgimbaWpfClient.ViewModels
{
    public class SearchResultsModel : BaseViewModel
    {
        public SearchResultsModel() { }

        public string[] SearchBucketListItems()
        {
            string searchTerm = BaseViewModel.srchTerm;
            List<string> fndBucketListItems = new List<string>();
            string[] bucketListItems = BaseViewModel.GetBucketListItems();

            foreach (string bucketListItem in bucketListItems)
            {
                if (bucketListItem.IndexOf(searchTerm) != -1)
                {
                    fndBucketListItems.Add(bucketListItem);
                }
            }

            BaseViewModel.srchTerm = string.Empty;

            return fndBucketListItems.ToArray();
        }
    }
}
