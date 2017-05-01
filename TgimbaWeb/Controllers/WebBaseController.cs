using System;
using System.Web.Mvc;

namespace TgimbaRestService.Controllers
{
    public class WebBaseController : Controller
    {
        protected void SetMobileFlag()
        {
            if (HttpContext != null
                    && HttpContext.Request != null
                        && HttpContext.Request.Browser != null)
            {
                //start test code ------------------
                Session[SessionConstants.IS_MOBILE] = HttpContext.Request.Browser.IsMobileDevice;
                //Session[SessionConstants.IS_MOBILE] = true;
                //end test code ------------------
            }
            else
                throw new Exception(Error.ERR_000001 + "-" + ErrorMsg.ERR_MSG_000001);
        }
        protected bool IsMobile()
        {
            if (Session[SessionConstants.IS_MOBILE] != null)
                return Convert.ToBoolean(Session[SessionConstants.IS_MOBILE]);
            else
                return false;
        }
    }
}