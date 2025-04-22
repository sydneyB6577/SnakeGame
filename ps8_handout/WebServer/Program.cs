using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            "Content-Length: 89\r\n" + 
            "\r\n";

        private const string httpBadHeader = "HTTP/1.1 404 Not Found\r\n" +
            "Connection: close\r\n" +
            "Content-Type: text/html; charset=UTF-8\r\n" +
            "\r\n";

        public static void Main(string[] args)
        {
            // start the server with the HandleHttpConnection deligate pass

            Server.StartServer(HandleHttpConnection, 80);
            
            Console.Read();
        }

        /// <summary>
        /// 
        /// </summary>+		connection	{GUI.Client.Controllers.NetworkConnection}	GUI.Client.Controllers.NetworkConnection

        /// <param name="connection"> Server fills the database. </param>
        private static void HandleHttpConnection(NetworkConnection connection)
        {
            Console.WriteLine("new client");
            string request = connection.ReadLine();
            Console.WriteLine(request);

            if(request.Contains("GET / "))
            {
                // serve to the display page
                string response = httpOkHeader;
                response += "<html>\r\n" + "<h3>Welcome to the Snake Games Database!</h3>\r\n" + "<a href=\"/games\">View Games</a>\r\n" + "</html>"; // might have to separate into multiple response += strings in case this is wrong. COME BACK!!!
                Console.WriteLine(response);
                connection.Send(response);
                Console.WriteLine(response);
            }
            else if(request.Contains("GET /games"))
            {
                // serve to the table of all the games in the database)
                string response = httpOkHeader;

                response += "<html>\r\n" + "<table border=\"1\">\r\n" + "<thead>\r\n" + "<tr>\r\n" + "<td>ID</td><td>Start</td><td>End</td>\r\n" + "</tr>\r\n" + "</thead>\r\n" + "<tbody>\r\n";

                using (MySqlConnection connectionOne = new MySqlConnection(NetworkController.connectDatabaseString))
                {
                    connectionOne.Open();
                    MySqlCommand cmd = connectionOne.CreateCommand();
                    cmd.CommandText = "select * from Games";
                    
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response += "<tr>\r\n";
                            response += "<td>" + "<a href=\"/games?gid=" + reader["GameID"] + ">" + reader["GameID"] + "</a>" + "</td>\r\n";
                            response += "<td>" + reader["StartTime"] + "</td>\r\n";
                            response += "<td>" + reader["EndTime"] + "</td>\r\n";
                            response += "</tr>\r\n";
                        }
                    }
                }
                response += "</tbody>\r\n" + "</table>\r\n" + "</html>\r\n";
                connection.Send(response);
                //Disconnects from snake server even when server # is 80.
                //connection.Disconnect();
            }
            else if(request.Contains("GET /games?gid="))
            {

                // serve to the stats for a specific game of a given gameID "x"
                string response = httpOkHeader;

                response += "<html>\r\n" + "<h3>\r\n" + "Stats for Game " + "1" + "</h3>\r\n" + "<table border=\"1\">\r\n" +
                    "<thead>\r\n" + "<tr>\r\n" + "<td>Player ID</td><td>Player Name</td><td>Max Score</td><td>Enter Time</td><td>Leave Time</td>\r\n" +
                    "</tr>\r\n" + "<tbody>\r\n";
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
                            response += "<td>" + reader["PlayerID"] + "</td>\r\n";
                            response += "<td>" + reader["PlayerName"] + "</td>\r\n";
                            response += "<td>" + reader["MaxScore"] + "</td>\r\n";
                            response += "<td>" + reader["EnterTime"] + "</td>\r\n";
                            response += "<td>" + reader["LeaveTime"] + "</td>\r\n";
                            response += "</tr>\r\n";
                        }
                    }
                }
                response += "</tbody>\r\n" + "</table>\r\n" + "</html>\r\n";
                connection.Send(response);
            }
            else
            {
                // if the server is not found
                string response = httpBadHeader;
                connection.Send(response);
            }
        }
    }
}

//< html >
//  < h3 > Welcome to the Snake Games Database!</h3>
//  <a href="/games">View Games</a>
//</html>
