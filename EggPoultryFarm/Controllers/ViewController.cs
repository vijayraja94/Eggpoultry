using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Xml;
using System.Data;
using EggPoultryFarm.Models;

namespace EggPoultryFarm.Controllers
{
    public class ViewController : Controller
    {
        // GET: View
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult view()
        {
            string asdasd = System.IO.File.ReadAllText(@"C:\Users\vijay\OneDrive\Desktop\New folder (2)\kolipanai.XML");

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(asdasd);
            XmlDocument xmlDoc = new XmlDocument();
            //Code to load xml into xmlDocument.
            XmlReader xmlReader = new XmlNodeReader(doc);
            DataSet ds = new DataSet();
            ds.ReadXml(xmlReader);


            List<poultry> poultrylist = new List<poultry>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                poultrylist.Add(new poultry
                {
                    CHICKENCOUNT = ds.Tables[0].Rows[i]["CHICKENCOUNT"].ToString(),
                    EGGCOUNT = ds.Tables[0].Rows[i]["EGGCOUNT"].ToString(),
                    EGGSIZE = ds.Tables[0].Rows[i]["EGGSIZE"].ToString(),
                    SET = ds.Tables[0].Rows[i]["SET"].ToString(),
                    DATE = ds.Tables[0].Rows[i]["DATE"].ToString(),
                    FEEDWEIGHT = ds.Tables[0].Rows[i]["FEEDWEIGHT"].ToString()
                });

            }


            ViewBag.vijay = poultrylist;
            return View();
        }
    }
}