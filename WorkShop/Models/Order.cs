using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkShop.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int CarID { get; set; }
        public int MasterID { get; set; }
        public string ProblemInfo { get; set; }
        public int Price { get; set; }
        public DateTime ExecStartDate { get; set; }
        public DateTime ExecEndDate { get; set; }
    }
}