using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityPowerInterfaces
{
    public interface IPowerLineObserver : IGrainObserver
    {
        void OverConsumption(int power);
    }
}
