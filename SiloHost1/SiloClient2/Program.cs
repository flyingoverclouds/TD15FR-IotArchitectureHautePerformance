using System;
using System.Threading;
using System.Threading.Tasks;

namespace SiloClient2
{
    /// <summary>
    /// Orleans test silo host
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {

            Orleans.OrleansClient.Initialize("DevTestClientConfiguration.xml");

            DoTestGrain();
            //DoTestObserver();
          

            Console.WriteLine("Orleans Client is running.\nPress Enter to terminate...");
            Console.ReadLine();

        }

        async static void DoTestGrain()
        {
           

            Random rnd = new Random((int)DateTime.Now.Ticks);
            for (int n = 0; n < 1000; n++)
            {
                int lineId = rnd.Next(10);
                int etag = rnd.Next(8);
                int appartId = (etag*10) + rnd.Next(8);
                int immeubleId = rnd.Next(15);
                long id = (immeubleId * 10000) + appartId * 100 + lineId;
                var line = CityPowerInterfaces.PowerLineFactory.GetGrain(id);
                await line.SetPowerCurrent(rnd.Next(6000));
                Console.Write(".");
                //await DisplayPowerForPrise(id);
            }
            
        }

        async static void DoTestObserver()
        {
            var l = CityPowerInterfaces.PowerLineFactory.GetGrain(12312);

            Console.WriteLine("Set to 4000W");
            await l.SetPowerCurrent(4000);
            Console.ReadLine();
            Console.WriteLine("Set to 5000W");
            await l.SetPowerCurrent(5000);
            Console.ReadLine();
            
        }

        async static Task DisplayPowerForPrise(long priseId)
        {
            var prise = CityPowerInterfaces.PowerLineFactory.GetGrain(priseId);
            var p = await prise.GetCurrentPower();
            Console.WriteLine("Ligne {0} : puissance instantané={1}W",
                priseId,p);
        }

    }
}
