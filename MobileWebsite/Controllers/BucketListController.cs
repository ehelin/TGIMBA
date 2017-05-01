using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileApplication.Shared;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;
using System.Web.Routing;

using MobileWebsite.Controllers;
using DataProvider.Interfaces;
using DataProvider;

namespace MobileApplication.Controllers
{
    //TODO - make all string literals constants
    public class BucketListController : BaseController
    {
        [HttpGet]
        public ActionResult Mobile()
        {
            IBucketListData bld = new BucketListData(Utility.GetAppSetting(BucketListConstants.DB_CONN));
            IList<string> parameters = new List<string>();
            parameters.Add("Making Call");
            CommonCode.Log(null, bld, "BucketListController.Mobile()", parameters);

            return View();
        }
        [HttpGet]
        public ActionResult Desktop()
        {
            IBucketListData bld = new BucketListData(Utility.GetAppSetting(BucketListConstants.DB_CONN));
            IList<string> parameters = new List<string>();
            parameters.Add("Making Call");
            CommonCode.Log(null, bld, "BucketListController.Desktop()", parameters);

            return View();
        }
    }
}
