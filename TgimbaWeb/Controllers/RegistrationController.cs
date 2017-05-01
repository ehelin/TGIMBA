using System;
using System.Collections.Generic;
using System.Web.Http;
using CommonServiceCode;

namespace TgimbaRestService.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Account")]
    public class RegistrationController : BaseController
    {
        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;

        public RegistrationController() : base() {}

        // POST api/Registration
        [HttpPost]
        public bool Post([FromBody]Dictionary<string, string> values)
        {
            bool userAdded = false;

            if (values != null && values.Count == 3)
                userAdded = client.ProcessUserRegistration(values["encodedUser"], values["encodedEmail"], values["encodedPass"]);

            return userAdded;
        }

        //HACK Alert! - Meant for the Android client which didn't place nice with .net posts when testing
        // GET api/Registration
        [HttpGet]
        public bool Get(string encodedUser, string encodedEmail, string encodedPass)
        {
            bool userAdded = false;

            if (!string.IsNullOrEmpty(encodedUser) 
                    && !string.IsNullOrEmpty(encodedEmail)  
                        && !string.IsNullOrEmpty(encodedPass))
                userAdded = client.ProcessUserRegistration(encodedUser, encodedEmail, encodedPass);

            return userAdded;
        }
    }
}
