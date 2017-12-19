using System;
using System.Web.Http;
using CommonServiceCode;
using System.Collections.Generic;

namespace TgimbaRestService.Controllers
{ 
    //[Authorize]
    //[RoutePrefix("api/BucketList")]
    public class BucketListController : BaseController
    {
        public BucketListController() : base() {}

        //GET api/BucketList
        [HttpGet]
        public string[] Get(string encodedUserName, string encodedSortString, string encodedToken)
        {
            string[] result = null;
            
            if (!string.IsNullOrEmpty(encodedUserName) && !string.IsNullOrEmpty(encodedToken))
                result = client.GetBucketListItems(encodedUserName, encodedSortString, encodedToken);
            
            return result;
        }

        //GET api/BucketList
        [HttpGet]
        [Route("api/GetDashboard")]
        public string[] GetDashboard()
        {
            string[] results = client.GetDashboard();

            return results;
        }

        //GET api/BucketList
        [HttpGet]
        [Route("api/getDaily")]
        public string[] GetDaily()
        {
            string[] results = client.GetDashboard();

            return results;
        }

        //HACK Alert! - Meant for the Android client which didn't place nice with .net posts when testing
        [HttpGet]
        [Route("api/BucketListUpsert")]
        public string[] GetUpsert(string encodedBucketListItems, string encodedUser, string encodedToken)
        {
            string[] result = null;

            if (!string.IsNullOrEmpty(encodedBucketListItems) 
                    && !string.IsNullOrEmpty(encodedUser)
                        && !string.IsNullOrEmpty(encodedToken))
                result = client.UpsertBucketListItem(encodedBucketListItems, encodedUser, encodedToken);

            return result;
        }

        [HttpPost]
        [Route("api/BucketListUpsert")]
        public string[] PostUpsert([FromBody]Dictionary<string, string> values)
        {
            string[] result = null;

            if (values != null && values.Count == 3)
                result = client.UpsertBucketListItem(values["encodedBucketListItems"], values["encodedUser"], values["encodedToken"]);

            return result;
        }
        
        //HACK Alert! - Meant for the Android client which didn't place nice with .net posts when testing    
        [HttpGet]
        [Route("api/BucketListDelete")]
        public string[] GetDelete(string dbIdStr, string encodedUser, string encodedToken)
        {
            string[] result = null;

            if (!string.IsNullOrEmpty(dbIdStr)
                    && !string.IsNullOrEmpty(encodedUser)
                        && !string.IsNullOrEmpty(encodedToken))
            {
                if (!string.IsNullOrEmpty(dbIdStr))
                {
                    int dbId = 0;
                    Int32.TryParse(dbIdStr, out dbId);

                    if (dbId > 0)
                    {
                        result = client.DeleteBucketListItem(dbId, encodedUser, encodedToken);
                    }
                }
            }

            return result;
        }

        [HttpPost]
        [Route("api/BucketListDelete")]
        public string[] PostDelete([FromBody]Dictionary<string, string> values)
        {
            string[] result = null;

            if (values != null && values.Count == 3)
            {
                string dbIdStr = values["bucketListDbId"];

                if (!string.IsNullOrEmpty(dbIdStr))
                {
                    int dbId = 0;
                    Int32.TryParse(dbIdStr, out dbId);

                    if (dbId > 0)
                    {
                        result = client.DeleteBucketListItem(dbId, values["encodedUser"], values["encodedToken"]);
                    }
                }
            }

            return result;
        }
    }
}
