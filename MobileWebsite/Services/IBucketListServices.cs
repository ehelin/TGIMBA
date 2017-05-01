using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MobileApplication
{
    [ServiceContract]
    public interface IBucketListServices
    {
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
        string[] UpsertBucketListItem(string encodedBucketListItems,
                                            string encodedUser,
                                            string encodedToken);

        [OperationContract]
        string[] DeleteBucketListItem(int bucketListDbId,
                                            string encodedUser,
                                            string encodedToken);
    }
}
