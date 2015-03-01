using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using AirplainShooterNext;
using ConsoleExtender;

namespace AirplaneShooterNext
{
    public class Hero
    {
        public static void UserAiplainKeysOptions()
        {
            // user keys : "<" , ">" , "space" - shooting
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.LeftArrow)
                {
                    AirplaneNext.currentAirplainPosX--;
                    AirplaneNext.AirplainMovingLimits();
                    Console.SetCursorPosition(AirplaneNext.currentAirplainPosX + 7, AirplaneNext.currentAirplainPosY + 2);
                    Console.Write(' ');
                    AirplaneNext.DrawFigureAtPosition(AirplaneNext.currentAirplainPosX, AirplaneNext.currentAirplainPosY, ConsoleColor.DarkGreen, AirplaneNext.airplain);
                }
                if (userInput.Key == ConsoleKey.RightArrow)
                {
                    AirplaneNext.currentAirplainPosX++;
                    AirplaneNext.AirplainMovingLimits();
                    Console.SetCursorPosition(AirplaneNext.currentAirplainPosX - 1, AirplaneNext.currentAirplainPosY + 2);
                    Console.Write(' ');
                    AirplaneNext.DrawFigureAtPosition(AirplaneNext.currentAirplainPosX, AirplaneNext.currentAirplainPosY, ConsoleColor.DarkGreen, AirplaneNext.airplain);
                }

                if (userInput.Key == ConsoleKey.Spacebar)
                {
                    AirplaneNext.Shooting(AirplaneNext.currentAirplainPosX + 3, AirplaneNext.currentAirplainPosY + 1, ConsoleColor.Magenta, '^');
                    Thread.Sleep(50);
                    AirplaneNext.Shooting(AirplaneNext.currentAirplainPosX + 3, AirplaneNext.currentAirplainPosY, ConsoleColor.Magenta, ' ');
                }
            }
        }
    }

    class AirplaneNext
    {
        public static Random randNum = new Random();

        public static char[,] airplainEmpty = { {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                         {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                         {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                         {' ', ' ', ' ', ' ', ' ', ' ', ' '}  };

        public static char[,] airplain = {  {' ', ' ', ' ', '*', ' ', ' ', ' '},
                                     {' ', ' ', '*', 'o', '*', ' ', ' '},
                                     {'*', '*', '|', '*', '|', '*', '*'},
                                     {' ', 'v', '*', '^', '*', 'v', ' '}  };
        public static int currentAirplainPosX = Console.WindowWidth / 2 - airplain.GetLength(0);
        public static int currentAirplainPosY = Console.WindowHeight - airplain.GetLength(1) + 2;

        public static char[,] bigAim = {  {'*', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', '*'},
                                   {' ', '*', '*', ' ', ' ', '*', ' ', ' ', '*', '*', ' '},
                                   {' ', ' ', ' ', '*', '*', 'o', '*', '*', ' ', ' ', ' '},
                                   {' ', ' ', ' ', '*', '*', 'v', '*', '*', ' ', ' ', ' '},
                                   {' ', '*', '*', ' ', ' ', '*', ' ', ' ', '*', '*', ' '},
                                   {'*', ' ', ' ', ' ', ' ', 'V', ' ', ' ', ' ', ' ', '*'}  };
        public static int currentBigAimPosX = Console.WindowWidth / 2 - bigAim.GetLength(0);
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
        public static int currentLittleAimPosX = currentBigAimPosX - 13;
        public static int currentLittleAimPosY = currentBigAimPosY - 2;

        public struct Bullet
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
        public struct EnemyBullet
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

        public static void Shooting(int x, int y, ConsoleColor color, char bulletChar)
        {
            Bullet playerBull = new Bullet();
            playerBull.X = x;
            playerBull.Y = y;
            playerBull.Color = color;
            playerBull.Bullets = bulletChar;
            Audio sp = new Audio();
            Audio sp2 = new Audio();
            Thread tid = new Thread(new ThreadStart(sp.shot));
            Thread tid2 = new Thread(new ThreadStart(sp2.destroy));
            tid.Start();

            while (playerBull.Y >= 0)
            {
                Console.ForegroundColor = playerBull.Color;
                Console.SetCursorPosition(playerBull.X, playerBull.Y);
                Console.WriteLine(playerBull.Bullets);
                playerBull.Y--;
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (playerBull.Y == enemies[i].Y + 3 && playerBull.X >= enemies[i].X && playerBull.X <= enemies[i].X + 4)
                    {
                        DrawFigureAtPosition(enemies[i].X, enemies[i].Y, ConsoleColor.DarkYellow, littleAimClear);
                        enemies.RemoveAt(i);
                        playerBull.Y = 0; 
                        tid2.Start();
                        break;
                    }
                }
            }
        }

        public static void EnemyShooting(int x, int y, ConsoleColor color, char bulletChar)
        {
            EnemyBullet enemyBull = new EnemyBullet();
            enemyBull.X = x;
            enemyBull.Y = y;
            enemyBull.Color = color;
            enemyBull.Bullets = bulletChar;
            Audio sp = new Audio();
            sp.enemyshot();

            while (enemyBull.Y < 43)
            {
                Console.ForegroundColor = enemyBull.Color;
                Console.SetCursorPosition(enemyBull.X, enemyBull.Y);
                Console.WriteLine(enemyBull.Bullets);
                enemyBull.Y++;
            }
        }

        public static void AirplainMovingLimits()
        {
            if (currentAirplainPosX == 0)
            {
                DrawFigureAtPosition(currentAirplainPosX, currentAirplainPosY, ConsoleColor.Black, airplainEmpty);
                currentAirplainPosX += 1;
            }
            if (currentAirplainPosX == Console.WindowWidth - 8)
            {
                DrawFigureAtPosition(currentAirplainPosX, currentAirplainPosY, ConsoleColor.Black, airplainEmpty);
                currentAirplainPosX -= 1;
            }
        }

        public static void EnemiesFigureConfiguration2()
        {
            DrawFigureAtPosition(currentBigAimPosX, currentBigAimPosY + 2, ConsoleColor.DarkRed, bigAim);

            DrawFigureAtPosition(currentLittleAimPosX - 3, currentLittleAimPosY, ConsoleColor.DarkYellow, littleAim);
            DrawFigureAtPosition(currentLittleAimPosX - 13, currentLittleAimPosY + 7, ConsoleColor.DarkYellow, littleAim);
            DrawFigureAtPosition(currentLittleAimPosX - 3, currentLittleAimPosY + 13, ConsoleColor.DarkYellow, littleAim);

            DrawFigureAtPosition(currentLittleAimPosX + 34, currentLittleAimPosY, ConsoleColor.DarkYellow, littleAim);
            DrawFigureAtPosition(currentLittleAimPosX + 44, currentLittleAimPosY + 7, ConsoleColor.DarkYellow, littleAim);
            DrawFigureAtPosition(currentLittleAimPosX + 34, currentLittleAimPosY + 13, ConsoleColor.DarkYellow, littleAim);

            DrawFigureAtPosition(currentLittleAimPosX + 16, currentLittleAimPosY + 13, ConsoleColor.DarkYellow, littleAim);
        }

        public static void EnemiesFigureConfiguration1()
        {
            DrawFigureAtPosition(currentBigAimPosX, currentBigAimPosY + 3, ConsoleColor.DarkRed, bigAim);

            DrawFigureAtPosition(currentLittleAimPosX, currentLittleAimPosY, ConsoleColor.DarkYellow, littleAim);
            DrawFigureAtPosition(currentLittleAimPosX - 10, currentLittleAimPosY + 7, ConsoleColor.DarkYellow, littleAim);
            DrawFigureAtPosition(currentLittleAimPosX, currentLittleAimPosY + 13, ConsoleColor.DarkYellow, littleAim);

            DrawFigureAtPosition(currentLittleAimPosX + 31, currentLittleAimPosY, ConsoleColor.DarkYellow, littleAim);
            DrawFigureAtPosition(currentLittleAimPosX + 40, currentLittleAimPosY + 7, ConsoleColor.DarkYellow, littleAim);
            DrawFigureAtPosition(currentLittleAimPosX + 31, currentLittleAimPosY + 13, ConsoleColor.DarkYellow, littleAim);

            DrawFigureAtPosition(currentLittleAimPosX + 16, currentLittleAimPosY + 15, ConsoleColor.DarkYellow, littleAim);
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
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
            Console.CursorVisible = false;
        }

        public static bool goLeft = true;

        public static List<LittleEnemy> enemies = new List<LittleEnemy>();

        public static void CreateLittleEnemies(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                var enemy = new LittleEnemy(i * 8, i % 2 * 10, ConsoleColor.DarkYellow, littleAim);
                enemies.Add(enemy);
            }

        }

        static void Main()
        {

            ConsoleHelper.SetConsoleFont(2);
            Console.WindowHeight = 78;
            Console.WindowWidth = 120;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            BufferSizeTitle();
            //LittleEnemy testEnemy = new LittleEnemy(20, 10, ConsoleColor.DarkYellow, littleAim);
            //LittleEnemy testEnemy2 = new LittleEnemy(40, 10, ConsoleColor.DarkYellow, littleAim);
            
            while (true)
            {
                DrawFigureAtPosition(currentAirplainPosX, currentAirplainPosY, ConsoleColor.DarkGreen, airplain);
                Hero.UserAiplainKeysOptions();
                //EnemiesFigureConfiguration1();
                if (enemies.Count == 0)
                {
                    CreateLittleEnemies(6);
                }
                
                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].Move();
                    enemies[i].Shoot();
                    
                }

                Thread.Sleep(50);
                //RandomEnemies shooting();

                //AirplainDyingConditions();

                //EnemiesDyingConditions();

                //RandomFallingBonus();

                //Scoring();         //Speed

                //Interface:  Wellcome, Rules of the game - .txt, Sounds, Levels changing - story of each level ???, Bye Bye
            }
        }
    }
}
