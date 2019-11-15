using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class OceanicRoute
    {
        public string Name { get; set; }

        public RouteTypeEnum RouteType { get; set; }
        public double TotalPrice { get; set; }
        public float TotalDuration { get; set; }
        public Parcel RouteParcel { get; set; }
        public List<Path> Paths { get; set; }

        public OceanicRoute(string name)
        {
            Name = name;
            Paths = new List<Path>();
        }

        public void addPath(Path path)
        {
            Paths.Add(path);
        }

        public override string ToString()
        {
            string routeToString = "";
            foreach (var path in Paths)
            {
                routeToString += path.ToString() + "\n";
            }

            return routeToString + this.TotalDuration + "h; " + this.TotalPrice + "$";
        }

        public bool isAvailable()
        {
            foreach (var path in this.Paths)
            {
                if (!path.isAvailable())
                {
                    return false;
                }
            }

            return true;
        }
    }
}