using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using AirplainShooterNext;
using ConsoleExtender;
using System.Runtime.InteropServices;
using System.IO;

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
            Console.SetCursorPosition(Window.Width - 30, 0);
            Console.WriteLine("Bye Bye!");

            //do your cleanup here
            Thread.Sleep(1000); //simulate some cleanup delay

            Console.SetCursorPosition(Window.Width - 30, 1);
            Console.WriteLine("Cleanup complete");
            HighScore(score, username);
            GoOnline.disconnect().Wait();
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


        public static List<string> levelPaths = new List<string>() 
         { "..\\..\\Levels\\level1.txt", 
            "..\\..\\Levels\\level2.txt", 
            "..\\..\\Levels\\level3.txt", 
            "..\\..\\Levels\\level4.txt", 
            "..\\..\\Levels\\level5.txt", 
            "..\\..\\Levels\\level6.txt", 
            "..\\..\\Levels\\level7.txt", 
            "..\\..\\Levels\\level8.txt", 
            "..\\..\\Levels\\level9.txt", 
            "..\\..\\Levels\\level10.txt", 
            "..\\..\\Levels\\level11.txt", 
            "..\\..\\Levels\\level12.txt", 
            "..\\..\\Levels\\level13.txt", 
            "..\\..\\Levels\\level14.txt", 
            "..\\..\\Levels\\level15.txt", 
            "..\\..\\Levels\\level16.txt", 
            "..\\..\\Levels\\level17.txt", 
            "..\\..\\Levels\\level18.txt", 
            "..\\..\\Levels\\level19.txt", 
            "..\\..\\Levels\\level20.txt", 
            "..\\..\\Levels\\level21.txt" };


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
        public static char[,] bigAimClear = {  {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                   {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                   {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                   {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                   {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                   {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}  };
        public static char[,] bigAimEmpty = { { ' ' }, { ' ' }, { ' ' }, { ' ' }, { ' ' }, { ' ' } };
        public static char[,] bigAimEmptyTop = {  {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}};
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
            KillHero(enemyBull);
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
            if (bossLevel)
            {
                KillBoss(bullet);
            }
            else
            {
                KillEnemy(bullet);
            }
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
            Console.Title = "Spider Invaders Killer";
            Console.WindowHeight = Window.Height;
            Console.WindowWidth = Window.Width;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;
        }

        public static bool goLeft = true;

        public static List<LittleEnemy> enemies = new List<LittleEnemy>();
        public static List<BigEnemy> boss = new List<BigEnemy>();

        public static List<EnemyBullet> enemyBullets = new List<EnemyBullet>();
        public static List<Bullet> bullets = new List<Bullet>();

        public static void CreateLittleEnemies(int number, ConsoleColor color)
        {
            Level(levelPaths[counter]);
            GoOnline.kill(score, number).Wait();
            for (int i = 1; i <= number; i++)
            {
                var enemy = new LittleEnemy(i * 8, i % 2 * 10, color, littleAim);
                enemies.Add(enemy);
            }

        }
        public static void CreateBoss(int number, ConsoleColor color)
        {
            Level(levelPaths[counter]);
            GoOnline.kill(score, number).Wait();
            for (int i = 1; i <= number; i++)
            {
                var enemy = new BigEnemy(i*20, 10, color, bigAim, 10);
                boss.Add(enemy);
            }

        }

        public static ConsoleColor[] colors = { ConsoleColor.DarkYellow, ConsoleColor.Red, ConsoleColor.Cyan };

        public static void KillEnemy(Bullet bullet)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].Color == ConsoleColor.DarkYellow && bullet.Y <= enemies[i].Y + 4 && bullet.Y >= enemies[i].Y &&
                    bullet.X >= enemies[i].X && bullet.X <= enemies[i].X + 4)
                {
                    DrawFigureAtPosition(enemies[i].X, enemies[i].Y, ConsoleColor.DarkYellow, littleAimClear);
                    enemies.RemoveAt(i);
                    if (enemies.Count == 0 && counter > 0 && (counter - 3) %4  == 0)
                    {
                        bossLevel = true;
                    }
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

        public static void KillBoss(Bullet bullet)
        {
            for (int i = 0; i < boss.Count; i++)
            {
                if (boss[i].Blood == 1 && bullet.Y <= boss[i].Y + 5 && bullet.Y >= boss[i].Y &&
                    bullet.X >= boss[i].X && bullet.X <= boss[i].X + 10)
                {
                    DrawFigureAtPosition(boss[i].X, boss[i].Y, ConsoleColor.DarkYellow, bigAimClear);
                    boss.RemoveAt(i);
                    if (boss.Count == 0)
                    {
                        bossLevel = false;
                    }
                    score += 50;
                    Audio.destroy();
                    Console.SetCursorPosition(bullet.X, bullet.Y + 1);
                    Console.WriteLine(' ');
                    bullet.Y = 0;
                    break;
                }
                else if (boss[i].Blood > 1 && bullet.Y <= boss[i].Y + 5 && bullet.Y >= boss[i].Y &&
                    bullet.X >= boss[i].X && bullet.X <= boss[i].X + 10)
                {
                    boss[i].Blood --;
                    DrawFigureAtPosition(boss[i].X, boss[i].Y, ConsoleColor.Red, bigAim);
                    
                    Audio.destroy();
                    Console.SetCursorPosition(bullet.X, bullet.Y + 1);
                    Console.WriteLine(' ');
                    bullet.Y = 0;
                    break;
                }
            }
        }
        public static void HighScore(int score, string username)
        {
            var scores = new SortedDictionary<int, string>();
            scores.Add(score, username);
            string path = "..\\..\\highScore.txt";
            if(File.Exists(path) == false)
            {
                File.Create(path);
            }
            StreamReader sr = new StreamReader(path);
            string line;
            List<string> fileContent = new List<string>();
            while ((line = sr.ReadLine()) != null)
            {
                fileContent.Add(line);
            }
            sr.Close();
            fileContent.Add(String.Format("{0}{1} points", username.PadRight(20), score.ToString().PadLeft(10)));
            fileContent.RemoveAt(0);
            var writer = new StreamWriter(path);
            writer.WriteLine("{0}{1}", "Username".PadRight(20), "High Score".PadLeft(10));
            foreach (var scor in fileContent)
            {
                writer.WriteLine(scor);
            }
            writer.Close();
        }
        public static bool KillHero(EnemyBullet bullet)
        {
            bool hit = false;
            if (bullet.Y >= currentAirplainPosY && bullet.Y >= Window.Height - 1 &&
                    bullet.X >= currentAirplainPosX && bullet.X <= currentAirplainPosX + 8)
            {
                hit = true;
                Audio.destroy();
                bullet.Y = Window.Height - 1;
                Console.SetCursorPosition(bullet.X, bullet.Y - 1);
                Console.WriteLine(' ');
            }
            return hit;
        }

        private static void GameOver()
        {
            Console.SetCursorPosition(60, 30);
            Console.WriteLine("GAME OVER");
            Console.SetCursorPosition(60, 31);
            Console.WriteLine("Your Score: {0}", score);
            Console.SetCursorPosition(60, 32);
            Console.WriteLine("Press any key to exit");
            HighScore(score, username);
            while (true)
            {
                Console.ReadKey();
                GoOnline.disconnect().Wait();
                Environment.Exit(-1);
            }
            //TO DO
        }

        public static void PrintScore(int score)
        {
            Console.SetCursorPosition(90, 8);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Player: {0}", username);
            Console.SetCursorPosition(90, 10);
            Console.WriteLine("Score: {0}", score);
        }

        public static void PrintLifeAndLives(int life)
        {
            Console.SetCursorPosition(90, 15);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Blood: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string(' ', 10));
            Console.SetCursorPosition(97, 15);
            if (life % 10 != 0)
            {
                Console.WriteLine(new string('|', life % 10));
            }
            else if (life > 0)
            {
                Console.WriteLine(new string('|', 10));
            }
            Console.SetCursorPosition(90, 20);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Lives: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new string(' ', 3));
            Console.SetCursorPosition(97, 20);
            if (life < 30 && life > 0 && life % 10 != 0)
            {
                Console.WriteLine(new string('♥', life / 10 + 1));
            }
            else
            {
                Console.WriteLine(new string('♥', life / 10));
            }
        }

        public static int speed = 0;
        public static int score = 0;
        public static bool isOnline = false;

        public static void Exceptions(string username)
        {
            try
            {
                bool usenameIsCorrect = username.Length != 0 || username.Length <= 20;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Username could not be empty!");
                throw;
            }
            catch (ApplicationException)
            {
                throw new ApplicationException("Too long username.");
                throw;
            }
            finally
            {
                Console.WriteLine("Incorrect username!");
            }
        }

        public static void Story()
        {
            StreamReader sr = new StreamReader("..\\..\\story.txt");
            string line = sr.ReadLine();

            while (line != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(line);
                line = sr.ReadLine();
            }
            sr.Close();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to continue ...");
            ConsoleKeyInfo userInput = Console.ReadKey();
            Console.Clear();
        }

        public static void Level(string levelpath)
        {
            Console.Clear();
            StreamReader sr = new StreamReader(levelpath);
            string line = sr.ReadLine();
            int p = Console.WindowHeight / 2 - 5;
            while (line != null)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 19, p);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(line);
                line = sr.ReadLine();
                p++;
            }
            sr.Close();
            Thread.Sleep(3000);
            Console.Clear();
        }

        public static string username = string.Empty;
        public static void Username() 
        {
            while (true)
            {
                Console.Write("Enter username: ");
                username = Console.ReadLine();

                if (username.Length == 0 || username.Length > 20)
                {
                    Exceptions(username);
                }
                else
                {
                    Console.WriteLine("Press any key to continue ...");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        isOnline = true;
                    }
                    else
                    {
                        isOnline = false;
                    }

                    GoOnline.connect(username).Wait();
                    Console.Clear();
                    break;
                }
            }
        }

        static int counter = 0;
        public static bool bossLevel = false;

        static void Main()
        {
            _handler += new EventHandler(Handler);
            SetConsoleCtrlHandler(_handler, true);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            ConsoleHelper.SetConsoleFont(2);
            Console.OutputEncoding = Encoding.Unicode;
            new Window();

            BufferSizeTitle();

            Story();

            Username();

            int life = 30;

            while (true)
            {
                DrawFigureAtPosition(currentAirplainPosX, currentAirplainPosY, ConsoleColor.DarkGreen, airplain);
                Hero.UserAiplainKeysOptions();

                if (bossLevel)
                {
                    if (boss.Count == 0)
                    {
                        CreateBoss(3, ConsoleColor.White);
                        counter++;
                    }
                    for (int i = 0; i < boss.Count; i++)
                    {
                        boss[i].Move();
                        boss[i].Shoot();
                    }    
                }
                else if(counter == 0 || !bossLevel)
                {
                    if (enemies.Count == 0)
                    {
                        CreateLittleEnemies(7, colors[counter % 3]);
                        counter++;    
                    }

                    for (int i = 0; i < enemies.Count; i++)
                    {
                        enemies[i].Move();
                        enemies[i].Shoot();
                    }
                    
                }
                for (int i = 0; i < enemyBullets.Count; i++)
                {
                    MoveEnemyBullet(enemyBullets[i]);
                    if (KillHero(enemyBullets[i]))
                    {
                        if (life / 10 != life - 1 / 10)
                        {
                            GoOnline.die((life / 10) + 1).Wait();
                        }
                        life--;
                        if (life <= 0)
                        {
                            PrintLifeAndLives(0);
                            GameOver();
                            break;
                        }
                    }
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
                PrintLifeAndLives(life);
                speed = score / 50;
                Thread.Sleep(50 - speed);
            }
        }
    }
}