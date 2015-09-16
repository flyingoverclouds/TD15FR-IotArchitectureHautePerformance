using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CityPowerWeb.Controllers
{
    public class OrleansController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        // GET: Orleans
        public ActionResult SetRandomValue(int id)
        {
          
            ViewBag.MessageGrain = "Ceci est un message du grain SANS ERREUR";

            try
            {
                int buildingNum = id;
                Random rnd = new Random((int)DateTime.Now.Ticks);

                for (int etg = 0; etg <= 7; etg++)
                {
                    for (int appNum = 0; appNum <= 8; appNum++)
                    {
                        for (int linNum = 0; linNum <= 15; linNum++)
                        {
                            int lineId =
                                (buildingNum * 10000) +
                                etg * 1000 + appNum * 100 +
                                linNum;

                            var grainLine = CityPowerInterfaces.PowerLineFactory.GetGrain(lineId);

                            grainLine.SetPowerCurrent(rnd.Next(5000));
                        }
                    }
                }
                ViewBag.MessageGrain = "C'est fait ... le courrant est consommé ;)";
            }
            catch(Exception ex)
            {
                ViewBag.MessageGrain = "EXCEPTION : " + ex.ToString().Replace("\n", "<br/>");
            }

            return View("Index");
        }

        public async Task<ActionResult> DisplayBuilding(int id)
        {
            ViewBag.MessageGrain = "";

            StringBuilder sb = new StringBuilder();
            try
            {
                int buildingNum = id;

                sb.AppendLine("Building " + buildingNum.ToString());

                for (int etg = 0; etg <= 7; etg++)
                {
                    for (int appNum = 0; appNum <= 8; appNum++)
                    {
                        for (int linNum = 0; linNum <= 15; linNum++)
                        {
                            int lineId =
                                (buildingNum * 10000) +
                                etg * 1000 + appNum * 100 +
                                linNum;

                            var grainLine = CityPowerInterfaces.PowerLineFactory.GetGrain(lineId);

                            sb.AppendLine("   line " + lineId.ToString() + " = " + (await grainLine.GetCurrentPower()).ToString() +"W");
                            
                        }
                    }
                }
                ViewBag.MessageGrain = DateTime.Now.ToString() + " \r\n\r\n" + sb.ToString();
            }
            catch (Exception ex)
            {
                ViewBag.MessageGrain = "EXCEPTION : " + ex.ToString();
            }

            return View("Index");
        }

        public async Task<ActionResult> DisplayAppartement(int id = 166)
        {
            ViewBag.MessageGrain = "";

            StringBuilder sb = new StringBuilder();
            try
            {
                int appartNum = id;

                sb.AppendLine("Appart " + appartNum.ToString());

                var appart = CityPowerInterfaces.ApartmentFactory.GetGrain(appartNum);
                
                int power = await appart.GetCurrentPower();

                for (int linNum = 0; linNum <= 15; linNum++)
                {
                    int lineId =
                        appartNum * 100 +
                        linNum;

                    var grainLine = CityPowerInterfaces.PowerLineFactory.GetGrain(lineId);
                    var linePuiss = await grainLine.GetCurrentPower();

                    //var pc = linePuiss * (100.0/5000.0);
                    //if (linePuiss>4500) // simulon le feu :)
                    //    pc=100;
                    var pc = linePuiss;

                    sb.AppendLine("   line " + lineId.ToString() + " = " + ((int)pc).ToString() + "W");

                }
                ViewBag.MessageGrain = DateTime.Now.ToString() + " \r\n\r\n" + sb.ToString();
            }
            catch (Exception ex)
            {
                ViewBag.MessageGrain = "EXCEPTION : " + ex.ToString();
            }

            return View("Index");
        }

        public async Task<ActionResult> SetPowerLine(long id,int value)
        {
            var powerLine = CityPowerInterfaces.PowerLineFactory.GetGrain(id);
            await powerLine.SetPowerCurrent(value);

            ViewBag.MessageGrain = "Line #" + id.ToString()+ "   = " + 
                (await powerLine.GetCurrentPower()).ToString() + "W";
            return View("Index");
        }
    }
}