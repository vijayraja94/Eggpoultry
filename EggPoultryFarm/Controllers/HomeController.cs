using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Threading;
using System.Data;
using EggPoultryFarm.Models;
using System.Threading.Tasks;
//using System.IO.Stream outStream;
namespace EggPoultryFarm.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Verfiy(string CHICKENCOUNT, string EGGCOUNT, string EGGSIZE, string EGGRATE, string SET, string Year, string Month, string DATE, string FEEDWEIGHT)
        {
            if (string.IsNullOrEmpty(CHICKENCOUNT) || string.IsNullOrEmpty(EGGCOUNT) || string.IsNullOrEmpty(EGGSIZE)|| string.IsNullOrEmpty(EGGRATE)
                || string.IsNullOrEmpty(SET) || string.IsNullOrEmpty(DATE) || string.IsNullOrEmpty(Month) || string.IsNullOrEmpty(Year)|| string.IsNullOrEmpty(FEEDWEIGHT))
            {
                string strStatus1 = string.Empty;
                string strMessage1 = string.Empty;
                strStatus1 = "00";
                strMessage1 = "Kindly check inputdata..";
                return Json(new { status = strStatus1, Message = strMessage1 });
            }

            System.Text.StringBuilder POULTRY = new System.Text.StringBuilder();
            POULTRY.Append("<Response>");
            POULTRY.Append("<CHICKENCOUNT>" + CHICKENCOUNT + "</CHICKENCOUNT>");
            POULTRY.Append("<EGGCOUNT>" + EGGCOUNT + "</EGGCOUNT>");
            POULTRY.Append("<EGGCOUNT>" + EGGCOUNT + "</EGGCOUNT>");
            POULTRY.Append("<EGGSIZE>" + EGGSIZE + "</EGGSIZE>");
            POULTRY.Append("<SET>" + SET + "</SET>");
            POULTRY.Append("<DATE>" + DATE + "/" + Month + "/" + Year + "</DATE>");
            POULTRY.Append("<FEEDWEIGHT>" + FEEDWEIGHT + "</FEEDWEIGHT>");
            POULTRY.Append("</Response>");



            string RESPONSE = POULTRY.ToString();
            string asdasd = System.IO.File.ReadAllText(@"C:\Users\vijay\OneDrive\Desktop\New folder (2)\kolipanai.XML");

            string datecontain = DATE + "/" + Month + "/" + Year;
            if (asdasd.Contains(datecontain))
            {
                string strStatus1 = string.Empty;
                string strMessage1 = string.Empty;
                strStatus1 = "00";
                strMessage1 = "Duplicate entry.Kindly check date";
                return Json(new { status = strStatus1, Message = strMessage1 });
            }

            asdasd = asdasd.Replace("<kolipanai>", "<kolipanai>" + RESPONSE);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(asdasd);


            //XmlSerializer sr = new XmlSerializer();
            //TextWriter writer = new StreamWriter(filename);
            //sr.Serialize(writer);
            //writer.Close();

            // Add a price element.
            //XmlElement newElem = doc.CreateElement("price");
            //newElem.InnerText = "10.95";
            //doc.DocumentElement.AppendChild(newElem);

            // Save the document to a file. White space is
            // preserved (no white space).
            doc.PreserveWhitespace = true;

            string strStatus = string.Empty;
            string strMessage = string.Empty;
            try
            {



                //doc.Save("C:\\Users\\vijay\\OneDrive\\Desktop\\New folder (2)\\" + DateTime.Now.ToString("ddMMyyyysss") + ".XML");
                doc.Save("C:\\Users\\vijay\\OneDrive\\Desktop\\New folder (2)\\kolipanai.XML");
                Thread.Sleep(1000);
                strStatus = "01";
                strMessage = "success";
            }
            catch (Exception)
            {

                strStatus = "00";
                strMessage = "Failure";
                return Json(new { status = strStatus, Message = strMessage });
            }

            string asdasd1 = System.IO.File.ReadAllText(@"C:\Users\vijay\OneDrive\Desktop\New folder (2)\kolipanai.XML");

            XmlDocument doc1 = new XmlDocument();
            doc1.LoadXml(asdasd1);
            XmlDocument xmlDoc = new XmlDocument();
            //Code to load xml into xmlDocument.
            XmlReader xmlReader1 = new XmlNodeReader(doc1);
            DataSet ds1 = new DataSet();
            ds1.ReadXml(xmlReader1);

            decimal totaleggcount = 0;
            decimal totalCHICKENCOUNT = 0;
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                totaleggcount =+ Convert.ToDecimal(ds1.Tables[0].Rows[i]["EGGCOUNT"]);
                totalCHICKENCOUNT =+ Convert.ToDecimal(ds1.Tables[0].Rows[i]["CHICKENCOUNT"]);
            }

            decimal totalpercentage = (totaleggcount / totalCHICKENCOUNT) * 100;


            List<poultry12> poultrylist = new List<poultry12>();
            for (int i = 0; i < 1; i++)
            {

                poultrylist.Add(new poultry12
                {
                    totalpercentage = Math.Ceiling(totalpercentage).ToString(),
                  
                   
                });

            }


         //   ViewBag.vijay1 = poultrylist;
            // String.Format("{0:0.00}", totalpercentage);

            //ViewBag.totalpercentage = Math.Ceiling(totalpercentage).ToString(); 
            string strResult = Math.Ceiling(totalpercentage).ToString();


            //return Json(new { status = strStatus, Message = strMessage });
            return Json(new { Result = strResult });
        }
    }
}