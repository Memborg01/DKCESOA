using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Models;
using SolutionAccelerator.Models.DataTypes;

public class RoutePlanController : ApiController
{
    // POST: api/RoutePlan
    public IEnumerable<RouteAPIModel> Post(PacketModel packetModel)
    {

        List<Route> routes = new List<Route>(); // routePlanService.findShortestRoute(dummyPackage); TODO

        var route1 = new Route()
        {
            DestinationA = new Airport()
            {
                Availability = true,
                Name = "Cairo"
            },
            DestinationB = new Airport()
            {
                Availability = true,
                Name = "Zanzibar"
            },
            Time = new DateTime().AddHours(8),
            PacketPrice = new PacketPrice()
            {
                Weight = new Weight()
                {
                    Max = 1,
                    Min = 0.1f
                },
                Price = new Price()
                {
                    Currency = "USD",
                    Amount = 40
                }
            },
            RouteID = 1
        };
        var route2 = new Route()
        {
            DestinationA = new Airport()
            {
                Availability = true,
                Name = "Congo"
            },
            DestinationB = new Airport()
            {
                Availability = true,
                Name = "Zanzibar"
            },
            Time = new DateTime().AddHours(8),
            PacketPrice = new PacketPrice()
            {
                Weight = new Weight()
                {
                    Max = 1,
                    Min = 0.1f
                },
                Price = new Price()
                {
                    Currency = "USD",
                    Amount = 40
                }
            },
            RouteID = 1
        };

        routes.Add(route1);
        routes.Add(route2);

        var routeOutputModels =

            routes.Select(route => new RouteAPIModel()
                {
                    From = route.DestinationA.Name,
                    To = route.DestinationB.Name,
                    Price = route.PacketPrice.Price,
                    Time = route.Time.ToString("dd:HH:mm:ss")
                }
            );

        return routeOutputModels;
    }

}