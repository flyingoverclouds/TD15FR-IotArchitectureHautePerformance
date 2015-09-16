using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CityPowerWeb.Controllers
{
     [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonnalDeviceController : ApiController
    {
        public async Task<Models.AppartmentModel> GetAppartment(long id)
        {

            var a = new Models.AppartmentModel();
            a.PowerLines = new List<Models.PowerLineModel>();
            a.Id = id;

            for (int pl = 0; pl < 15;pl++ )
            {
                long lineId = id * 100 + pl;
                var powerLine = CityPowerInterfaces.PowerLineFactory.GetGrain(lineId);
                a.PowerLines.Add(new Models.PowerLineModel()
                {
                    Id = lineId,
                    CurrentPower = await powerLine.GetCurrentPower()
                });
            }

            a.TotalPower = a.PowerLines.Select(l => l.CurrentPower).Sum();
            return a;
        }
    }
}
