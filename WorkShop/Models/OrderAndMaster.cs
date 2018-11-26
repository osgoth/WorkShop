using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkShop.Models
{
    public class OrderAndMaster
    {
        public List<Order> order { get; set; }
        public List<Master> master { get; set; }
    }
}