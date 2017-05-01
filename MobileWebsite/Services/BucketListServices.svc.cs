using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MobileApplication.Shared;
using MobileApplication.Controllers;
using System.ServiceModel.Activation;
using MemberShip;
using DataProvider.Interfaces;
using DataProvider;
using MobileWebsite.Controllers;
using Shared;
using MemberShip.dto;

namespace MobileApplication
{    
    //TODO - make all string literals constants
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class BucketListServices : IBucketListServices
    {
        public string ProcessUser(string encodedUser, string encodedPass)
        {
            IMemberShipData msd = new Data(Utility.GetAppSetting(BucketListConstants.DB_CONN));
            string token = string.Empty;

            try
            {
                string decodedUser = Utility.DecodeClientBase64String(encodedUser);
                string decodedPass = Utility.DecodeClientBase64String(encodedPass);
                
                LogProcessUserParameters(decodedUser, msd);

                token = VerifyUser(decodedUser, decodedPass, msd); 
                if (!string.IsNullOrEmpty(token))
                    msd.AddToken(decodedUser, token);
            }
            catch (Exception e)
            {
                msd.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return token;
        }                        
        public bool ProcessUserRegistration(string encodedUser,
                                            string encodedEmail,
                                            string encodedPass)
        {
            IMemberShipData msd = new Data(Utility.GetAppSetting(BucketListConstants.DB_CONN));
            bool userAdded = false;

            try
            {
                string decodedUser = Utility.DecodeClientBase64String(encodedUser);
                string decodedEmail = Utility.DecodeClientBase64String(encodedEmail);
                string decodedPass = Utility.DecodeClientBase64String(encodedPass);                

                IList<string> parameters = new List<string>();
                parameters.Add(decodedUser);
                parameters.Add(decodedEmail);
                CommonCode.Log(msd, null, "ProcessUserRegistration", parameters);

                Password p = new Password();
                NewPassword np = p.GetPassword(decodedPass);
                userAdded = msd.AddUser(decodedUser, decodedEmail, np.SaltedHashedPassword, np.Salt);
            }
            catch (Exception e)
            {
                msd.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }
            
            return userAdded;
        }
        public string[] GetBucketListItems(string encodedUserName, string encodedSortString, string encodedToken)
        {
            IBucketListData bld = new BucketListData(Utility.GetAppSetting(BucketListConstants.DB_CONN));
            string[] result = null;

            try
            {
                string decodedUserName = Utility.DecodeClientBase64String(encodedUserName);
                string decodedSortString = Utility.DecodeClientBase64String(encodedSortString);
                string decodedToken = Utility.DecodeClientBase64String(encodedToken);

                IList<string> parameters = new List<string>();
                parameters.Add(decodedUserName);
                parameters.Add(decodedSortString);
                CommonCode.Log(null, bld, "GetBucketListItems", parameters);

                if (ProcessToken(decodedUserName, decodedToken))
                    result = bld.GetBucketList(decodedUserName, decodedSortString);
                else
                {
                    result = Utility.GetInValidTokenResponse();
                }
            }
            catch (Exception e)
            {
                bld.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return result;
        }
        public string[] UpsertBucketListItem(string encodedBucketListItems, 
                                            string encodedUser, 
                                            string encodedToken)
        {
            IBucketListData bld = new BucketListData(Utility.GetAppSetting(BucketListConstants.DB_CONN));
            string[] result = null;

            try
            {
                string decodedBucketListItems = Utility.DecodeClientBase64String(encodedBucketListItems);
                string decodedToken = Utility.DecodeClientBase64String(encodedToken);
                string decodedUserName = Utility.DecodeClientBase64String(encodedUser);

                decodedBucketListItems = decodedBucketListItems.Trim(',');
                decodedBucketListItems = decodedBucketListItems.Trim(';');
                string[] items = decodedBucketListItems.Split(',');

                IList<string> parameters = new List<string>();
                foreach (string bucketListItem in items)
                    parameters.Add(bucketListItem);
                CommonCode.Log(null, bld, "UpsertBucketListItem", parameters);
                
                if (ProcessToken(decodedUserName, decodedToken))
                {
                    bld.UpsertBucketListItem(items);
                    result = Utility.GetValidTokenResponse();
                }
                else
                    result = Utility.GetInValidTokenResponse();
            }
            catch (Exception e)
            {
                bld.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return result;
        }
        public string[] DeleteBucketListItem(int bucketListDbId,
                                            string encodedUser,
                                            string encodedToken)
        {
            IBucketListData bld = new BucketListData(Utility.GetAppSetting(BucketListConstants.DB_CONN));
            string[] result = null;

            try
            {
                string decodedToken = Utility.DecodeClientBase64String(encodedToken);
                string decodedUserName = Utility.DecodeClientBase64String(encodedUser);

                IList<string> parameters = new List<string>();
                parameters.Add(bucketListDbId.ToString());
                CommonCode.Log(null, bld, "DeleteBucketListItem", parameters);

                if (ProcessToken(decodedUserName, decodedToken))
                {
                    bld.DeleteBucketListItem(bucketListDbId);
                    result = Utility.GetValidTokenResponse();
                }
                else
                    result = Utility.GetInValidTokenResponse();
            }
            catch (Exception e)
            {
                bld.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return result;
        }                
        private string VerifyUser(string userName, string password, IMemberShipData msd)
        {
            string token = string.Empty;
            User u = msd.GetUser(userName);

            if (u != null)
            {
                Password p = new Password();

                bool goodUser = p.UserExists(u, password);

                if (goodUser)
                    token = Utility.GenerateToken();
            }

            return token;
        }        
        private void LogProcessUserParameters(string userName, IMemberShipData msd)
        {
            IList<string> parameters = new List<string>();
            parameters.Add(userName);
            CommonCode.Log(msd, null, "ProcessUser", parameters);
        }
        private bool ProcessToken(string userName, string token)
        {
            bool goodToken = false;        
            IMemberShipData msd = new Data(Utility.GetAppSetting(BucketListConstants.DB_CONN));
            User u = msd.GetUser(userName);

            if (u != null 
                    && !string.IsNullOrEmpty(u.Token) 
                        && !string.IsNullOrEmpty(token) 
                            && u.Token.Equals(token))
            {
                byte[] data = Convert.FromBase64String(token);
                DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
                if (when >= DateTime.UtcNow.AddHours(-2)) {
                  goodToken = true;
                }
            }

            return goodToken;
        }
    }
}