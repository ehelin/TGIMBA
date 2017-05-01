using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Services
{
    [ServiceContract]
    public interface IBucketListServices
    {
        [OperationContract]
        string GetTestResult();

        [OperationContract]
        string LoginDemoUser();

        [OperationContract]
        string ProcessUser(string encodedUser,
                           string encodedPass);

        [OperationContract]
        bool ProcessUserRegistration(string encodedUser,
                                     string encodedEmail,
                                     string encodedPass);

        [OperationContract]
        string[] GetBucketListItems(string encodedUserName,
                                    string encodedSortString,
                                    string encodedToken);

        [OperationContract]
        string[] GetBucketListItemsV2(string encodedUserName,
                                      string encodedSortString,
                                      string encodedToken);

        [OperationContract]
        string[] UpsertBucketListItem(string encodedBucketListItems,
                                            string encodedUser,
                                            string encodedToken);

        [OperationContract]
        string[] UpsertBucketListItemV2(string encodedBucketListItems,
                                        string encodedUser,
                                        string encodedToken);

        [OperationContract]
        string[] DeleteBucketListItem(int bucketListDbId,
                                            string encodedUser,
                                            string encodedToken);

        [OperationContract]
        string[] GetDashboard();
    }
}
