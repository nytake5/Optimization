using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    class Laba3
    {
        

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

        public static void MethodLomanih(double a, double b, double E = 0.01)
        {
            double L = LFunc(a, b, E);
            double x, y, f;
            x = (1 / (2 * L)) * (Func2(a) - Func2(b) + L * (a + b)); ;
            y = (1d / 2) * (Func2(a) + Func2(b) + L * (a - b));
            double delta1, delta2;
            delta1 = (1 / (2 * L)) * (Func2(x) - y);
            delta2 = 2 * L * delta1;
            while (delta2 > E)
            {
                double x1, x2;
                x1 = x - delta1;
                x2 = x + delta1;
                if (Func2(x1) < Func2(x2))
                {
                    x = x1;
                }
                else
                {
                    x = x2;
                }
                f = (1 / 2d) * (Func2(x) + y);
                delta1 = 1 / (2 * L) * (Func2(x) - y);
                delta2 = 2 * L * delta1;
                y = f;
            }
            Console.WriteLine($"x = {x:f4} y = {Func2(x):f4}");
        }
        //метод для поиска константы липшица
        static double LFunc(double a, double b, double E)
        {
            double res, L = 0;
            for (double i = a + E; i <= b; i += E)
            {
                res = Math.Abs(Func2(i + E) - Func2(i)) / E;
                if (res > a)
                {
                    L = res;
                }
            }
            return L;
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
        
    }
}
