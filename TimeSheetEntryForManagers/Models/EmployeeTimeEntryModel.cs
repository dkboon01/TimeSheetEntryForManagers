using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeSheetEntryForManagers.Models
{
    public class EmployeeTimeEntryModel
    {
        [Key]
        public int  EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string ItemDesc1 { get; set; }
        public decimal RegularHrs { get; set; }
        public decimal OTHrs { get; set;  }
        public decimal Vacation { get; set; }
        public decimal Personal { get; set;  }
        public decimal Training { get; set; }
        public decimal LeadDedution { get; set; }
      
        public decimal ExcusedUnpaid { get; set; }
        public decimal Unexecused { get; set; }
        public decimal ThankYouDeduction { get; set; }
        public decimal LeadDeduction { get; set; }
        public int PRQC { get; set; }
        public decimal Holiday { get; set;  }
        //public string ItemDesc { get; set; }
        //public int  ItemCdeId { get; set; }
        //public string ItemValid { get; set; }
        public decimal ItemHrs { get; set; }
        public decimal ItemAmt { get; set; }
    }

}
