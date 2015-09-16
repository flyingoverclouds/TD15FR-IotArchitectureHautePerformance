using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Orleans;
using Orleans.Storage;
using Orleans.Providers;
using System.Net;
using CityPowerInterfaces;




namespace CityPowerGrains
{
    /// <summary>
    /// Orleans grain implementation class Grain1.
    /// </summary>
    [StorageProvider(ProviderName = "PowerStore")]
    public class PowerLine : Orleans.Grain<CityPowerInterfaces.IPowerLineState>, CityPowerInterfaces.IPowerLine
    {
       
        public async Task SetPowerCurrent(int powerWatt)
        {
            GetLogger().Info("Set power to : " + powerWatt.ToString());
            State.CurrentPower = powerWatt;
            await State.WriteStateAsync();

            var lineId = this.GetPrimaryKeyLong();
            var apartmentId = (int)(this.GetPrimaryKeyLong() / 100);
            
            var apartement = CityPowerInterfaces.ApartmentFactory.GetGrain(apartmentId);
            await apartement.SetPowerForLine(lineId, powerWatt);

            #region Simulation de surconsommation
            
            if (powerWatt>4500)
            {
                if (lineId.ToString().StartsWith("123")) // if appartment de test ID = 123 :)
                {
                    SendPushNotification("AU FEU !! : " + powerWatt.ToString() + "W");
                    subscribers.Notify((plo) => plo.OverConsumption(powerWatt));
                }
            }
            #endregion
        }


        public async Task<int> GetCurrentPower()
        {
            return State.CurrentPower;
        }

        
        #region Send notification
        private void SendPushNotification(string msg)
        {
            string notifUrl = "http://devtd15ams.azure-mobile.net/api/orleans/?msg=" + msg;

            var client = new WebClient();
            var content = client.DownloadString(notifUrl);
        }
        #endregion


        public override Task ActivateAsync()
        {
            this.subscribers = new ObserverSubscriptionManager<IPowerLineObserver>();
            return TaskDone.Done;
        }

        private ObserverSubscriptionManager<IPowerLineObserver> subscribers;
        public async Task SubscribeForPowerNotifications(IPowerLineObserver subscriber)
        {
            subscribers.Subscribe(subscriber);
        }
    }
}
