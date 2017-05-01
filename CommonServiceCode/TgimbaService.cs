using AccountDataProvider;
using AccountDataProvider.Interfaces;
using BucketListDataProvider;
using Shared;
using Shared.Dto;
using Shared.Interfaces;
using AccountDataProvider.dto;
using System;

namespace CommonServiceCode
{
    public class TgimbaService : ITgimbaService
    {
        public string GetTestResult()
        {
            return "Test Service Response";
        }

        public string LoginDemoUser()
        {
            string token = string.Empty;
            IMemberShipData msd = null;

            try
            {
                msd = new Data(Utilities.GetDbSetting());
                token = VerifyUser(AccountDataProvider.Constants.DEMO_USER, AccountDataProvider.Constants.DEMO_USER_PASSWORD, msd);

                if (!string.IsNullOrEmpty(token))
                    msd.AddToken(AccountDataProvider.Constants.DEMO_USER, token);
            }
            catch (Exception e)
            {
                msd.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return token;
        }

        public string ProcessUser(string encodedUser, string encodedPass)
        {
            IMemberShipData msd = null;
            string token = string.Empty;

            try
            {
                msd = new Data(Utilities.GetDbSetting());
                string decodedUser = Utilities.DecodeClientBase64String(encodedUser);
                string decodedPass = Utilities.DecodeClientBase64String(encodedPass);

                //LogParameters();

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

        public bool ProcessUserRegistration(string encodedUser, string encodedEmail, string encodedPass)
        {
            IMemberShipData msd = null;
            bool userAdded = false;

            try
            {
                msd = new Data(Utilities.GetDbSetting());
                string decodedUser = Utilities.DecodeClientBase64String(encodedUser);
                string decodedEmail = Utilities.DecodeClientBase64String(encodedEmail);
                string decodedPass = Utilities.DecodeClientBase64String(encodedPass);

                //LogParameters();
                if (Utilities.ValidUserToRegistration(decodedUser, decodedEmail, decodedPass))
                {
                    Password p = new Password();
                    NewPassword np = p.GetPassword(decodedPass);
                    userAdded = msd.AddUser(decodedUser, decodedEmail, np.SaltedHashedPassword, np.Salt);
                }
            }
            catch (Exception e)
            {
                msd.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return userAdded;
        }

        public string[] GetBucketListItems(string encodedUserName, string encodedSortString, string encodedToken)
        {
            IBucketListData bld = null;
            string[] result = null;

            try
            {
                bld = new BucketListData(Utilities.GetDbSetting());

                string decodedUserName = Utilities.DecodeClientBase64String(encodedUserName);
                string decodedSortString = Utilities.DecodeClientBase64String(encodedSortString);
                string decodedToken = Utilities.DecodeClientBase64String(encodedToken);

                //LogParameters();

                if (ProcessToken(decodedUserName, decodedToken))
                    result = bld.GetBucketList(decodedUserName, decodedSortString);
                else
                {
                    result = Utilities.GetInValidTokenResponse();
                }
            }
            catch (Exception e)
            {
                bld.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return result;
        }

        public string[] GetBucketListItemsV2(string encodedUserName, string encodedSortString, string encodedToken)
        {
            IBucketListData bld = null;
            string[] result = null;

            try
            {
                bld = new BucketListData(Utilities.GetDbSetting());

                string decodedUserName = Utilities.DecodeClientBase64String(encodedUserName);
                string decodedSortString = Utilities.DecodeClientBase64String(encodedSortString);
                string decodedToken = Utilities.DecodeClientBase64String(encodedToken);

                //LogParameters();

                if (ProcessToken(decodedUserName, decodedToken))
                    result = bld.GetBucketListV2(decodedUserName, decodedSortString);
                else
                {
                    result = Utilities.GetInValidTokenResponse();
                }
            }
            catch (Exception e)
            {
                bld.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return result;
        }

        public string[] UpsertBucketListItem(string encodedBucketListItems, string encodedUser, string encodedToken)
        {
            IBucketListData bld = null;
            string[] result = null;

            try
            {
                bld = new BucketListData(Utilities.GetDbSetting());

                string decodedBucketListItems = Utilities.DecodeClientBase64String(encodedBucketListItems);
                string decodedToken = Utilities.DecodeClientBase64String(encodedToken);
                string decodedUserName = Utilities.DecodeClientBase64String(encodedUser);

                decodedBucketListItems = decodedBucketListItems.Trim(',');
                decodedBucketListItems = decodedBucketListItems.Trim(';');
                string[] items = decodedBucketListItems.Split(',');

                //HACK - needed a demo user quick and I didn't want any changes
                if (!string.IsNullOrEmpty(decodedUserName) && decodedUserName.Equals("demouser"))
                {
                    result = Utilities.GetValidTokenResponse();
                }
                else
                {
                    //LogParameters();

                    if (ProcessToken(decodedUserName, decodedToken))
                    {
                        bld.UpsertBucketListItem(items);
                        result = Utilities.GetValidTokenResponse();
                    }
                    else
                        result = Utilities.GetInValidTokenResponse();
                }
            }
            catch (Exception e)
            {
                bld.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return result;
        }

        public string[] UpsertBucketListItemV2(string encodedBucketListItems, string encodedUser, string encodedToken)
        {
            IBucketListData bld = null;
            string[] result = null;

            try
            {
                bld = new BucketListData(Utilities.GetDbSetting());

                string decodedBucketListItems = Utilities.DecodeClientBase64String(encodedBucketListItems);
                string decodedToken = Utilities.DecodeClientBase64String(encodedToken);
                string decodedUserName = Utilities.DecodeClientBase64String(encodedUser);

                decodedBucketListItems = decodedBucketListItems.Trim(',');
                decodedBucketListItems = decodedBucketListItems.Trim(';');
                string[] items = decodedBucketListItems.Split(',');

                //HACK - needed a demo user quick and I didn't want any changes
                if (!string.IsNullOrEmpty(decodedUserName) && decodedUserName.Equals("demouser"))
                {
                    result = Utilities.GetValidTokenResponse();
                }
                else
                {
                    //LogParameters();

                    if (ProcessToken(decodedUserName, decodedToken))
                    {
                        bld.UpsertBucketListItemV2(items);
                        result = Utilities.GetValidTokenResponse();
                    }
                    else
                        result = Utilities.GetInValidTokenResponse();
                }
            }
            catch (Exception e)
            {
                bld.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return result;
        }

        public string[] DeleteBucketListItem(int bucketListDbId, string encodedUser, string encodedToken)
        {
            IBucketListData bld = null;
            string[] result = null;

            try
            {
                bld = new BucketListData(Utilities.GetDbSetting());

                string decodedToken = Utilities.DecodeClientBase64String(encodedToken);
                string decodedUserName = Utilities.DecodeClientBase64String(encodedUser);

                //HACK - needed a demo user quick and I didn't want any changes
                if (!string.IsNullOrEmpty(decodedUserName) && decodedUserName.Equals("demouser"))
                {
                    result = Utilities.GetValidTokenResponse();
                }
                else
                {
                    //LogParameters();

                    if (ProcessToken(decodedUserName, decodedToken))
                    {
                        bld.DeleteBucketListItem(bucketListDbId);
                        result = Utilities.GetValidTokenResponse();
                    }
                    else
                        result = Utilities.GetInValidTokenResponse();
                }
            }
            catch (Exception e)
            {
                bld.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return result;
        }

        public string[] GetDashboard()
        {
            IBucketListData bld = null;
            string[] results = null;

            try
            {
                bld = new BucketListData(Utilities.GetDbSetting());
                results = bld.GetDashboard();
            }
            catch (Exception e)
            {
                bld.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return results;
        }

        #region Private Methods

        private string VerifyUser(string userName, string password, IMemberShipData msd)
        {
            string token = string.Empty;
            User u = msd.GetUser(userName);

            if (u != null)
            {
                Password p = new Password();

                bool goodUser = p.UserExists(u, password);

                if (goodUser)
                    token = Utilities.GenerateToken();
            }

            return token;
        }
        private bool ProcessToken(string userName, string token)
        {
            bool goodToken = false;
            IMemberShipData msd = new Data(Utilities.GetDbSetting());
            User u = msd.GetUser(userName);

            //HACK for android
            token = token.Replace("\"", "");

            if (u != null
                    && !string.IsNullOrEmpty(u.Token)
                        && !string.IsNullOrEmpty(token)
                            && u.Token.Equals(token))
            {
                byte[] data = Convert.FromBase64String(token);
                DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
                DateTime now = DateTime.UtcNow.AddHours(-2);
                if (when >= now)
                {
                    goodToken = true;
                }
            }

            return goodToken;
        }
        private void LogParameters()
        {
            throw new NotImplementedException();

            //DeleteBucketListItem(args) -----------------------------------------------------------------------
            //IList<string> parameters = new List<string>();
            //parameters.Add(bucketListDbId.ToString());
            //CommonCode.Log(null, bld, "DeleteBucketListItem", parameters);

            //GetBucketListItems(args) -----------------------------------------------------------------------
            //IList<string> parameters = new List<string>();
            //parameters.Add(decodedUserName);
            //parameters.Add(decodedSortString);
            //CommonCode.Log(null, bld, "GetBucketListItems", parameters);

            //ProcessUser(args) -----------------------------------------------------------------------
            //IList<string> parameters = new List<string>();
            //parameters.Add(userName);
            //CommonCode.Log(msd, null, "ProcessUser", parameters);

            //UpsertBucketListItem(args) -----------------------------------------------------------------------
            //IList<string> parameters = new List<string>();
            //parameters.Add(decodedUser);
            //parameters.Add(decodedEmail);
            //CommonCode.Log(msd, null, "ProcessUserRegistration", parameters);

            //? -----------------------------------------------------------------------
            //IList<string> parameters = new List<string>();
            //foreach (string bucketListItem in items)
            //    parameters.Add(bucketListItem);
            //CommonCode.Log(null, bld, "UpsertBucketListItem", parameters);

        }

        #endregion
    }
}
