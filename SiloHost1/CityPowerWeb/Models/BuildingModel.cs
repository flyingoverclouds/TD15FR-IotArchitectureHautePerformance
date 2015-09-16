using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityPowerWeb.Models
{
    public class BuildingModel
    {
        public long Id { get; set; }
        public List<AppartmentModel> Appartments { get; set; }
    }
}
