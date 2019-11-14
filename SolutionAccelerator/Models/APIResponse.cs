using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace Models
{
    public class APIReponse
    {
        public string from { get; set; }
        public string to { get; set; }
        public Price Price { get; set; }
        public int time { get; set; }
    }
}