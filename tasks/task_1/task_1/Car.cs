using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Car : Vehicle
    {
        /// <summary>
        /// Acceleration from 0 to 100 km/h
        /// </summary>
        public double Acceleration { get; set; }
        public Car() : base("car", 120, 2500)
        {
            Acceleration = 9.6;
        }
    }
}
