using System;
using System.ServiceModel.Activation;
using CommonServiceCode;

namespace Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class BucketListServices : IBucketListServices
    {
        private TgimbaService client = null;

        public BucketListServices()
        {
            string dbConn = System.Configuration.ConfigurationManager.AppSettings["BucketListDbConnStrProd"];
            client = new TgimbaService();

        }

        public string LoginDemoUser()
        {
            string token = client.LoginDemoUser();

            return token;
        }
        public string GetTestResult()
        {
            string result = client.GetTestResult();

            return result;
        }
        public string ProcessUser(string encodedUser, string encodedPass)
        {
            string token = client.ProcessUser(encodedUser, encodedPass);

            return token;
        }
        public bool ProcessUserRegistration(string encodedUser,
                                            string encodedEmail,
                                            string encodedPass)
        {
            bool userAdded = client.ProcessUserRegistration(encodedUser, encodedEmail, encodedPass);

            return userAdded;
        }
        public string[] GetBucketListItems(string encodedUserName, string encodedSortString, string encodedToken)
        {
            string[] result = client.GetBucketListItems(encodedUserName, encodedSortString, encodedToken);

            return result;
        }
        public string[] GetBucketListItemsV2(string encodedUserName, string encodedSortString, string encodedToken)
        {
            string[] result = client.GetBucketListItemsV2(encodedUserName, encodedSortString, encodedToken);

            return result;
        }
        public string[] UpsertBucketListItem(string encodedBucketListItems,
                                            string encodedUser,
                                            string encodedToken)
        {
            string[] result = client.UpsertBucketListItem(encodedBucketListItems, encodedUser, encodedToken);

            return result;
        }
        public string[] UpsertBucketListItemV2(string encodedBucketListItems,
                                               string encodedUser,
                                               string encodedToken)
        {
            string[] result = client.UpsertBucketListItemV2(encodedBucketListItems, encodedUser, encodedToken);

            return result;
        }
        public string[] DeleteBucketListItem(int bucketListDbId,
                                            string encodedUser,
                                            string encodedToken)
        {
            string[] result = client.DeleteBucketListItem(bucketListDbId, encodedUser, encodedToken);

            return result;
        }
        public string[] GetDashboard()
        {
            string[] results = client.GetDashboard();

            return results;
        }
    }
}
