using CityPowerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloObserver1
{
    class Program
    {
        static void Main(string[] args)
        {
            Orleans.OrleansClient.Initialize("DevTestClientConfiguration.xml");

            RunOberver();
            Console.WriteLine("Orleans Observer is running.\nPress Enter to terminate...");
            Console.ReadLine();

        }

        async static void RunOberver()
        {
            var line = CityPowerInterfaces.PowerLineFactory.GetGrain(12312);

            var observer = new PowerLineObserver();
            IPowerLineObserver observerRef = await PowerLineObserverFactory.CreateObjectReference(observer);

            await line.SubscribeForPowerNotifications(observerRef);

        }
    }
}
