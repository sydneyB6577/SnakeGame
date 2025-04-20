using System;
using System.Collections.Generic;
using System.Diagnostics;
using CS3500.Networking;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySqlX.XDevAPI;

namespace WebServer
{
    /// <summary>
    /// 
    /// </summary>
    public static class WebServer
    {
        private const string httpOkHeader = "HTTP/1.1 200 OK\r\n" +
        "Connection: close\r\n\"" +
        "Content-Type: text/html; charset=UFT-\r\n" +
        "\r\n";

        private const string httpBadHeader = "HTTP/1.1 404 Not Found\r\n" + 
        "Connection: close\r\n" + 
        "Content-Type: text/html; charset=UTF-8\r\n" +
        "\r\n";
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
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
                //Serve to the display page
                string response = httpOkHeader;
                response = "<html >\r\n < h3 > Welcome to the Snake Games Database! < /h3 > \r\n  <a href=\"/games\">View Games</a>\r\n</html>"; //Maybe?
                connection.Send(response);
            }
            else if(request.Contains("GET /games"))
            {
                // serve to the table of all the games in the database
            }
            else if(request.Contains("GET /games?gid=x"))
            {
                // serve to the stats for a specific game of a given gameID "x"
            }
            else
            {
                string exception = httpBadHeader;
                exception = "lol";
                connection.Send(exception);
            }
        }
    }
}

//< html >
//  < h3 > Welcome to the Snake Games Database!</h3>
//  <a href="/games">View Games</a>
//</html>
