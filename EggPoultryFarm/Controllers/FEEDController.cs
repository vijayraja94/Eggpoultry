using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using System.Threading;
using System.Data;
using EggPoultryFarm.Models;

namespace EggPoultryFarm.Controllers
{
    public class FEEDController : Controller
    {
        // GET: FEED
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FEED(string Month, string DATE, string Year, string FEEDQUALITY, string FEEDWEIGHT, string FEEDPRICE)
        {
           

            //System.Text.StringBuilder POULTRY = new System.Text.StringBuilder();
            //POULTRY.Append("<Response>");
            //POULTRY.Append("<FEEDQUALITY>" + FEEDQUALITY + "</FEEDQUALITY>");
            //POULTRY.Append("<FEEDWEIGHT>" + FEEDWEIGHT + "</FEEDWEIGHT>");
            //POULTRY.Append("<FEEDPRICE>" + FEEDPRICE + "</FEEDPRICE>");          
            //POULTRY.Append("<DATE>" + DATE + "/" + Month + "/" + Year + "</DATE>");            
            //POULTRY.Append("</Response>");


            //string RESPONSE = POULTRY.ToString();
            //string asdasd = System.IO.File.ReadAllText(@"C:\Users\vijay\OneDrive\Desktop\New folder (2)\FEEDSTOCK.XML");

            //string datecontain = DATE + "/" + Month + "/" + Year;
            //if (asdasd.Contains(datecontain))
            //{
            //    string strStatus1 = string.Empty;
            //    string strMessage1 = string.Empty;
            //    strStatus1 = "00";
            //    strMessage1 = "Duplicate entry.Kindly check date";
            //    return Json(new { status = strStatus1, Message = strMessage1 });
            //}

            //asdasd = asdasd.Replace("<kolipanai>", "<kolipanai>" + RESPONSE);
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(asdasd);            
            //doc.PreserveWhitespace = true;

            //string strStatus = string.Empty;
            //string strMessage = string.Empty;
            //try
            //{                //doc.Save("C:\\Users\\vijay\\OneDrive\\Desktop\\New folder (2)\\" + DateTime.Now.ToString("ddMMyyyysss") + ".XML");
            //    doc.Save("C:\\Users\\vijay\\OneDrive\\Desktop\\New folder (2)\\FEEDSTOCK.XML");
            //    Thread.Sleep(1000);
            //    strStatus = "01";
            //    strMessage = "success";
            //}
            //catch (Exception)
            //{

            //    strStatus = "00";
            //    strMessage = "Failure";
            //    return Json(new { status = strStatus, Message = strMessage });
            //}


            return View();
        }
    }
}
