using System;
using System.Windows;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

namespace TgimbaWpfClient
{
    public class TgimbaApi
    {
        private string host = "https://www.tgimba.com/";

        public TgimbaApi() {}

        public string ProcessUser(string user, string pass)
        {
            string token = string.Empty;

            try
            {
                string base64EncodedUser = Utilities.EncodeClientBase64String(user);
                string base64EncodedPass = Utilities.EncodeClientBase64String(pass);
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("encodedUser", base64EncodedUser);
                values.Add("encodedPass", base64EncodedPass);
                var content = new StringContent(JsonConvert.SerializeObject(values), System.Text.Encoding.UTF8, "application/json");

                string unserializedResponse = Post("api/account", content).Result;
                token = JsonConvert.DeserializeObject<string>(unserializedResponse);
            }
            catch (Exception e)
            {
                // TODO handle this error better
                MessageBox.Show("Api Call Error -> ProcessUser()", "Api Error", MessageBoxButton.OK);
            }

            return token;
        }
        public bool ProcessUserRegistration(string user, string email, string password)
        {
            bool userAdded = false;

            try
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("encodedUser", Utilities.EncodeClientBase64String(user));
                values.Add("encodedPass", Utilities.EncodeClientBase64String(password));
                values.Add("encodedEmail", Utilities.EncodeClientBase64String(email));
                var content = new StringContent(JsonConvert.SerializeObject(values), System.Text.Encoding.UTF8, "application/json");

                string unserializedResponse = Post("api/Registration", content).Result;
                userAdded = Convert.ToBoolean(unserializedResponse);
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
            string[] results = null;

            try
            {
                StringBuilder queryString = new StringBuilder();
                queryString.Append("?");
                queryString.Append("encodedUserName=" + Utilities.EncodeClientBase64String(user));
                queryString.Append("&encodedSortString=" + Utilities.EncodeClientBase64String(sortString));
                queryString.Append("&encodedToken=" + Utilities.EncodeClientBase64String(token));
                
                string unserializedResponse = Get("/api/BucketList" + queryString.ToString()).Result;
                results = unserializedResponse.Split(new string[] { "\",\"" }, StringSplitOptions.None);
            }
            catch (Exception e)
            {
                // TODO handle this error better
                MessageBox.Show("Api Call Error -> GetBucketListItems()", "Api Error", MessageBoxButton.OK);
            }

            return results;
        }
        public string[] UpsertBucketListItem(string bucketListItem, string user, string token)
        {
            string[] results = null;

            try
            {
                bucketListItem = Utilities.RemoveCharacaters(bucketListItem);
                Dictionary <string, string> values = new Dictionary<string, string>();
                values.Add("encodedBucketListItems", Utilities.EncodeClientBase64String(bucketListItem));
                values.Add("encodedUser", Utilities.EncodeClientBase64String(user));
                values.Add("encodedToken", Utilities.EncodeClientBase64String(token));
                var content = new StringContent(JsonConvert.SerializeObject(values), System.Text.Encoding.UTF8, "application/json");

                string unserializedResponse = Post("api/BucketListUpsert", content).Result;
                results = unserializedResponse.Split(',');
                results = JsonConvert.DeserializeObject<string[]>(results[0]);
            }
            catch (Exception e)
            {
                // TODO handle this error better
                MessageBox.Show("Api Call Error -> UpsertBucketListItem()", "Api Error", MessageBoxButton.OK);
            }

            return results;
        }
        public string[] DeleteBucketListItem(string bucketListDbId, string user, string token)
        {
            string[] results = null;

            try
            {
                string base64EncodedUser = Utilities.EncodeClientBase64String(user);
                string base64EncodedToken = Utilities.EncodeClientBase64String(token);

                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("bucketListDbId", bucketListDbId);
                values.Add("encodedUser", Utilities.EncodeClientBase64String(user));
                values.Add("encodedToken", Utilities.EncodeClientBase64String(token));
                var content = new StringContent(JsonConvert.SerializeObject(values), System.Text.Encoding.UTF8, "application/json");

                string unserializedResponse = Post("api/BucketListDelete", content).Result;
                results = unserializedResponse.Split(',');
                results = JsonConvert.DeserializeObject<string[]>(results[0]);
            }
            catch (Exception e)
            {
                // TODO handle this error better
                MessageBox.Show("Api Call Error -> DeleteBucketListItem()", "Api Error", MessageBoxButton.OK);
            }

            return results;
        }
        private async Task<string> Post(string subUrl, StringContent body)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = null;
            string result = string.Empty;

            response = await client.PostAsync(host + subUrl, body).ConfigureAwait(false);
            result = await response.Content.ReadAsStringAsync();

            return result;
        }
        private async Task<string> Get(string subUrl)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = null;
            string result = string.Empty;

            response = await client.GetAsync(host + subUrl).ConfigureAwait(false);
            result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
