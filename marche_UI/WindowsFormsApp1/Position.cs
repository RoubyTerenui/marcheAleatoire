﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1
{
    class Position
    {
        private int x;
        private int y;
        
        // Constructor
        public Position(Position position)
        {
            this.X = (int)position.X;
            this.Y = (int)position.Y;
        }
        public Position()
        {
            this.X = 0;
            this.Y = 0;
        }
        public Position(int x_, int y_)
        {
            this.X = x_;
            this.Y = y_;
        }
        // Getters and setters
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        // Other functions

        public int getIndex(int i)
        {
            if (i == 0)
            {
                return X;
            }
            else
            {
                return Y;
            }
        }

        public void setIndex(int i,int value)
        {
            if (i == 0)
            {
                X=value;
            }
            else
            {
                Y=value;
            }
        }
        public override bool Equals(object obj)
        {
            var position = obj as Position;
            return position != null &&
                   x == position.x &&
                   y == position.y;
        }


        public double distance(Position endPosition)
        {
            double res;
            res =Math.Pow(X - endPosition.X, 2) + Math.Pow(Y - endPosition.Y, 2);
            return res;
        }
    }
}
