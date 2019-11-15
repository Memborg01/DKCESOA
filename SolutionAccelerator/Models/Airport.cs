using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Airport
    {
        public int AirportId { get; set; }
        public string Name { get; set; }
        public bool Availability { get; set; }

        public Airport()
        {
            
        }

        public Airport(int id, string name, Boolean availability)
        {
            AirportId = id;
            Name = name;
            Availability = availability;
        }
    }
}