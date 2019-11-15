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

        private List<Airport> airports;

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

        public List<Airport> GetaAirports()
        {
            CreateConnection();

            airports = new List<Airport>();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Airport", dbConnection))
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

                            var availability = reader.GetBoolean(reader.GetOrdinal("availability"));

                            var id = reader.GetInt32(reader.GetOrdinal("AirportId"));

                            var airport = new Airport(id, name, availability);

                            airports.Add(airport);
                        }
                    }
                }
            }

            CloseConnection();
            return airports;
        }
    }
}