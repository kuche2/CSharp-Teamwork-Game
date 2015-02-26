using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AirplaneNext
{
    class AirplaneNext
    {
        static Random randNum = new Random();

        static char[,] airplainEmpty = { {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                         {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                         {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                         {' ', ' ', ' ', ' ', ' ', ' ', ' '}  };

        static char[,] airplain = {  {' ', ' ', ' ', '*', ' ', ' ', ' '},
                                     {' ', ' ', '*', 'o', '*', ' ', ' '},
                                     {'*', '*', '|', '*', '|', '*', '*'},
                                     {' ', 'v', '*', '^', '*', 'v', ' '}  };
        static int currentAirplainPosX = Console.WindowWidth / 2 - airplain.GetLength(0);
        static int currentAirplainPosY = Console.WindowHeight - airplain.GetLength(1) + 2;

        static char[,] bigAim = {  {'*', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', '*'},
                                   {' ', '*', '*', ' ', ' ', '*', ' ', ' ', '*', '*', ' '},
                                   {' ', ' ', ' ', '*', '*', 'o', '*', '*', ' ', ' ', ' '},
                                   {' ', ' ', ' ', '*', '*', 'v', '*', '*', ' ', ' ', ' '},
                                   {' ', '*', '*', ' ', ' ', '*', ' ', ' ', '*', '*', ' '},
                                   {'*', ' ', ' ', ' ', ' ', 'V', ' ', ' ', ' ', ' ', '*'}  };
        static int currentBigAimPosX = Console.WindowWidth / 2 - bigAim.GetLength(0);
        static int currentBigAimPosY = bigAim.GetLength(0) - 2;

        static char[,] littleAim = {  {'*', ' ', '*', ' ', '*'},
                                      {' ', '*', '*', '*', ' '},
                                      {' ', '*', 'o', '*', ' '},
                                      {'*', ' ', 'V', ' ', '*'}  };
        static int currentLittleAimPosX = currentBigAimPosX - 13;
        static int currentLittleAimPosY = currentBigAimPosY - 2;

        struct Bullet
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

        private static void Shooting(int x, int y, ConsoleColor color, char bulletChar)
        {
            Bullet playerBull = new Bullet();
            playerBull.X = x;
            playerBull.Y = y;
            playerBull.Color = color;
            playerBull.Bullets = bulletChar;

            while (playerBull.Y > 0)
            {
                Console.ForegroundColor = playerBull.Color;
                Console.SetCursorPosition(playerBull.X, playerBull.Y);
                Console.WriteLine(playerBull.Bullets);
                playerBull.Y--;
            }
        }

        private static void AirplainMovingLimits()
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

        private static void UserAiplainKeysOptions()
        {
            // user keys : "<" , ">" , "space" - shooting
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.LeftArrow)
                {
                    currentAirplainPosX--;
                    AirplainMovingLimits();
                    Console.SetCursorPosition(currentAirplainPosX + 7, currentAirplainPosY + 2);
                    Console.Write(' ');
                    DrawFigureAtPosition(currentAirplainPosX, currentAirplainPosY, ConsoleColor.DarkGreen, airplain);
                }
                if (userInput.Key == ConsoleKey.RightArrow)
                {
                    currentAirplainPosX++;
                    AirplainMovingLimits();
                    Console.SetCursorPosition(currentAirplainPosX - 1, currentAirplainPosY + 2);
                    Console.Write(' ');
                    DrawFigureAtPosition(currentAirplainPosX, currentAirplainPosY, ConsoleColor.DarkGreen, airplain);
                }

                if (userInput.Key == ConsoleKey.Spacebar)
                {
                    Shooting(currentAirplainPosX + 3, currentAirplainPosY + 1, ConsoleColor.Magenta, '^');
                    Thread.Sleep(50);
                    Shooting(currentAirplainPosX + 3, currentAirplainPosY, ConsoleColor.Magenta, ' ');
                }
            }
        }

        private static void EnemiesFigureConfiguration2()
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

        private static void EnemiesFigureConfiguration1()
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

        private static void BufferSizeTitle()
        {
            Console.Title = "Airplain Shooter";
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
            Console.CursorVisible = false;
        }

        static void Main(string[] args)
        {
            BufferSizeTitle();

            while (true)
            {
                DrawFigureAtPosition(currentAirplainPosX, currentAirplainPosY, ConsoleColor.DarkGreen, airplain);

                EnemiesFigureConfiguration1();

                UserAiplainKeysOptions();

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
