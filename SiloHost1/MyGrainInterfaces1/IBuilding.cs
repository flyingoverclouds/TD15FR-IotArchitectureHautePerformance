using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;

namespace CityPowerInterfaces
{
    /// <summary>
    /// Orleans grain communication interface IBuilding
    /// </summary>
    public interface IBuilding : Orleans.IGrain
    {
        Task SetPowerForApartment(long apartmentId, int currentPower);

        Task<int> GetCurrentPower();


        Task<List<PowerMeasurement>> GetPowerByApartments();
    }
}
