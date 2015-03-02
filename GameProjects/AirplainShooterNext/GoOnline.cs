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

    static class GoOnline
    {
        static public Player MyData;

        static HttpClient client = new HttpClient();

        public static async Task connect(string username)
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

        public static async Task LoginUser()
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

        public static async Task kill(int score, int killed)
        {
            MyData.RealScore = score;
            MyData.RealKilled += killed;
            var response = await client.PutAsJsonAsync("api/Players/" + MyData.PlayerID, MyData);
        }

        public static async Task die()
        {
            MyData.RealDeaths--;
            var response = await client.PutAsJsonAsync("api/Players/" + MyData.PlayerID, MyData);
        }

        public static async Task disconnect()
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
