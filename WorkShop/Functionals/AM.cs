using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;
using WorkShop.Models;

namespace WorkShop.Functionals
{
    public class AM
    {
        public static readonly string ConStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=WorkShop;Integrated Security=True";

        public static List<Order> WithoutMaster()
        {   List<Order> withoutMaster = new List<Order>();
            using (SqlConnection con = new SqlConnection(ConStr))
            {
                withoutMaster = con.Query<Order>("Select * from Orders where MasterID is null").ToList();
            }
            return withoutMaster;
        }
        public static void UpdMaster(int OrderID, int MasterID)
        {
            using(SqlConnection con = new SqlConnection(ConStr))
            {
                con.Execute($"update Orders set MasterID={MasterID} where Orders.ID = {OrderID}");
            }
        }
    }
}