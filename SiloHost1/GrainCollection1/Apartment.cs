using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Orleans;
using Orleans.Providers;

namespace GrainCollection1
{
    /// <summary>
    /// Orleans grain implementation class Apartment
    /// </summary>
     [StorageProvider(ProviderName = "PowerStore")]
    public class Apartment : Orleans.Grain<CityPowerInterfaces.IApartmentState>, CityPowerInterfaces.IApartment
    {
       
        public async Task SetPowerForLine(long powerLineId, int currentPower)
        {
            var line = State.PowerLines.Find((p) => p.Id == powerLineId);

            if (line == null)
            {
                line = new CityPowerInterfaces.PowerMeasurement() { Id = powerLineId, PowerConsumption = currentPower };
                State.PowerLines.Add(line);
            }
            else
                line.PowerConsumption = currentPower;
            await State.WriteStateAsync();

            DisplayApartmentPowerUsage();

            var apartmentId = this.GetPrimaryKeyLong();
            var buildingId = (int)(apartmentId / 100);
            var pTotal = await GetCurrentPower();
            var building = CityPowerInterfaces.BuildingFactory.GetGrain(buildingId);
            await building.SetPowerForApartment(apartmentId, pTotal);
        }

        public async Task<int> GetCurrentPower()
        {
            if (State.PowerLines == null)
                return 0;
            return State.PowerLines.Select(p => p.PowerConsumption).Sum();
        }

        async void DisplayApartmentPowerUsage()
        {
            GetLogger().Info("Apartment {0} : {1} lines consuming {2}W", this.GetPrimaryKeyLong(), State.PowerLines.Count, await GetCurrentPower());
        }

    }
}
