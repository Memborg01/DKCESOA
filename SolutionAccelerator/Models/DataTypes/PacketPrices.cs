using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace SolutionAccelerator.Models.DataTypes
{
    public class PacketPrices
    {
        public PacketPrice OneKg { get; } = new PacketPrice()
        {
            Price = new Price()
            {
                Currency = "dollars",
                Amount = 40,
            },
            Weight = new Weight()
            {
                Max = 1,
                Min = 0.01f
            }
        };

        public PacketPrice OneToFive { get; } = new PacketPrice()
        {
            Price = new Price()
            {
                Currency = "dollars",
                Amount = 60,
            },
            Weight = new Weight()
            {
                Max = 5,
                Min = 1
            }
        };

    }
}