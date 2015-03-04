using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirplaneShooterNext;

namespace AirplainShooterNext
{
    public class BigEnemy
    {
        private int x;
        private int y;
        private ConsoleColor color;
        private int blood;


        public char[,] Shape { get; set; }

        public  int X { get; set; }
        public  int Y { get; set; }
        public int Blood { get; set; }
        public  ConsoleColor Color { get; set; }

        public BigEnemy(int x, int y, ConsoleColor color, char[,] shape, int blood)
        {
            this.X = x;
            this.Y = y;
            this.Color = color;
            this.Shape = shape;
            this.Blood = blood;
        }

        public void Move()
        {
            switch (AirplaneNext.goLeft)
            {
                case true:
                    if (X > 0)
                    {
                        AirplaneNext.DrawFigureAtPosition(--X, Y, Color, Shape);
                        AirplaneNext.DrawFigureAtPosition(X + 11, Y, Color, AirplaneNext.bigAimEmpty);
                    }
                    else
                    {
                        AirplaneNext.goLeft = false;
                    }
                    break;
                case false:
                    if (X < 75)
                    {
                        AirplaneNext.DrawFigureAtPosition(++X, Y, Color, Shape);
                        if (X > 11)
                        {
                            AirplaneNext.DrawFigureAtPosition(X - 1, Y, Color, AirplaneNext.bigAimEmpty);
                        }
                        else
                        {
                            AirplaneNext.DrawFigureAtPosition(X - 1, Y, Color, AirplaneNext.bigAimEmpty);
                        }
                    }
                    else
                    {
                        AirplaneNext.goLeft = true;
                    }
                    break;
            }
            int random = AirplaneNext.randNum.Next(0, 50);
            if (random == 10)
            {
                AirplaneNext.DrawFigureAtPosition(X, ++Y, Color, Shape);
                AirplaneNext.DrawFigureAtPosition(X, Y - 1, Color, AirplaneNext.bigAimEmptyTop);
            }
        }

        public void Shoot()
        {
            int random = AirplaneNext.randNum.Next(0, 30);
            if (random == 10)
            {
                AirplaneNext.EnemyBullet enemyBull = new AirplaneNext.EnemyBullet(X + 2, Y + 3, ConsoleColor.Black, 'Y');
                AirplaneNext.EnemyBullet enemyBull1 = new AirplaneNext.EnemyBullet(X + 5, Y + 3, ConsoleColor.Black, 'Y');
                AirplaneNext.EnemyBullet enemyBull2 = new AirplaneNext.EnemyBullet(X + 8, Y + 3, ConsoleColor.Black, 'Y');
                AirplaneNext.enemyBullets.Add(enemyBull);
                AirplaneNext.enemyBullets.Add(enemyBull1);
                AirplaneNext.enemyBullets.Add(enemyBull2);
                Audio.enemyshot();
            }
        }
    }
}
