using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;

namespace CityPowerInterfaces
{
    public interface IApartmentState : Orleans.IGrainState
    {
        List<PowerMeasurement> PowerLines { get; set; }

        int CurrentPower { get; set; }
    }
}
