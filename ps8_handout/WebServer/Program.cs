using System;
using System.Collections.Generic;
using System.Diagnostics;
using CS3500.Networking;
using GUI.Client.Controllers;
using Microsoft.AspNetCore.Hosting.Server;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;


namespace WebServer
{
    /// <summary>
    /// 
    /// </summary>
    public static class WebServer
    {

        private const string httpOkHeader = "HTTP/1.1 200 OK\r\n" +
            "Connection: close\r\n" +
            "Content-Type: text/html; charset=UTF-8\r\n" +
            "Content-Length: 89";

        private const string httpBadHeader = "HTTP/1.1 404 Not Found\r\n" +
            "Connection: close\r\n" +
            "Content-Type: text/html; charset=UTF-8\r\n" +
            "\r\n";

        public static void Main(string[] args)
        {
            // start the server with the HandleHttpConnection deligate pass
            
            Console.Read();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        private static void HandleHttpConnection(NetworkConnection connection)
        {
            Console.WriteLine("new client");
            string request = connection.ReadLine();
            Console.WriteLine(request);

            if(request.Contains("GET / "))
            {
                // serve to the display page

                string response = httpOkHeader;
                response += "<html>\r\n" + "<h3>Welcome to the Snake Games Database!</h3>\r\n" + "<a href=\"/games\">View Games</a>\r\n</html>"; // might have to separate into multiple response += strings in case this is wrong. COME BACK!!!
                connection.Send(response);
                connection.Disconnect();
            }
            else if(request.Contains("GET /games"))
            {
                // serve to the table of all the games in the database

                // mySQLConnection = new(connectDatabaseString)

                string response = httpOkHeader;

                response += "<html>" + "<table border=\"1\">" + "<thead>" + "<tr>" + "<td>ID</td><td>Start</td><td>End</td>" + "</tr>" + "</thead>" + "<tbody>";

                using (MySqlConnection connectionOne = new MySqlConnection(NetworkController.connectDatabaseString))
                {
                    connectionOne.Open();
                    MySqlCommand cmd = connectionOne.CreateCommand();
                    cmd.CommandText = "select * from Games";
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response += "<tr>";
                            response += "<td>" + "<a href=\"/games?gid=" + reader["GameID"] + ">" + reader["GameID"] + "</a>" +  "</td>";
                            response += "<td>" + reader["StartTime"] + "</td>";
                            response += "<td>" + reader["EndTime"] + "</td>";
                            response += "</tr>";
                        }
                    }
                }
                response += "</tbody>" + "</table>" + "</html>";
                connection.Send(response);
                connection.Disconnect();
            }
            else if(request.Contains("GET /games?gid=x"))
            {
                // serve to the stats for a specific game of a given gameID "x"

                string response = httpOkHeader;

                response += "<html>" + "<h3>" + "Stats for Game X" + "</h3>" + "<table border=\"1\">" +
                    "<thead>" + "<tr>" + "<td>Player ID</td><td>Player Name</td><td>Max Score</td><td>Enter Time</td><td>Leave Time</td>" +
                    "</tr>" + "<tbody>";
                using (MySqlConnection connectionTwo = new MySqlConnection(NetworkController.connectDatabaseString))
                {
                    connectionTwo.Open();
                    MySqlCommand cmd = connectionTwo.CreateCommand();
                    cmd.CommandText = "select * from Players";
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response += "<tr>";
                            response += "<td>" + reader["PlayerID"] + "</td>";
                            response += "<td>" + reader["PlayerName"] + "</td>";
                            response += "<td>" + reader["MaxScore"] + "</td>";
                            response += "<td>" + reader["EnterTime"] + "</td>";
                            response += "<td>" + reader["LeaveTime"] + "</td>";
                            response += "</tr>";
                        }
                    }
                }
                response += "</tbody>" + "</table>" + "</html>";
                connection.Send(response);
                connection.Disconnect();
            }
            else
            {
                // if the server is not found
                string response = httpBadHeader;
                connection.Send(response);
                connection.Disconnect();
            }
        }
    }
}

//< html >
//  < h3 > Welcome to the Snake Games Database!</h3>
//  <a href="/games">View Games</a>
//</html>
