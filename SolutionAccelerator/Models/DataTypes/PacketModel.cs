using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolutionAccelerator.Models.DataTypes
{
    public class PacketModel
    {
        public string Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string PackageType { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

    }
}