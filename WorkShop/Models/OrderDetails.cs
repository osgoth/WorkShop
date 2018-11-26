using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkShop.Models
{
    public class OrderDetails
    {
        int ID { get; set; }
        int OrderID { get; set; }
        int Discount { get; set; }
        bool Repeated { get; set; }
    }
}