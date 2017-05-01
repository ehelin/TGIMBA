using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MemberShip;
using DataProvider.Interfaces;
using DataProvider;
using Shared.Dto;
using Shared;
using MobileApplication.Shared;

namespace MobileWebsite.Controllers
{
    public class CommonCode 
    {
        //TODO - unncomment before official release
        public static void LogBrowser(BrowserData bd)
        {
            IBucketListData bld = new BucketListData(Utility.GetAppSetting(BucketListConstants.DB_CONN));
            int browserLogId = bld.LogBrowser(bd);

            foreach (System.Collections.DictionaryEntry kvp in bd.Capabilities)
            {
                bld.LogBrowserCapability(browserLogId, kvp.Key.ToString(), kvp.Value.ToString());
            }
        }
        public static void Log(IMemberShipData msd, IBucketListData bld, string method, IList<string> parameters)
        {
            if (msd != null)
            {
                string msg = method + " - ";

                foreach (string parameter in parameters)
                    msg += parameter + ", ";

                msg = msg.Trim(' ');
                msg = msg.Trim(',');

                msd.LogMsg(msg);
            }
            else if (bld != null)
            {
                string msg = method + " - ";

                foreach (string parameter in parameters)
                    msg += parameter + ", ";

                msg = msg.Trim(' ');
                msg = msg.Trim(',');

                bld.LogMsg(msg);
            }
        }
    }
}