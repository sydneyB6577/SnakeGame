using GUI.Client.Controllers;
using MySql.Data.MySqlClient;

namespace WebServer
{
    /// <summary>
    ///     A class that generates a web server to display game information from the database.  
    ///     
    ///     Authors: Sydney Burt and Levi Hammond
    ///     Date: April 22, 2025
    /// </summary>
    public static class WebServer
    {
        /// <summary>
        ///     Creates a good HTTP header for when the server is found, the request is valid, and the database is connected. 
        /// </summary>
        /// Change contentLength 
        private const string httpOkHeader = "HTTP/1.1 200 OK\r\n" +
            "Connection: close\r\n" +
            "Content-Type: text/html; charset=UTF-8\r\n" +
            "Content-Length: {NetworkConnection.contentLength} \r\n" +
            "\r\n";

        /// <summary>
        ///     Creates a bad HTTP header for when the server isn't found, the request isn't valid, or the database isn't connected.
        /// </summary>
        private const string httpBadHeader = "HTTP/1.1 404 Not Found\r\n" +
            "Connection: close\r\n" +
            "Content-Type: text/html; charset=UTF-8\r\n" +
            "\r\n";

        //
        private static string gid = string.Empty;

        /// <summary>
        ///     The main method to start the server with the HandleHttpConnection delegate pass.
        /// </summary>
        /// <param name="args">Any string arguments the main method takes.</param>
        public static void Main(string[] args)
        {
            Server.StartServer(HandleHttpConnection, 80);
            Console.Read();
        }

        /// <summary>
        ///     This method handles basic http requests with very basic html reponses. 
        ///     Handles three different pages/requests: GET /, GET /games, and GET /games?gid=x.
        ///     GET  displays a basic welcome message and links to the game page.
        ///     GET /games displays a table with all the games in the database.
        ///     GET /games?gid=x displays the stats for a specific game with the given game ID.
        /// </summary>
        /// <param name="connection"> The network connection taken by the method. </param>
        private static void HandleHttpConnection(NetworkConnection connection)
        {
            string request = connection.ReadLine();
            if (request.Contains("GET / "))
            {
                //Creates the first display page with the title of the website.
                string response = httpOkHeader;
                response += "<html>\r\n" + "<h3>Welcome to the Snake Games Database!</h3>\r\n" + "<a href=\"/games\">View Games</a>\r\n" + "</html>"; // might have to separate into multiple response += strings in case this is wrong. 
                connection.Send(response);
            }
            else if (request.Contains("GET /games"))
            {
                //Displays a table with all of the game information in the database.
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
                            response += "<td>" + "<a href=/players?gid=" +  reader["GameID"] + ">" + reader["GameID"] + "</a>" + "</td>\r\n";
                            response += "<td>" + reader["StartTime"] + "</td>\r\n";
                            response += "<td>" + reader["EndTime"] + "</td>\r\n";
                            response += "</tr>\r\n";
                            //gid = reader["GameID"].ToString()!;
                        }
                    }
                }
                response += "</tbody>\r\n" + "</table>\r\n" + "</html>\r\n";
                connection.Send(response);
            }
            else if (request.Contains("GET /players?gid="))
            {
                //int nextWhiteSpace = request.IndexOf(' ', 16);
                //Not working
                //string linkGameID = request.Substring(16, nextWhiteSpace);
                //int currentGameID = 0;
                //int.TryParse(linkGameID, out currentGameID);

                //Displays the stats for a specific game of a given gameID "x."
                string response = httpOkHeader;
                //response += $"{response.Length}\r\n" + "\r\n";

                //replace 1 with url
                response += "<html>\r\n" + "<h3>\r\n" + "Stats for Game " + gid + "</h3>\r\n" + "<table border=\"1\">\r\n" +
                    "<thead>\r\n" + "<tr>\r\n" + "<td>Player ID</td><td>Player Name</td><td>Max Score</td><td>Enter Time</td><td>Leave Time</td>\r\n" +
                    "</tr>\r\n" + "<tbody>\r\n";
                using (MySqlConnection connectionTwo = new MySqlConnection(NetworkController.connectDatabaseString))
                {
                    connectionTwo.Open();
                    MySqlCommand cmd = connectionTwo.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Players"; // WHERE GameID = " + $"{currentGameID}";
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response += "<tr>";
                            response += "<td>" + reader["PlayerID"] + "</td>\r\n";
                            response += "<td>" + reader["PlayerName"] + "</td>\r\n";
                            response += "<td>" + reader["PlayerMaxScore"] + "</td>\r\n";
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
                //If the server is not found, the database is not connected, or the request isn't valid, returns 404 Not Found.
                string response = httpBadHeader;
                connection.Send(response);
            }
        }
    }
}
