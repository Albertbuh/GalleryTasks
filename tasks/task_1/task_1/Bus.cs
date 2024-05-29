using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }
        /// <summary>
        /// Bus fuel usage in gallons per 100 km
        /// </summary>
        public float FuelUsage { get; set; }

        public Bus() : base("bus", 60, 4000)
        {
            NumberOfSeats = 80;
            FuelUsage = 30;
        }
    }
}
