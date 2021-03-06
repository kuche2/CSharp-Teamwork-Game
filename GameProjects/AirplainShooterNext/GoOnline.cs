﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;

namespace AirplainShooterNext
{
    /// <summary>
    /// Structure/Class that store user data
    /// </summary>
    public class Player
    {
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public DateTime RegisterAt { get; set; }
        public bool Logged { get; set; }
        public DateTime LoggedDate { get; set; }
        public int Score { get; set; }
        public int Killed { get; set; }
        public int Death { get; set; }
        public int RealScore { get; set; }
        public int RealKilled { get; set; }
        public int RealLives { get; set; }
        public int RealDeaths { get; set; }
    }
    /// <summary>
    /// Go Online script that implements multiplayer statistics on player's score etc
    /// </summary>
    static class GoOnline
    {
        static public Player MyData;

        static HttpClient client = new HttpClient();
        /// <summary>
        /// Connect to server with username and creates new instance of httpClient
        /// </summary>
        /// <param name="username">String variable for username of player</param>
        /// <returns>The method returns and store user data from server if user exists or create new user</returns>
        public static async Task connect(string username)
        {
            if(AirplaneShooterNext.AirplaneNext.isOnline == true)
            {
                client.BaseAddress = new Uri("http://game.igergov.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Players/" + username);
                if (response.IsSuccessStatusCode)
                {
                    Player Player = await response.Content.ReadAsAsync<Player>();
                    if (Player.ToString().Length > 0)
                    {
                        MyData = Player;
                    }
                    else
                    {
                        CreateUser(username).Wait();
                    }
                }
                else
                {
                    CreateUser(username).Wait();
                }
                LoginUser().Wait();

                Thread.Sleep(3000);
            }
        }

        /// <summary>
        /// Create new user if user not exists
        /// </summary>
        /// <param name="username">Username of player as string</param>
        /// <returns>Store data from server for new user</returns>
        public static async Task CreateUser(string username)
        {

            // HTTP POST
            var Player = new Player() { Name = username, Death = 0, Killed = 0, RealDeaths = 0, RealKilled = 0, RealLives = 3, RealScore = 0, RegisterAt = DateTime.Now, Logged = true, LoggedDate = DateTime.Now, Score = 0 };
            var response = await client.PostAsJsonAsync("api/Players", Player);
            if (response.IsSuccessStatusCode)
            {
                Player Result = await response.Content.ReadAsAsync<Player>();
                Console.WriteLine("Successfully created {0}", Player.Name);
                MyData = Result;
            }
        }

        /// <summary>
        /// Username of player as string
        /// </summary>
        /// <returns>Get data from server</returns>
        public static async Task LoginUser()
        {
            if (AirplaneShooterNext.AirplaneNext.isOnline == true)
            {
                MyData.Logged = true;
                MyData.RealLives = 3;
                MyData.RealScore = 0;
                MyData.RealKilled = 0;
                MyData.RealDeaths = 0;
                var response = await client.PutAsJsonAsync("api/Players/" + MyData.PlayerID, MyData);
                if (response.IsSuccessStatusCode)
                {
                    Console.Clear();
                    Console.WriteLine("You are logged in!");
                    Console.WriteLine("{0}{1}{2}", "Username".PadRight(20), "Score".PadRight(20), "Registered at");
                    Console.WriteLine("{0}{1}{2}{3}", MyData.Name.PadRight(20), MyData.Score.ToString().PadRight(20), MyData.RegisterAt, MyData.RealScore);
                }
            }
        }
        /// <summary>
        /// This method store data in server 
        /// </summary>
        /// <param name="score">Score of player</param>
        /// <param name="killed">Killed ships by player</param>
        /// <returns>No data returned</returns>
        public static async Task kill(int score, int killed)
        {
            if (AirplaneShooterNext.AirplaneNext.isOnline == true)
            {
                MyData.RealScore = score;
                MyData.RealKilled += killed;
                var response = await client.PutAsJsonAsync("api/Players/" + MyData.PlayerID, MyData);
            }
        }
        /// <summary>
        /// Update user data on server after user was killed
        /// </summary>
        /// <param name="lives">User lives</param>
        /// <returns>No data returned</returns>
        public static async Task die(int lives)
        {
            if (AirplaneShooterNext.AirplaneNext.isOnline == true)
            {
                MyData.RealDeaths = 3 - lives;
                MyData.RealLives = lives;
                var response = await client.PutAsJsonAsync("api/Players/" + MyData.PlayerID, MyData);
            }
        }

        /// <summary>
        /// Change status of player on disconnect
        /// </summary>
        /// <returns>No data returned</returns>
        public static async Task disconnect()
        {
            if (AirplaneShooterNext.AirplaneNext.isOnline == true)
            {
                MyData.Logged = false;
                MyData.Score += MyData.RealScore;
                MyData.Death += MyData.RealDeaths;
                MyData.Killed += MyData.RealKilled;
                MyData.RealDeaths = 0;
                MyData.RealKilled = 0;
                MyData.RealLives = 0;
                MyData.RealScore = 0;
                var response = await client.PutAsJsonAsync("api/Players/" + MyData.PlayerID, MyData);
            }
        }
    }
}
