using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    class Laba3
    {
        public struct Point
        {
            public double x;
            public double y;
            
            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public static void MethodAveragePoint(double a, double b, double E)
        {
            double x = (a + b) / 2d;
            double past = 0d;
            while (Math.Abs(FuncDef(x)) >= E)
            {
                if (FuncDef(x) > 0)
                {
                    b = x;
                }
                else if (FuncDef(x) < 0)
                {
                    a = x;
                }
                else 
                {
                    break;
                }
                if (past == x)
                {
                    break;
                }
                else
                {
                    past = x;
                }
                x = (a + b) / 2d;
            }
            Console.WriteLine($"x = {x:f4} y = {Func(x):f4}");
        }

        public static void MethodHord(double a, double b, double E)
        { 
            double aDef = FuncDef(a);
            double bDef = FuncDef(b);
            double x = a - (aDef / (aDef - bDef)) * (a - b);
            double xDef = FuncDef(x);
            while (Math.Abs(xDef) >= E)
            {
                if (aDef * bDef >= 0)
                {
                    if (aDef > 0)
                    {
                        x = a;
                        break;
                    }
                    if (aDef < 0)
                    {
                        x = b;
                        break;
                    }
                }
                if (xDef > 0)
                {
                    b = x;
                    bDef = xDef;
                }
                else if (FuncDef(x) < 0)
                {
                    a = x;
                    aDef = xDef;
                }
                
                x = a - (aDef / (aDef - bDef)) * (a - b);
                xDef = FuncDef(x);
            }
            Console.WriteLine($"x = {x:f4} y = {Func(x):f4}");
        }

        public static void MethodNewton(double a, double b, double E)
        {
            double x = a - FuncDef(a) / FuncDefTwo(a);
            while (Math.Abs(FuncDefTwo(x)) >= E)
            {
                x = x - FuncDef(x) / FuncDefTwo(x);
                if (FuncDef(x) == 0)
                {
                    break;
                }
            }
            Console.WriteLine($"x = {x:f4} y = {Func(x):f4}");
        }

        public static void MethodLomanih(double a, double b, double E)
        {
            double x = (a + b) / 2;
            double L = LFunc(a, b, E);
            double x1 = (1 / (2 * L)) * (Func2(a) - Func2(b) + L * (a + b));
            double y1 = (1 / (2 * L)) * (Func2(a) + Func2(b) + L * (a + b));
            double gX = Func2(x1) - L * (x1 - x);
            double P0;
            if (x1 < x)
            {
                P0 = Func2(a) - L * (x1 - a);
            }
            else
                P0 = Func2(b) + L * (x1 - b);
            double P1 = gX < P0? P0 : gX;
            double delta = (1 / (2 * L)) * (Func2(x1) - y1);
            double x1S = x1 - delta;
            double x2S = x1 + delta;
            List<Point> lst = new List<Point>();
            lst.Add(new Point(x1S, P1));
            lst.Add(new Point(x1S, P1));
            x = x1S;
            double pastMin = double.MaxValue;
            while (true)
            {
                double min = double.MaxValue;
                int minI = -1;
                
                for (int i = 0; i < lst.Count; i++)
                {
                    if (min > lst[i].y)
                    {
                        min = lst[i].y;
                        minI = i;
                    }
                }
                if (Math.Abs(pastMin - min) <= 2 * L * delta)
                {
                    break;
                }
                pastMin = min;
                x1 = lst[minI].x;

                gX = Func2(x1) - L * (x1 - x);
                if (x1 < x)
                {
                    P0 = Func2(a) - L * (x1 - a);
                }
                else
                {
                    P0 = Func2(b) + L * (x1 - b);
                }
                y1 = lst[minI].y;
                P1 = gX < P0 ? P0 : gX;

                delta = (1 / (2 * L)) * (Func2(x1) - y1);
                x1S = x1 - delta;
                x2S = x1 + delta;
                lst.Add(new Point(x1S, P1));
                lst.Add(new Point(x1S, P1));
                x = lst[minI].x;
            }
            Console.WriteLine($"x = {x:f4} y = {Func2(x):f4}");
        }


        static double Func(double x)
        {
            return x + (1d / (x * x));
        }
        static double FuncDef(double x)
        {
            return 1d - (2d / (x * x * x));
        }
        static double FuncDefTwo(double x)
        {
            return 6d/(Math.Pow(x, 4));
        }

        static double Func2(double x)
        {
            return (x + 2) * (x + 2) * (x - 1) * (x - 2) - 1;
        }
        static double Func2Def(double x)
        {
            return 4 * x * x * x + 3 * x * x - 12 * x - 4;
        }
        static double LFunc(double a, double b, double E)
        {
            double x = a;
            double maxX = a;
            double max = Func2Def(maxX);
            while (x <= b)
            {
                if (Math.Abs(max) < Math.Abs(Func2Def(x)))
                {
                    max = Func2Def(x);
                    maxX = x;
                }
                x += E * 10;
            }
            return maxX;
        }
    }
}
