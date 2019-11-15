using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class RouteGraph
    {
        // Nodes list
        private List<Airport> Nodes;

        // Adjacency lists
        private List<Airport>[] AdjLists;

        public RouteGraph(List<Airport> nodes)
        {
            Nodes = nodes;

            // Initialize the adjacency lists
            initAdjLists();
        }

        private void initAdjLists()
        {
            int count = this.Nodes.Count + 1;
            this.AdjLists = new List<Airport>[count];

            foreach (var Node in this.Nodes)
            {
                this.AdjLists[Node.AirportId] = new List<Airport>();
            }
        }

        // Add an edge from startNode to endNode
        public void addEdge(Airport startNode, Airport endNode)
        {
            this.AdjLists[startNode.AirportId].Add(endNode);
        }

        // Print all paths from startNode to endNode
        public void printAllRoutes(Airport startNode, Airport endNode)
        {
            int count = this.Nodes.Count + 1;
            bool[] isVisited = new bool[count];
            List<Airport> route = new List<Airport>();

            // Add startNode the the route
            route.Add(startNode);

            // Recursive route calculation
            printAllRoutes(startNode, endNode, isVisited, route);
        }

        // A recursive function to print  
        // all paths from 'u' to 'd'.  
        // isVisited[] keeps track of  
        // vertices in current path.  
        // localPathList<> stores actual  
        // vertices in the current path 
        private void printAllRoutes(Airport node, Airport endNode, bool[] isVisited, List<Airport> route)
        {
            // Merk the current node
            isVisited[node.AirportId] = true;

            if (node.Equals(endNode))
            {
                string routeString = "";
                foreach (var routeNode in route)
                {
                    routeString += routeNode.Name + " ";
                }

                // If a match is found the route is finished so no need to go deeper
                isVisited[node.AirportId] = false;
                return;
            }

            // Recursively go through all the nodes adjacent to the current node
            foreach (var adjNode in this.AdjLists[node.AirportId])
            {
                if (!isVisited[adjNode.AirportId])
                {
                    // Add the current adjacent node tp the route
                    route.Add(adjNode);
                    printAllRoutes(adjNode, endNode, isVisited, route);

                    // Remove the current adjacent node from the route
                    route.Remove(adjNode);
                }
            }

            // Mark the current node  
            isVisited[node.AirportId] = false;
        }
    }
}