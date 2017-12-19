using Shared.Dto;
using System;

namespace BucketListDataProvider
{
    public interface IBucketListData
    {
        string[] GetBucketList(string userName, string sortString);
        bool UpsertBucketListItem(string[] bucketListItems);
        bool DeleteBucketListItem(int bucketListItemDbId);
        void LogMsg(string msg);
        void LogBrowserCapability(int browserLogId, string key, string val);
        void DeleteTestUser(string userName);
        string[] GetDashboard();

        string[] GetBucketListV2(string userName, string sortString);
        bool UpsertBucketListItemV2(string[] bucketListItems);
    }
}