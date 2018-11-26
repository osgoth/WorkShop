using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkShop.Models
{
    public class Report
    {
        public int OrderID { get; set; }
        public string ClientName { get; set; }
        public string CarModel { get; set; }
        public DateTime ExecStartDate { get; set; }
        public DateTime ExecEndDate { get; set; }
        public string MasterName { get; set; }
        public int Price { get; set; }
    }
}