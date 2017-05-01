using System;
using System.Collections.Generic;
using System.Web.Http;
using CommonServiceCode;

namespace TgimbaRestService.Controllers
{ 
    //[Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : BaseController
    {
        public AccountController() : base() {}

        // POST api/account
        [HttpPost]
        public string Post([FromBody]Dictionary<string, string> values)
        {
            string token = string.Empty;

            if (values != null && values.Count == 2)
                token = client.ProcessUser(values["encodedUser"], values["encodedPass"]);

            return token;
        }

        //HACK Alert! - Meant for the Android client which didn't place nice with .net posts when testing
        // GET api/account
        [HttpGet]
        public string Get(string encodedUser, string encodedPass)
        {
            string token = string.Empty;

            if (!string.IsNullOrEmpty(encodedUser) && !string.IsNullOrEmpty(encodedPass))
                token = client.ProcessUser(encodedUser, encodedPass);

            return token;
        }        
    }
}
