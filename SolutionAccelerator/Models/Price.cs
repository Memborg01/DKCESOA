using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Models
{
    public class Price
    {

        public int PriceID { get; set; }
        public string Currency { get; set; }
        public float Amount { get; set; }
    }
}