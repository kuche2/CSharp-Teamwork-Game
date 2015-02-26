using System;
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
            switch (AirplaneNext.direction)
            {
                case "left":
                    if (X > 0)
                    {
                        AirplaneNext.DrawFigureAtPosition(--X, Y, ConsoleColor.DarkYellow, Shape);
                        AirplaneNext.DrawFigureAtPosition(X + 5, Y, ConsoleColor.DarkYellow, AirplaneNext.littleAimEmpty);
                        
                    }
                    else
                    {
                        AirplaneNext.direction = "right";
                    }
                    break;
                case "right":
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
                        AirplaneNext.direction = "left";
                    }
                    break;
            }
        }
    }
}
