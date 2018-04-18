using System;
﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using TimeSheetEntryForManagers.Models;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Configuration;
using System.Net;

namespace TimeSheetEntryForManagers.Controllers
{
	public partial class GridController : Controller
    {
		public ActionResult Employee_Read([DataSourceRequest]DataSourceRequest request)
		{
            var list = GetEmployees("dpelfrey", 225);

            var q = list
                .GroupBy(c => c.EmployeeName )
                .Select(g => new
                {
                    EmployeeName = (g.Key),
                
                    Vacation =g.Where(c=>c.TMItemCdeID ==1022 && c.PVValidItem.Equals('Y')).Sum(c =>c.tmhrs),
                    Holiday =g.Where(c =>c.TMItemCdeID == 1016 && c.PVValidItem.Equals('Y')).Sum(c=>c.tmhrs),
                    RegularHrs = g.Where(c => c.TMItemCdeID == 7 && c.PVValidItem.Equals('Y') ).Sum(c =>c.tmhrs),
                    OTHrs = g.Where(c => c.TMItemCdeID == 14 && c.PVValidItem.Equals('Y')).Sum(c => c.tmhrs),
                    Personal = g.Where(c => c.TMItemCdeID == 1015 && c.PVValidItem.Equals('Y')).Sum(c => c.tmhrs),
                    Training = g.Where(c=> c.TMItemCdeID == 1017 && c.PVValidItem.Equals('Y')).Sum(c =>c.tmhrs),
                    ThankYouDeduction = g.Where(c => c.TMItemCdeID == 1020 && c.PVValidItem.Equals('Y')).Sum(c => c.tmamt), 
                    ExcusedUnpaid = g.Where(c => c.TMItemCdeID == 1018 && c.PVValidItem.Equals('Y')).Sum(c => c.tmhrs),
                   Unexcused = g.Where(c =>c.TMItemCdeID == 1019 && c.PVValidItem.Equals('Y')).Sum(c =>c.tmhrs),
                  LeadDeduction = g.Where(c => c.TMItemCdeID == 1024 && c.PVValidItem.Equals('Y')).Sum(c =>c.tmamt), 
                   PRQC = g.Where(c=>c.TMItemCdeID == 1021 && c.PVValidItem.Equals('Y')).Sum(c => c.tmhrs)
                });

           // var t = list
             //   .GroupBy

            var result =q.ToList();
            //var result = Enumerable.Range(0, 50).Select(i => new EmployeeTimeEntryModel
            //{
            //    EmployeeID = q.
            //    EmployeeName = i.ToString()
            //    //OrderID = i,
            //    //Freight = i * 10,
            //    //OrderDate = DateTime.Now.AddDays(i),
            //    //ShipName = "ShipName " + i,E
            //    //ShipCity = "ShipCity " + i
            //});

            return Json(result.ToDataSourceResult(request));
		}
        private static List<TimeSheetEmployee> GetEmployees(string manager , int payweek)
        {

            List<TimeSheetEmployee> inv = new List<TimeSheetEmployee>();

            Byte[] documentBytes;  //holds the post body information in bytes

          //  http://localhost:54188/api/Values/GetTimeSheetManagerPayweek/dpelfrey/225
           // string uri = "https://localhost:54188/api/Values/GetTimeSheetManagerPayweek?manager=" + manager + "&payweek=" + payweek;
            string uri = "http://localhost:54188/api/Values/GetTimeSheetManagerPayweek/" + manager + "/" + payweek;


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            string authInfo = ConfigurationManager.AppSettings["apilgusrin"] + ":" + ConfigurationManager.AppSettings["apilgusrps"];
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Headers["Authorization"] = "Basic " + authInfo;
            request.AllowAutoRedirect = true;
            request.PreAuthenticate = true;

            request.AutomaticDecompression = DecompressionMethods.GZip;


            request.Method = "GET";
            request.ContentType = "application/json";


            string body = "";


            System.Text.ASCIIEncoding obj = new System.Text.ASCIIEncoding();
            documentBytes = obj.GetBytes(body); //convert string to bytes
            request.ContentLength = documentBytes.Length;

            HttpWebResponse responsemsg = (HttpWebResponse)request.GetResponse();
            if ((responsemsg.StatusCode == HttpStatusCode.OK))
            {
                using (StreamReader reader = new StreamReader(responsemsg.GetResponseStream()))
                {
                    var responsedata = reader.ReadToEnd();
                    inv = JsonConvert.DeserializeObject<List<TimeSheetEmployee>>(responsedata);  ///Here is the problem on retrive inspection *********************

                }

            }
            else
            {

                ;

            }


            return inv;
        }
    }
}
