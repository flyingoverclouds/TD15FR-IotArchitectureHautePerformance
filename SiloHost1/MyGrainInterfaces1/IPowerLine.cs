using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Orleans;

namespace CityPowerInterfaces
{
    /// <summary>
    /// Orleans grain communication interface IGrain1
    /// </summary>
    public interface IPowerLine : Orleans.IGrain
    {
        // TODO: add your interface methods.
        //
        // All methods must return a Task or Task<T>.

        Task SetPowerCurrent(int powerWatt);

        Task<int> GetCurrentPower();
        Task SubscribeForPowerNotifications(IPowerLineObserver subscriber);
    }
}
