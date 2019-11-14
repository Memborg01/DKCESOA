using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Models
{
    public class Weight
    {

        public int WeightID { get; set; }
        public float Min { get; set; }
        public float Max { get; set; }
    }
}