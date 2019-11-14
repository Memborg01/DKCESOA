﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;


namespace Models
{
    public class Routes
    {

        public int RouteID { get; set; }
        public Airport DestinationA { get; set; }
        public Airport DestinationB { get; set; }
        public int Time { get; set; }
        public PacketPrice PacketPrice { get; set; }
        
    }
}