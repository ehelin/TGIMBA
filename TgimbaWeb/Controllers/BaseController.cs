using System.Web.Http;
using System;
using CommonServiceCode;

namespace TgimbaRestService.Controllers
{
    public class BaseController : ApiController
    {
        protected TgimbaService client = null;

        public BaseController()
        {
            client = new TgimbaService();
        }     
    }
}