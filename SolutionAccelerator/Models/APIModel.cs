using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Parceltype
    {
        public bool animal { get; set; }
        public bool recommended { get; set; }
        public bool refrigerated { get; set; }
        public bool heated { get; set; }
        public bool weaponry { get; set; }
        public bool nuclear { get; set; }
        public bool cautious { get; set; }
    }

    public class RootObejct
    {
        public string date { get; set; }
        public float weight { get; set; }
        public float height { get; set; }
        public float width { get; set; }
        public float length { get; set; }
        public Parceltype parceltype { get; set; }
    }
}