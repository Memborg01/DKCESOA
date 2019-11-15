using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Models
{
    public class PacketPrice
    {
        public int PacketPriceID { get; set; }
        public Price Price { get; set; }
        public Weight Weight { get; set; }
    }
}