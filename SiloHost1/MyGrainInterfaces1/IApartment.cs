using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;

namespace CityPowerInterfaces
{
    /// <summary>
    /// Orleans grain communication interface IApartment
    /// </summary>
    public interface IApartment : Orleans.IGrain
    {
        Task SetPowerForLine(long powerLineId, int currentPower);

        Task<int> GetCurrentPower();

    }

}
