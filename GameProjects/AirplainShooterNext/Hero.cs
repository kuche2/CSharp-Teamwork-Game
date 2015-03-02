using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirplaneShooterNext;
namespace AirplainShooterNext
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
}
