using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;
using WorkShop.Models;

namespace WorkShop.Functionals
{
    public class DB
    {
        public static readonly string ConStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=WorkShop;Integrated Security=True";

        public static List<Client> ClientLoad()
        {
            List<Client> clients = new List<Client>();
            using (SqlConnection con = new SqlConnection(ConStr))
            {
                clients = con.Query<Client>("select * from Clients").ToList();
            }
            return clients;
        }

        public static List<Master> MastersLoad()
        {
            List<Master> masters = new List<Master>();
            using (SqlConnection con = new SqlConnection(ConStr))
            {
                masters = con.Query<Master>("select * from Masters").ToList();
            }
            return masters;
        }

        public static List<Car> CarsLoad()
        {
            List<Car> cars = new List<Car>();
            using (SqlConnection con = new SqlConnection(ConStr))
            {
                cars = con.Query<Car>("select * from Cars").ToList();
            }
            return cars;
        }

        public static void Create(Client clt)
        {
            using (SqlConnection con = new SqlConnection(ConStr))
            {
                con.Execute($"insert into Clients values ('{clt.FullName}', '{clt.PhoneNumber}')");
            }
        }
        public static void Create(Car cr)
        {
            using (SqlConnection con = new SqlConnection(ConStr))
            {
                con.Execute($"insert into Cars values ('{cr.Model}', '{cr.Year}', '{cr.Number}')");
            }
        }

        public static void CreateOrder(Client cl, Car cr, DateTime dt, string PbInfo)
        {
            using (SqlConnection con = new SqlConnection(ConStr))
            {
                con.Execute($"insert into Orders values ({cl.ID}, {cr.ID}, null, '{PbInfo}', null, '{dt.Year}-{dt.Month}-{dt.Day}', null)");
            }
        }

        public static bool IsRepeated(List<Client> cls, Client cl)
        {
            foreach (var x in cls)
            {
                if (x.FullName == cl.FullName && x.PhoneNumber == cl.PhoneNumber)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsRepeated(List<Car> crs, Car cr)
        {
            foreach (var x in crs)
            {
                if (x.Model == cr.Model && x.Number == cr.Number)
                {
                    return true;
                }
            }
            return false;
        }
    }
}