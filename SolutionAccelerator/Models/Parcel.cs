using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace Models
{
    public class Parcel
    {
        public float Weight { get; set; }
        public float Length { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public ParcelTypeEnum Type { get; set; }
        public Parcel(float weight, float length, float height, float width, ParcelTypeEnum type)
        {
            Weight = weight;
            Length = length;
            Height = height;
            Width = width;
            Type = type;
        }
    }
}