using System.Web.Mvc;
using TgimbaRestService.Models;

namespace TgimbaRestService.Controllers
{
    public class WebRequestController : WebBaseController
    {
        public ActionResult RoadMap()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult WelcomePage()
        {
            BaseModel model = new BaseModel();
            SetMobileFlag();

            model.IsMobile = IsMobile();

            //return RedirectToAction("Desktop", "BucketList");
            ////IBucketListData bld = new BucketListData(Utility.GetAppSetting(BucketListConstants.DB_CONN));
            //IList<string> parameters = new List<string>();
            //parameters.Add("Making Call");
            //CommonCode.Log(null, bld, "RequestController.WelcomePage()", parameters);

            //CommonCode.LogBrowser(GetBrowserData());

            return View(model);
        }
        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        public ActionResult DirectRequest()
        {
            SetMobileFlag();  //TODO - redundant with call in WelcomePage()

            if (IsMobile())
                return RedirectToAction("Mobile", "WebBucketList", new { demoUserLogin = false });
            else
                return RedirectToAction("Desktop", "WebBucketList", new { demoUserLogin = false });
        }
        public ActionResult DirectRequestDemoUser()
        {
            SetMobileFlag();

            if (IsMobile())
                return RedirectToAction("Mobile", "WebBucketList", new { demoUserLogin = true });
            else
                return RedirectToAction("Desktop", "WebBucketList", new { demoUserLogin = true });
        }
    }
}