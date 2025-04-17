using System;
using System.Collections.Generic;
using System.Diagnostics;
using CS3500.Networking;
using Microsoft.AspNetCore.Hosting.Server;
using MySqlX.XDevAPI;

namespace WebServer
{
    public static class WebServer
    {
        public static void Main(string[] args)
        {
            // start the server with the HandleHttpConnection deligate pass
            
            Console.Read();
        }

        private static void HandleHttpConnection(NetworkConnection connection)
        {
            Console.WriteLine("new client");
            string request = connection.ReadLine();
            Console.WriteLine(request);

            if(request.Contains("GET / "))
            {
                // serve to the display page
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
                // if the serve is not found
            }
        }
    }
}

//< html >
//  < h3 > Welcome to the Snake Games Database!</h3>
//  <a href="/games">View Games</a>
//</html>
