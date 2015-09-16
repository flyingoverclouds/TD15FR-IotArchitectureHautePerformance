using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityPowerWeb.Models
{
    public class AppartmentModel
    {
        public long Id { get; set; }

        public int TotalPower { get; set; }

        public List<Models.PowerLineModel> PowerLines { get; set; }
    }
}
