using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileApplication.Shared;

using MobileWebsite.Controllers;
using DataProvider.Interfaces;
using DataProvider;

namespace MobileApplication.Controllers
{
    //TODO - make all string literals constants
    public class RequestController : BaseController
    {
        public ActionResult WelcomePage()
        {
            IBucketListData bld = new BucketListData(Utility.GetAppSetting(BucketListConstants.DB_CONN));
            IList<string> parameters = new List<string>();
            parameters.Add("Making Call");
            CommonCode.Log(null, bld, "RequestController.WelcomePage()", parameters);

            CommonCode.LogBrowser(GetBrowserData());

            return View();
        }
        public ActionResult DirectRequest()
        {
            SetMobileFlag();

            if (IsMobile())
                return RedirectToAction("Mobile", "BucketList");
            else
                return RedirectToAction("Desktop", "BucketList");
        }      
    }
}
