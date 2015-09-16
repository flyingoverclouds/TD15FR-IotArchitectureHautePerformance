using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UpdatePowerLines
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://orleanscitypower.cloudapp.net/orleans/SetRandomValue/2");
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Console.WriteLine("Mise à jour des PowerLines");

                    Thread.Sleep(5000);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
