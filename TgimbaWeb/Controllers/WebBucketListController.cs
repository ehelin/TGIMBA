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
    }
}