using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Bicycle : Vehicle
    {
        public string Model { get; set; }
        public DateOnly DateOfPurchase { get; set; }
        public Bicycle() : base("bicycle", 40, 15)
        {
            Model = "Mountain";
            DateOfPurchase = new DateOnly(2024, 10, 1);
        }
    }
}
