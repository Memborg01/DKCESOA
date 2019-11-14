using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace SolutionAccelerator.Models.DataTypes
{
    public class RouteAPIModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public Price Price { get; set; }
        public string Time { get; set; }
    }
}