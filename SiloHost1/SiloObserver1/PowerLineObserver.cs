using CityPowerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloObserver1
{
    class PowerLineObserver : IPowerLineObserver    
    {
        public void OverConsumption(int power)
        {
            Console.WriteLine("Risque d'incendie : {0}W", power);
        }
    }
}
