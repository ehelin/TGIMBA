﻿using Shared.Interfaces;
using Shared;
using CommonServiceCode;

namespace TgimbaWpfClient.ViewModels
{
    public class AddEditModel : BaseViewModel
    {
        private ITgimbaService service = null;

        public AddEditModel()
        {
            service = new TgimbaService();
        }

        private string PackageBucketListItem(string name, string date, string category, bool achieved)
        {
            string[] newBucketListItem = new string[6];
            string singleLineBucketListItem = "";

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

            foreach (string bucketListItemEntry in newBucketListItem)
            {
                singleLineBucketListItem += "," + bucketListItemEntry;
            }

            return singleLineBucketListItem;
        }

        public bool AddBucketListItem(string name, string date, string category, bool achieved)
        {
            if (!BaseViewModel.IsLoggedIn())
            {
                return false; 
            }

            string newBucketListItem = PackageBucketListItem(name, date, category, achieved);
            
            string base64NewBucketListItem = Utilities.EncodeClientBase64String(newBucketListItem);
            string base64UserName = Utilities.EncodeClientBase64String(BaseViewModel.userName);
            string base64Token = Utilities.EncodeClientBase64String(BaseViewModel.token);

            var result = service.UpsertBucketListItem(base64NewBucketListItem, base64UserName, base64Token);

            if (result != null && result.Length == 1 && result[0] == "TokenValid")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
