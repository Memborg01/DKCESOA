using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Models;

namespace Helpers
{
    public class DatabaseHelper
    {
        private SqlConnection dbConnection;

        private Dictionary<uint, Airport> idToAirportsDictionary;
        private Dictionary<string, Airport> nameToAirportsDictionary;

        private List<Path> paths;
        private List<Path> flightPaths;
        private List<Airport> nodes;

        public DatabaseHelper()
        {
        }

        private void CreateConnection()
        {
            dbConnection =
                new SqlConnection(
                    "Data Source=dbs-oadk.database.windows.net;Initial Catalog=db-oadk;User ID=admin-oadk;Password=oceanicFlyAway123");
            dbConnection.Open();
        }

        private void CloseConnection()
        {
            if (dbConnection != null)
            {
                dbConnection.Close();
            }
        }

        public List<Airport> GetNodesCommand()
        {
            if (nodes != null && nodes.Any())
            {
                return nodes;
            }

            CreateConnection();

            idToAirportsDictionary = new Dictionary<uint, Airport>();
            nameToAirportsDictionary = new Dictionary<string, Airport>();

            nodes = new List<Airport>();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Airports ORDER BY NAME", dbConnection))
            {
                //connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check is the reader has any rows at all before starting to read.
                    if (reader.HasRows)
                    {
                        // Read advances to the next row.
                        while (reader.Read())
                        {
                            var name = reader.GetString(reader.GetOrdinal("name"));

                            var status = reader.GetBoolean(reader.GetOrdinal("availability"));

                            var id = (uint) reader.GetInt32(reader.GetOrdinal("ID"));

                            var node = new Airport(id, name, status);

                            nodes.Add(node);
                            idToAirportsDictionary.Add(id, node);
                            nameToAirportsDictionary.Add(node.Name, node);
                        }
                    }
                }
            }

            CloseConnection();
            return nodes;
        }

        public Airport getNodeById(uint id)
        {
            return idToAirportsDictionary[id];
        }

        public Airport getNodeByName(string name)
        {
            return nameToAirportsDictionary[name];
        }

        public Path getPathFromTo(Airport fromNode, Airport toNode, bool flightsOnly)
        {
            IOrderedEnumerable<Path> orderedPaths = null;
            if (flightsOnly)
            {
                orderedPaths = flightPaths.Where(p => p.FromNode.Name.Equals(fromNode.Name) && p.ToNode.Name.Equals(toNode.Name)).OrderBy(p => p.Duration);
            }
            else
            {
                orderedPaths = paths.Where(p => p.FromNode.Name.Equals(fromNode.Name) && p.ToNode.Name.Equals(toNode.Name)).OrderBy(p => p.Duration);
            }

            if (orderedPaths != null && orderedPaths.Any())
            {
                return orderedPaths.ElementAt(0);
            }
            else
            {
                return new Path();
            }

        }
    }
}