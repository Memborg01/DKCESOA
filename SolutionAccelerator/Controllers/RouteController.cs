using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;

namespace Controllers
{
    public class RouteController : Controller
    {
        public DatabaseHelper dbHelper { get; set; }

        private PriceHelper priceHelper;

        private HttpRequestHelper httpRequestHelper;

        public RouteController()
        {
            dbHelper = new DatabaseHelper();
            priceHelper = new PriceHelper();
            httpRequestHelper = new HttpRequestHelper();
        }


        // GET: Route
        public ActionResult RouteView()
        {
            //dbHelper = new DatabaseHelper();
            //priceHelper = new PriceHelper();

            List<Airport> nodes = dbHelper.GetNodesCommand();

            var weight = Request.QueryString["weight"];
            var length = Request.QueryString["length"];
            var width = Request.QueryString["width"];
            var depth = Request.QueryString["depth"];
            var from = Request.QueryString["from"];
            var to = Request.QueryString["to"];
            var date = Request.QueryString["date"];

            var parcel = new Parcel(float.Parse(weight), float.Parse(length), float.Parse(width), float.Parse(depth), ParcelTypeEnum.None);

            var fastestRoute = CalculateRoute(parcel, dbHelper.getNodeByName(from), dbHelper.getNodeByName(to), date, nodes, false, "Route 1");
            var flightsOnlyRoute = CalculateRoute(parcel, dbHelper.getNodeByName(from), dbHelper.getNodeByName(to), date, nodes, true, "Route 2");
            //CalculateCheapestRoute(nodes, paths);

            var routes = new List<OceanicRoute>();
            if (fastestRoute != null)
            {
                routes.Add(fastestRoute);
            }

            if (flightsOnlyRoute != null)
            {
                routes.Add(flightsOnlyRoute);
            }


            ViewBag.Nodes = nodes;
            ViewBag.Routes = routes;

            return View();
        }

        private void connectNodes(Graph<Airport, Path> graph, Path path)
        {
            int time = CalculateRouteTime(path.TransportationMode, path.Steps);

            path.Duration = time;

            graph.Connect(path.FromNode.AirportId, path.ToNode.AirportId, time, path);
        }

        private int CalculateRouteTime(TransportationModeEnum transportationMode, int steps)
        {
            switch (transportationMode)
            {
                case TransportationModeEnum.Ocean:
                    return 12 * steps;
                case TransportationModeEnum.Land:
                    return 4 * steps;
                case TransportationModeEnum.Air:
                    return 8 * steps;
                default:
                    return steps;
            }
        }


        public void CalculateCheapestRoute(List<Airport> nodes, List<Path> paths)
        {
            // Create a sample graph  
            RouteGraph g = new RouteGraph(nodes);
            foreach (var path in paths)
            {
                g.addEdge(path.FromNode, path.ToNode);
            }

            Console.WriteLine("Following are all different" +
                              " paths from " + nodes[5].Name + " to " + nodes[20].Name);
            g.printAllRoutes(nodes[5], nodes[20]);
        }


        public OceanicRoute CalculateRoute(Parcel parcel, Airport fromNode, Airport toNode, string date, List<Airport> nodes, bool flightsOnly, string routeName)
        {
            var graph = new Graph<Airport, Path>();

            List<Airport> paths = new List<Airport>();

            if (flightsOnly)
            {
                paths = dbHelper.GetNodesCommand();
            }

            foreach (var node in nodes)
            {
                graph.AddNode(node);
            }

            foreach (var path in paths)
            {
                connectNodes(graph, path);
            }

            ShortestPathResult result = graph.Dijkstra(fromNode.AirportId, toNode.AirportId); //result contains the shortest path

            var route = result.GetPath().ToList();


            OceanicRoute oceanicRoute = new OceanicRoute(routeName);
            if (flightsOnly)
            {
                oceanicRoute.RouteType = RouteTypeEnum.PlaneOnly;
            }
            else
            {
                oceanicRoute.RouteType = RouteTypeEnum.Fastest;
            }

            var price = priceHelper.CalculatePriceConsecutiveNodes(parcel.Weight, parcel.Height, parcel.Length, parcel.Width);

            for (int index = 0; index < route.Count - 1; index++)
            {
                var FromNode = dbHelper.getNodeById(route[index]);
                var ToNode = dbHelper.getNodeById(route[index + 1]);

                var path = dbHelper.getPathFromTo(FromNode, ToNode, flightsOnly);
                if (!path.TransportationMode.Equals(TransportationModeEnum.Air))
                {
                    var responseRootObject = httpRequestHelper.SendRequest(date, parcel.Weight, parcel.Height, parcel.Length, parcel.Width, path.TransportationMode);
                    path.Price = responseRootObject.Price.Amount;
                    path.Duration = responseRootObject.time;
                }
                else
                {
                    path.Price = price;
                }


                oceanicRoute.Paths.Add(path);

                //var calculateRouteTime = CalculateRouteTime(path.TransportationMode, path.Steps);

                oceanicRoute.TotalDuration += path.Duration;
                oceanicRoute.TotalPrice += path.Price;
            }

            if (oceanicRoute.Paths.Any())
            {
                return oceanicRoute;
            }
            else
            {
                return null;
            }

        }
    }
}