using System;
using System.Collections.Generic;
using System.Threading;
using AirplainShooterNext;
using ConsoleExtender;

namespace AirplaneShooterNext
{
    public class Window
    {
        public static int Height = 55;
        public static int Width = 120;
    }
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
                    AirplaneNext.Bullet bullet = new AirplaneNext.Bullet(AirplaneNext.currentAirplainPosX + 3, AirplaneNext.currentAirplainPosY + 1, ConsoleColor.Magenta, '^');
                    AirplaneNext.bullets.Add(bullet);
                    Audio.shot();
                }

                if (userInput.Key == ConsoleKey.P)
                {
                    while (true)
                    {
                        if (Console.ReadKey().Key == ConsoleKey.P)
                        {
                            break;
                        }
                    }
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
            for (int i = 0; i < enemies.Count; i++)
            {
                if (bullet.Y <= enemies[i].Y + 4 && bullet.Y >= enemies[i].Y && bullet.X >= enemies[i].X && bullet.X <= enemies[i].X + 4)
                {
                    DrawFigureAtPosition(enemies[i].X, enemies[i].Y, ConsoleColor.DarkYellow, littleAimClear);
                    enemies.RemoveAt(i);
                    Audio.destroy();
                    Console.SetCursorPosition(bullet.X, bullet.Y + 1);
                    Console.WriteLine(' ');
                    bullet.Y = 0;
                    break;
                }
            }
        }

        //public static void Shooting(int x, int y, ConsoleColor color, char bulletChar)
        //{
        //    Bullet playerBull = new Bullet();
        //    playerBull.X = x;
        //    playerBull.Y = y;
        //    playerBull.Color = color;
        //    playerBull.Bullets = bulletChar;

        //    while (playerBull.Y >= 0)
        //    {
        //        Console.ForegroundColor = playerBull.Color;
        //        Console.SetCursorPosition(playerBull.X, playerBull.Y);
        //        Console.WriteLine(playerBull.Bullets);
        //        playerBull.Y--;
        //        for (int i = 0; i < enemies.Count; i++)
        //        {
        //            if (playerBull.Y == enemies[i].Y + 3 && playerBull.X >= enemies[i].X && playerBull.X <= enemies[i].X + 4)
        //            {
        //                DrawFigureAtPosition(enemies[i].X, enemies[i].Y, ConsoleColor.DarkYellow, littleAimClear);
        //                enemies.RemoveAt(i);
        //                playerBull.Y = 0;
        //                break;
        //            }
        //        }
        //    }
        //}

        //public static void EnemyShooting(int x, int y, ConsoleColor color, char bulletChar)
        //{
        //    EnemyBullet enemyBull = new EnemyBullet();
        //    enemyBull.X = x;
        //    enemyBull.Y = y;
        //    enemyBull.Color = color;
        //    enemyBull.Bullets = bulletChar;

        //    //if (enemyBull.Y < 43)
        //    //{
        //    //    Console.ForegroundColor = enemyBull.Color;
        //    //    Console.SetCursorPosition(enemyBull.X, enemyBull.Y);
        //    //    Console.WriteLine(enemyBull.Bullets);
        //    //    enemyBull.Y++;
        //    //}
        //}

        public static void AirplainMovingLimits()
        {
            if (currentAirplainPosX == 0)
            {
                DrawFigureAtPosition(currentAirplainPosX, currentAirplainPosY, ConsoleColor.Black, airplainEmpty);
                currentAirplainPosX += 1;
            }
            if (currentAirplainPosX == Window.Width - 8)
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

            new Window();

            BufferSizeTitle();

            while (true)
            {
                DrawFigureAtPosition(currentAirplainPosX, currentAirplainPosY, ConsoleColor.DarkGreen, airplain);
                Hero.UserAiplainKeysOptions();
                //EnemiesFigureConfiguration1();
                if (enemies.Count == 0)
                {
                    CreateLittleEnemies(7);
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
