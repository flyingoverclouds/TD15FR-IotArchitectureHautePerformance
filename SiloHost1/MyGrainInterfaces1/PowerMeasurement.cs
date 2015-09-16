using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityPowerInterfaces
{
    [Serializable]
    public class PowerMeasurement
    {
        public long Id { get; set; }
        public int PowerConsumption { get; set; }
    }
}
