using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Path : IEquatable<Path>
    {
        public Airport FromNode { get; set; }

        public Airport ToNode { get; set; }

        public int Steps { get; set; }


        public TransportationModeEnum TransportationMode { get; set; }

        public double Price { get; set; }

        public float Duration { get; set; }

        public Path()
        {

        }

        public Path(Airport fromNode, Airport toNode, int steps, TransportationModeEnum transportationMode)
        {
            FromNode = fromNode;
            ToNode = toNode;
            Steps = steps;
            TransportationMode = transportationMode;
            Duration = 8;
        }

        public bool Equals(Path other)
        {
            if (this.FromNode.Name.Equals(other.FromNode.Name) && this.ToNode.Name.Equals(other.ToNode.Name))
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return this.FromNode.Name + "-" + this.ToNode.Name;
        }

        public bool isAvailable()
        {
            if (!this.FromNode.Availability || !this.ToNode.Availability)
            {
                return false;
            }

            return true;
        }
    }
}