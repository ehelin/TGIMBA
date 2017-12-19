using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface ITgimbaService : IService
    {
        string GetTestResult();
        string ProcessUser(string encodedUser, string encodedPass);
        bool ProcessUserRegistration(string encodedUser, string encodedEmail, string encodedPass);
        string[] GetBucketListItems(string encodedUserName, string encodedSortString, string encodedToken);
        string[] UpsertBucketListItem(string encodedBucketListItems, string encodedUser, string encodedToken);
        string[] DeleteBucketListItem(int bucketListDbId, string encodedUser, string encodedToken);
        string[] GetDashboard();
        void GetDaily();
    }
}
