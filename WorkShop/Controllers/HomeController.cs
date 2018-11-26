using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkShop.Models;
using WorkShop.Functionals;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AssignMaster()
        {
            List<Master> masts = DB.MastersLoad();
            List<Order> ords = AM.WithoutMaster();
            OrderAndMaster oam = new OrderAndMaster
            { master = masts, order = ords };
            
            return View(oam);
        }

        public ActionResult CompleteOrder()
        {
            return View();
        }

        public ActionResult ShowReport()
        {
            List<Report> reps = SR.ReportLoad();
            return View(reps);
        }

        [HttpPost]
        public ActionResult Create(string name, string pnum, string model, string year, string cnum, string pinfo)
        {
            //loading lists 

            List<Client> clients = DB.ClientLoad();
            List<Car> cars = DB.CarsLoad();

            Client client = new Client
            {
                FullName = name,
                PhoneNumber = pnum
            };

            Car car = new Car
            {
                Model = model,
                Year = Convert.ToDateTime($"{year}-1-1"),
                Number = cnum
            };

            //check if db contains a client and a car

            if (!DB.IsRepeated(clients, client))
            {
                DB.Create(client);
            }

            if (!DB.IsRepeated(cars, car))
            {
                DB.Create(car);
            }

            //reloading lists

            clients = DB.ClientLoad();
            cars = DB.CarsLoad();

            //adding ids

            client.ID = clients.Where(x => x.FullName == client.FullName && x.PhoneNumber == client.PhoneNumber).Select(x => x.ID).FirstOrDefault();
            car.ID = cars.Where(x => x.Model == car.Model && x.Number == car.Number && x.Year == car.Year).Select(x => x.ID).FirstOrDefault();

            //creating order

            DB.CreateOrder(client, car, DateTime.Now, pinfo);



            return Content($"<h1>Order created successfully!</h1>");
        }

        [HttpPost]
        public ActionResult UpdMaster(int OID, int MID)
        {
            AM.UpdMaster(OID, MID);
            return PartialView();
        }
    }
}