﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using AirplainShooterNext;
using ConsoleExtender;
using System.Runtime.InteropServices;

namespace AirplaneShooterNext
{
    public class Window
    {
        public static int Height = 55;
        public static int Width = 120;
    }
    

    class AirplaneNext
    {
        /**
         * 
         * Move to another class
         * 
         * 
         */


        static bool exitSystem = false;

        #region Trap application termination
        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);

        private delegate bool EventHandler(CtrlType sig);
        static EventHandler _handler;

        enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        private static bool Handler(CtrlType sig)
        {
            Console.SetCursorPosition(Window.Width-30,0);
            Console.WriteLine("Bye Bye!");

            //do your cleanup here
            Thread.Sleep(1000); //simulate some cleanup delay

            Console.SetCursorPosition(Window.Width - 30, 1);
            Console.WriteLine("Cleanup complete");

            Thread.Sleep(1000); //simulate some cleanup delay

            //allow main to run off
            exitSystem = true;

            Console.SetCursorPosition(Window.Width - 30, 2);
            //shutdown right away so there are no lingering threads
            Environment.Exit(-1);

            return true;
        }
        #endregion



        /**
         * 
         * 
         * 
         */


        public static Random randNum = new Random();

        public static char[,] airplainEmpty = { {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                         {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                         {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                         {' ', ' ', ' ', ' ', ' ', ' ', ' '}  };

        public static char[,] airplain = {  {' ', ' ', ' ', '*', ' ', ' ', ' '},
                                     {' ', ' ', '*', 'o', '*', ' ', ' '},
                                     {'*', '*', '|', '*', '|', '*', '*'},
                                     {' ', 'v', '*', '^', '*', 'v', ' '}  };
        public static int currentAirplainPosX = Window.Width / 2 - airplain.GetLength(0);
        public static int currentAirplainPosY = Window.Height - airplain.GetLength(1) + 2;

        public static char[,] bigAim = {  {'*', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', '*'},
                                   {' ', '*', '*', ' ', ' ', '*', ' ', ' ', '*', '*', ' '},
                                   {' ', ' ', ' ', '*', '*', 'o', '*', '*', ' ', ' ', ' '},
                                   {' ', ' ', ' ', '*', '*', 'v', '*', '*', ' ', ' ', ' '},
                                   {' ', '*', '*', ' ', ' ', '*', ' ', ' ', '*', '*', ' '},
                                   {'*', ' ', ' ', ' ', ' ', 'V', ' ', ' ', ' ', ' ', '*'}  };
        public static int currentBigAimPosX = Window.Width / 2 - bigAim.GetLength(0);
        public static int currentBigAimPosY = bigAim.GetLength(0) - 2;

        public static char[,] littleAim = {  {'*', ' ', '*', ' ', '*'},
                                      {' ', '*', '*', '*', ' '},
                                      {' ', '*', 'o', '*', ' '},
                                      {'*', ' ', 'V', ' ', '*'}  };
        public static char[,] littleAimClear = {  {' ', ' ', ' ', ' ', ' '},
                                      {' ', ' ', ' ', ' ', ' '},
                                      {' ', ' ', ' ', ' ', ' '},
                                      {' ', ' ', ' ', ' ', ' '}  };
        public static char[,] littleAimEmpty = { { ' ' }, { ' ' }, { ' ' }, { ' ' }, { ' ' } };
        public static char[,] littleAimEmptyTop = { { ' ', ' ', ' ', ' ', ' ' } };
        public static int currentLittleAimPosX = currentBigAimPosX - 13;
        public static int currentLittleAimPosY = currentBigAimPosY - 2;

        public class Bullet
        {
            public int X;
            public int Y;
            public ConsoleColor Color;
            public char Bullets;

            public Bullet(int x, int y, ConsoleColor color, char bull)
            {
                this.X = x;
                this.Y = y;
                this.Color = color;
                this.Bullets = bull;
            }
        }
        public class EnemyBullet
        {
            public int X;
            public int Y;
            public ConsoleColor Color;
            public char Bullets;

            public EnemyBullet(int x, int y, ConsoleColor color, char bull)
            {
                this.X = x;
                this.Y = y;
                this.Color = color;
                this.Bullets = bull;
            }
        }

        public static void MoveEnemyBullet(EnemyBullet enemyBull)
        {
            if (enemyBull.Y < Window.Height - 1)
            {
                Console.ForegroundColor = enemyBull.Color;
                Console.SetCursorPosition(enemyBull.X, enemyBull.Y);
                Console.WriteLine(enemyBull.Bullets);
                enemyBull.Y++;
                Console.SetCursorPosition(enemyBull.X, enemyBull.Y - 2);
                Console.WriteLine(' ');
                if (enemyBull.Y == Window.Height - 1)
                {
                    Console.SetCursorPosition(enemyBull.X, enemyBull.Y - 1);
                    Console.WriteLine(' ');
                }
            }
        }

        public static void MoveBullet(Bullet bullet)
        {
            if (bullet.Y >= 0)
            {
                Console.ForegroundColor = bullet.Color;
                Console.SetCursorPosition(bullet.X, bullet.Y);
                Console.WriteLine(bullet.Bullets);
                bullet.Y--;
                Console.SetCursorPosition(bullet.X, bullet.Y + 2);
                Console.WriteLine(' ');
                if (bullet.Y == 0)
                {
                    Console.SetCursorPosition(bullet.X, 1);
                    Console.WriteLine(' ');
                }
            }
            KillEnemy(bullet);
        }

        public static void AirplainMovingLimits()
        {
            if (currentAirplainPosX == 0)
            {
                DrawFigureAtPosition(currentAirplainPosX, currentAirplainPosY, ConsoleColor.Black, airplainEmpty);
                currentAirplainPosX += 1;
            }
            if (currentAirplainPosX == Window.Width - 48)
            {
                DrawFigureAtPosition(currentAirplainPosX, currentAirplainPosY, ConsoleColor.Black, airplainEmpty);
                currentAirplainPosX -= 1;
            }
        }

        public static void DrawFigureAtPosition(int x, int y, ConsoleColor color, char[,] figure)
        {
            Console.ForegroundColor = color;

            for (int i = 0; i < figure.GetLength(0); i++)
            {
                for (int j = 0; j < figure.GetLength(1); j++)
                {
                    Console.SetCursorPosition(x + j, y + i);
                    Console.Write(figure[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static void BufferSizeTitle()
        {
            Console.Title = "Airplain Shooter";
            Console.WindowHeight = Window.Height;
            Console.WindowWidth = Window.Width;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;
        }

        public static bool goLeft = true;

        public static List<LittleEnemy> enemies = new List<LittleEnemy>();

        public static List<EnemyBullet> enemyBullets = new List<EnemyBullet>();
        public static List<Bullet> bullets = new List<Bullet>();

        public static void CreateLittleEnemies(int number, ConsoleColor color)
        {
            for (int i = 1; i <= number; i++)
            {
                var enemy = new LittleEnemy(i * 8, i % 2 * 10, color, littleAim);
                enemies.Add(enemy);
            }

        }

        public static ConsoleColor[] colors = {ConsoleColor.DarkYellow, ConsoleColor.Red, ConsoleColor.Cyan};

        private static void KillEnemy(Bullet bullet)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].Color == ConsoleColor.DarkYellow && bullet.Y <= enemies[i].Y + 4 && bullet.Y >= enemies[i].Y &&
                    bullet.X >= enemies[i].X && bullet.X <= enemies[i].X + 4)
                {
                    DrawFigureAtPosition(enemies[i].X, enemies[i].Y, ConsoleColor.DarkYellow, littleAimClear);
                    enemies.RemoveAt(i);
                    score += 10;
                    Audio.destroy();
                    Console.SetCursorPosition(bullet.X, bullet.Y + 1);
                    Console.WriteLine(' ');
                    bullet.Y = 0;
                    break;
                }
                else if (enemies[i].Color == ConsoleColor.Red && bullet.Y <= enemies[i].Y + 4 && bullet.Y >= enemies[i].Y &&
                    bullet.X >= enemies[i].X && bullet.X <= enemies[i].X + 4)
                {
                    enemies[i].Color = ConsoleColor.DarkYellow;
                    DrawFigureAtPosition(enemies[i].X, enemies[i].Y, enemies[i].Color, littleAim);
                    //enemies.RemoveAt(i);
                    score += 10;
                    Audio.destroy();
                    Console.SetCursorPosition(bullet.X, bullet.Y + 1);
                    Console.WriteLine(' ');
                    bullet.Y = 0;
                    break;
                }
                else if (enemies[i].Color == ConsoleColor.Cyan && bullet.Y <= enemies[i].Y + 4 && bullet.Y >= enemies[i].Y &&
                    bullet.X >= enemies[i].X && bullet.X <= enemies[i].X + 4)
                {
                    enemies[i].Color = ConsoleColor.Red;
                    DrawFigureAtPosition(enemies[i].X, enemies[i].Y, enemies[i].Color, littleAim);
                    //enemies.RemoveAt(i);
                    score += 10;
                    Audio.destroy();
                    Console.SetCursorPosition(bullet.X, bullet.Y + 1);
                    Console.WriteLine(' ');
                    bullet.Y = 0;
                    break;
                }
            }
        }

        public static void PrintScore(int score)
        {
            Console.SetCursorPosition(90, 10);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Score: {0}", score);
        }

        public static int speed = 0;
        public static int score = 0;
        
        static void Main()
        {
            _handler += new EventHandler(Handler);
            SetConsoleCtrlHandler(_handler, true);

            ConsoleHelper.SetConsoleFont(2);

            new Window();

            BufferSizeTitle();

            int counter = 0;

            while (true)
            {
                DrawFigureAtPosition(currentAirplainPosX, currentAirplainPosY, ConsoleColor.DarkGreen, airplain);
                Hero.UserAiplainKeysOptions();

                if (enemies.Count == 0)
                {
                    CreateLittleEnemies(7, colors[counter%3]);
                    counter++;
                }

                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].Move();
                    enemies[i].Shoot();
                }
                for (int i = 0; i < enemyBullets.Count; i++)
                {
                    MoveEnemyBullet(enemyBullets[i]);
                    if (enemyBullets[i].Y == Window.Height - 1)
                    {
                        enemyBullets.RemoveAt(i);
                    }
                }
                for (int i = 0; i < bullets.Count; i++)
                {
                    MoveBullet(bullets[i]);
                    if (bullets[i].Y == 0)
                    {
                        bullets.RemoveAt(i);
                    }
                }
                PrintScore(score);
                speed = score/50;
                Thread.Sleep(50 - speed);
            }
        }
    }
}
