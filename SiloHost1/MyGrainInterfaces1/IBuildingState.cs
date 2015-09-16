using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans;

namespace CityPowerInterfaces
{
    public interface IBuildingState : Orleans.IGrainState
    {
        List<PowerMeasurement> AppartmentsPower { get; set; }
        int CurrentPower { get; set; }
    }
}
