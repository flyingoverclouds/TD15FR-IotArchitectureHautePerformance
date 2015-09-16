using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Orleans;
using CityPowerInterfaces;
using Orleans.Providers;

namespace GrainCollection1
{
    /// <summary>
    /// Orleans grain implementation class Building
    /// </summary>
    [StorageProvider(ProviderName = "PowerStore")]
    public class Building : Orleans.Grain<CityPowerInterfaces.IBuildingState>, CityPowerInterfaces.IBuilding
    {
        public async Task SetPowerForApartment(long apartmentId, int currentPower)
        {
            var apartment = State.AppartmentsPower.Find(a => a.Id == apartmentId);
            if (apartment == null)
            {
                apartment = new CityPowerInterfaces.PowerMeasurement() { Id = apartmentId, PowerConsumption = currentPower };
                State.AppartmentsPower.Add(apartment);
            }
            else
                apartment.PowerConsumption = currentPower;
            await State.WriteStateAsync();
            DisplayBuildingPowerUsage();
        }

        public async Task<int> GetCurrentPower()
        {
            if (State.AppartmentsPower == null)
                return 0;

            return State.AppartmentsPower.Select(ap => ap.PowerConsumption).Sum();
        }


        public async Task<List<PowerMeasurement>> GetPowerByApartments()
        {
            return State.AppartmentsPower;
        }

        async void DisplayBuildingPowerUsage()
        {
            GetLogger().Info("Building {0} : {1} apartment consuming {2}W", this.GetPrimaryKeyLong(), State.AppartmentsPower.Count, await GetCurrentPower());
        }
    }
}
