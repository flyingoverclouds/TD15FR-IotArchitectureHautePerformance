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
    public class PowerNetworkController : ApiController
    {
    
        public async Task<Models.BuildingModel> GetBuilding(long id)
        {
            var b = new  Models.BuildingModel();
            b.Appartments = new List<Models.AppartmentModel>();

            b.Id = id;

            for (int etg = 0; etg <= 7; etg++)
            {
                for (int appNum = 0; appNum <= 8; appNum++)
                {
                    long appId = (id * 100) + etg * 10 + appNum;

                    var appGrain = CityPowerInterfaces.ApartmentFactory.GetGrain(appId);
                    var p = await appGrain.GetCurrentPower();

                    b.Appartments.Add(
                    new Models.AppartmentModel()
                    {
                        Id = appId,
                        TotalPower = p
                    });

                }
            }
            return b;
        }
    }
}