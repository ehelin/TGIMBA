using System;
using System.Windows;

namespace TgimbaWpfClient
{
    public class TgimbaApi
    {
        public TgimbaApi() {}
        public string ProcessUser(string user, string pass)
        {
            string result = string.Empty;

            try
            {
                string base64EncodedUser = Utilities.EncodeClientBase64String(user);
                string base64EncodedPass = Utilities.EncodeClientBase64String(pass);


                
                result = "";
            }
            catch (Exception e)
            {
                // TODO handle this error better
                MessageBox.Show("Api Call Error -> ProcessUser()", "Api Error", MessageBoxButton.OK);
            }

            return result;
        }

        public bool ProcessUserRegistration(string user, string email, string password)
        {
            bool userAdded = false;

            try
            {
                string base64EncodedUser = Utilities.EncodeClientBase64String(user);
                string base64EncodedEmail = Utilities.EncodeClientBase64String(email);
                string base64EncodedPass = Utilities.EncodeClientBase64String(password);

                userAdded = false;
            }
            catch (Exception e)
            {
                // TODO handle this error better
                MessageBox.Show("Api Call Error -> ProcessUserRegistration()", "Api Error", MessageBoxButton.OK);
            }

            return userAdded;
        }

        public string[] GetBucketListItems(string user, string sortString, string token)
        {
            string[] result = null;

            try
            {
                string base64EncodedUser = Utilities.EncodeClientBase64String(user);
                string base64EncodedSortString = Utilities.EncodeClientBase64String(sortString);
                string base64EncodedToken = Utilities.EncodeClientBase64String(token);

                result = null;
            }
            catch (Exception e)
            {
                // TODO handle this error better
                MessageBox.Show("Api Call Error -> GetBucketListItems()", "Api Error", MessageBoxButton.OK);
            }

            return result;
        }
        
        public string[] UpsertBucketListItem(string bucketListItem, string user, string token)
        {
            string[] result = null;

            try
            {
                string base64EncodedBucketListItem = Utilities.EncodeClientBase64String(bucketListItem);
                string base64EncodedUser = Utilities.EncodeClientBase64String(user);
                string base64EncodedToken = Utilities.EncodeClientBase64String(token);

                result = null;
            }
            catch (Exception e)
            {
                // TODO handle this error better
                MessageBox.Show("Api Call Error -> UpsertBucketListItem()", "Api Error", MessageBoxButton.OK);
            }

            return result;
        }
        
        public string[] DeleteBucketListItem(int bucketListDbId, string user, string token)
        {
            string[] result = null;

            try
            {
                string base64EncodedUser = Utilities.EncodeClientBase64String(user);
                string base64EncodedToken = Utilities.EncodeClientBase64String(token);

                result = null;
            }
            catch (Exception e)
            {
                // TODO handle this error better
                MessageBox.Show("Api Call Error -> DeleteBucketListItem()", "Api Error", MessageBoxButton.OK);
            }

            return result;
        }
    }
}
