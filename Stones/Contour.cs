using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stones
{
    /// <summary>
    /// Класс для хранения точки принадлежащей контуру
    /// </summary>
    public class CountorPoint : IComparable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public CountorPoint(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public int CompareTo(object obj)
        {
            CountorPoint otherTemperature = obj as CountorPoint;
            if (otherTemperature == null)
                throw new ArgumentException("Object is not a Temperature");

            if (otherTemperature.X > this.X || otherTemperature.Y > this.Y)
                return 1;
            else
                if (otherTemperature.X == this.X || otherTemperature.Y == this.Y)
                    return 0;
            
            return -1;
        }
    }

    /// <summary>
    /// Класс представляющий контур объекта
    /// </summary>
    public class Contour
    {
        private List<CountorPoint> Points = new List<CountorPoint>();

        public Contour()
        {
 
        }

        /// <summary>
        /// Проверяет, принадлежит ли точка контуру
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool Contain(CountorPoint point)
        {
            return Contain(point.X, point.Y);
        }

        /// <summary>
        /// Проверяет, принадлежит ли точка контуру
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public bool Contain(int X, int Y)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                if (Points[i].X == X && Points[i].Y == Y)
                {
                    return true;
                }
            }

            return false;
        }

        public System.Drawing.Rectangle GetRectangle()
        {
            int MinX, MinY, MaxX, MaxY;
            MinX = MinY = MaxX = MaxY = 0;
            bool MinXSet, MinYSet, MaxXSet, MaxYSet;
            MinXSet = MinYSet = MaxXSet = MaxYSet = false;
            
            for (int i = 0; i < Points.Count; i++)
            {
                if (MinXSet)
                {
                    if (Points[i].X < MinX)
                    {
                        MinX = Points[i].X;
                    }
                }
                else
                {
                    MinX = Points[i].X;
                    MinXSet = true;
                }

                if (MaxXSet)
                {
                    if (Points[i].X > MaxX)
                    {
                        MaxX = Points[i].X;
                    }
                }
                else
                {
                    MaxX = Points[i].X;
                    MaxXSet = true;
                }

                if (MinYSet)
                {
                    if (Points[i].Y < MinY)
                    {
                        MinY = Points[i].Y;
                    }
                }
                else
                {
                    MinY = Points[i].Y;
                    MinYSet = true;
                }

                if (MaxYSet)
                {
                    if (Points[i].Y > MaxY)
                    {
                        MaxY = Points[i].Y;
                    }
                }
                else
                {
                    MaxY = Points[i].Y;
                    MaxYSet = true;
                }
            }

            return new System.Drawing.Rectangle(MinX, MinY, MaxX - MinX, MaxY - MinY);
        }

        public void Add(CountorPoint Item)
        {
            Points.Add(Item);    
        }
    }
}
