﻿using System;
using System.Threading;
using AirplaneNext = AirplaneShooterNext.AirplaneNext;

namespace AirplainShooterNext
{
    public class LittleEnemy
    {
        private int x;
        private int y;
        private ConsoleColor color;


        public char[,] Shape = {  
                                {'*', ' ', '*', ' ', '*'},
                                {' ', '*', '*', '*', ' '},
                                {' ', '*', 'o', '*', ' '},
                                {'*', ' ', 'V', ' ', '*'}  
                               };
        public  int X { get; set; }
        public  int Y { get; set; }
        public  ConsoleColor Color { get; set; }

        public LittleEnemy(int x, int y, ConsoleColor color, char[,] shape)
        {
            this.X = x;
            this.Y = y;
            this.Color = color;
            this.Shape = shape;
        }

        public void Move()
        {
            switch (AirplaneNext.goLeft)
            {
                case true:
                    if (X > 0)
                    {
                        AirplaneNext.DrawFigureAtPosition(--X, Y, ConsoleColor.DarkYellow, Shape);
                        AirplaneNext.DrawFigureAtPosition(X + 5, Y, ConsoleColor.DarkYellow, AirplaneNext.littleAimEmpty);
                    }
                    else
                    {
                        AirplaneNext.goLeft = false;
                    }
                    break;
                case false:
                    if (X < 75)
                    {
                        AirplaneNext.DrawFigureAtPosition(++X, Y, ConsoleColor.DarkYellow, Shape);
                        if (X > 5)
                        {
                            AirplaneNext.DrawFigureAtPosition(X - 1, Y, ConsoleColor.DarkYellow, AirplaneNext.littleAimEmpty);
                        }
                        else
                        {
                            AirplaneNext.DrawFigureAtPosition(X - 1, Y, ConsoleColor.DarkYellow, AirplaneNext.littleAimEmpty);
                        }
                    }
                    else
                    {
                        AirplaneNext.goLeft = true;
                    }
                    break;
            }
        }

        public void Shoot()
        {
            int random = AirplaneNext.randNum.Next(0, 20);
            if (random == 10)
            {
                AirplaneNext.EnemyShooting(X + 2, Y + 3, ConsoleColor.White, 'Y');
                Thread.Sleep(50);
                AirplaneNext.EnemyShooting(X + 2, Y + 2, ConsoleColor.White, ' ');    
            }
        }
    }
}
