using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeSheetEntryForManagers.Models
{
    public class TimeSheetEmployee
    {
        public int tmpayweekid { get; set; }
        public string empmanager { get; set; }
        public string tmemployee_id { get; set; }
        public int tmelementid { get; set; }
        public int tmtimesheetid { get; set; }
        public string EmployeeName { get; set; }
        public string EDEmployee_ID { get; set; }
        public string EMPFirst_Name { get; set; }
        public string EMPLast_Name { get; set; }
        public string pidisplaydesc { get; set; }
        public int TMItemCdeID { get; set; }
        public Nullable<decimal> tmhrs { get; set; }
        public Nullable<decimal> tmrate { get; set; }
        public Nullable<decimal> tmamt { get; set; }
        public Nullable<int> TMInvoiceNumber { get; set; }
        public Nullable<decimal> TMInvoiceAmt { get; set; }
        public string tmcustomername { get; set; }
        public Nullable<decimal> PIItemPayRate { get; set; }
        public Nullable<int> edpaytypeid { get; set; }
        public string emptitle { get; set; }
        public Nullable<decimal> PVMaxAmtValue { get; set; }
        public Nullable<decimal> PVMinAmtValue { get; set; }
        public Nullable<decimal> PVMaxHrsValue { get; set; }
        public Nullable<decimal> PVMinHrsValue { get; set; }
        public Nullable<decimal> pvroundhrs { get; set; }
        public string pvtitle { get; set; }
        public string pvemployee_id { get; set; }
        public string PVValidItem { get; set; }
    }
}