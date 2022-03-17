using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EggPoultryFarm.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
       
        public ActionResult Login()
        {

            
            return View();
        }
       
        public  ActionResult Verfiy(string strUserName,string strPassword)
        {
            //string userSname = data1;
            //string userSSSname = data2;
            string strStatus = string.Empty;
            string strMessage = string.Empty;
            if (strUserName == "vijay"&& strPassword == "vijay1")
            {
                strStatus = "01";
                strMessage = "success";
                
            }
            else
            {
                strStatus = "00";
                strMessage = "Failure";
            }
          //  return View();
            return Json(new { status = strStatus,Message = strMessage});
        }

    }
}