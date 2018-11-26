using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;
using WorkShop.Models;

namespace WorkShop.Functionals
{
    public class CO
    {
        public static readonly string ConStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=WorkShop;Integrated Security=True";

        public static List<Order> WithoutPrice()
        {
            List<Order> ords = new List<Order>();

            using (SqlConnection con = new SqlConnection(ConStr))
            {
                ords = con.Query<Order>("select * from Orders where Price is null and ExecEndDate is null and MasterID is not null").ToList();
            }

            return ords;
        }

        public static void UpdPrice(int OID, int price)
        {
            using(SqlConnection con = new SqlConnection(ConStr))
            {
                con.Execute($"update Orders set Price = {price}, ExecEndDate='{DateTime.Now.Year.ToString()}-{DateTime.Now.Month.ToString()}-{DateTime.Now.Day.ToString()}' where ID = {OID}");
            }
        }
    }
}