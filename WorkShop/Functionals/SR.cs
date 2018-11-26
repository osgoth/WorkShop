using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WorkShop.Models;

namespace WorkShop.Functionals
{
    public class SR
    {
        public static readonly string ConStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=WorkShop;Integrated Security=True";

        public static List<Report> ReportLoad()
        {
            List<Report> reps = new List<Report>();
            using (SqlConnection con = new SqlConnection(ConStr))
            {
                con.Open();
                SqlCommand com = new SqlCommand("select Orders.ID as OrderID, Clients.FullName as ClientName, Cars.Model as CarModel, Orders.ExecStartDate, Orders.ExecEndDate, Masters.FullName as MasterName, Orders.Price"
                                                + " from Orders" 
                                                + " join Clients on Clients.ID = Orders.ClientID"
                                                + " join Cars on Cars.ID = Orders.CarID"
                                                + " join Masters on Masters.ID = Orders.MasterID"
                                                + " where Price is not null and ExecEndDate is not null and MasterID is not null", con);

                SqlDataReader red = com.ExecuteReader();

                if (red.HasRows)
                {
                    while (red.Read())
                    {
                        reps.Add(new Report
                        {
                            OrderID = Convert.ToInt16(red["OrderID"]),
                            ClientName = Convert.ToString(red["ClientName"]),
                            CarModel = Convert.ToString(red["CarModel"]),
                            ExecStartDate = Convert.ToDateTime(red["ExecStartDate"]),
                            ExecEndDate = Convert.ToDateTime(red["ExecEndDate"]),
                            MasterName = Convert.ToString(red["MasterName"]),
                            Price = Convert.ToInt16(red["Price"])
                        });
                    }

                }
            }
            return reps;
        }
    }
}