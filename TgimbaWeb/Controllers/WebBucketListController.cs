using System.Web.Mvc;
using TgimbaRestService.Models;

namespace TgimbaRestService.Controllers
{
    public class WebBucketListController : WebBaseController
    {
        [HttpGet]
        public ActionResult Mobile(bool demoUserLogin)
        {
            BaseModel model = new BaseModel();
            model.LoginAsDemoUser = demoUserLogin;

            return View(model);
        }

        [HttpGet]
        public ActionResult Desktop(bool demoUserLogin)
        {
            BaseModel model = new BaseModel();
            model.LoginAsDemoUser = demoUserLogin;

            return View(model);
        }

        //[HttpGet]
        //public ActionResult Mobile()
        //{
        //    //TODO - add logging (if needed)
        //    //IBucketListData bld = new BucketListData(Utilities.GetDbSetting());
        //    //IList<string> parameters = new List<string>();
        //    //parameters.Add("Making Call");
        //    //CommonCode.Log(null, bld, "BucketListController.Mobile()", parameters);

        //    return View();
        //}
        //[HttpGet]
        //public ActionResult Desktop()
        //{
        //    //TODO - add logging (if needed)
        //    //IBucketListData bld = new BucketListData(Utilities.GetDbSetting());
        //    //IList<string> parameters = new List<string>();
        //    //parameters.Add("Making Call");
        //    //CommonCode.Log(null, bld, "BucketListController.Desktop()", parameters);

        //    return View();
        //}
    }
}