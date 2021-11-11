using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    class Laba2
    {
        public static void MethodDechotomia(double a, double b, double E)
        {
            double d = E / 10;
            double x, x1, x2, f1, f2;

            while ((b - a) / 2 >= E)
            {
                x1 = (a + b - d) / 2;
                x2 = (a + b + d) / 2;
                f1 = Func(x1);
                f2 = Func(x2);
                if (f1 <= f2)
                {
                    b = x2;
                }
                else
                {
                    a = x1;
                }
            }
            x = (a + b) / 2;
            Console.WriteLine($"x = {x:f3} y = {Func(x):f4}");
        }

        public static void MethodFind(double a, double b, double E)
        {
            double h = (b - a) / 4;
            double x1 = a;
            double x2 = a + h;
            double f1 = Func(x1);
            double f2 = Func(x2);
            while (true)
            {
                if (f1 > f2)
                {
                    x1 = x2;
                    f1 = f2;
                    if (a > x1 && b < x1)
                    {
                        break;
                    }
                    x2 += h;
                    f2 = Func(x2);
                }
                else if (Math.Abs(h) < E)
                {
                    break;
                }
                else
                {
                    h = -h / 4;
                    x1 = x2;
                    f1 = f2;
                    x2 += h;
                    f2 = Func(x2);
                }
            }
            Console.WriteLine($"x = {x1:f3} y = {f1:f4}");
        }

        public static void MethodGoldSech(double a, double b, double E)
        {
            double r = (Math.Sqrt(5) - 1) / 2;
            double t = (3 - Math.Sqrt(5)) / 2;
            double x2 = a + r * (b - a);
            double x1 = a + b - x2;
            double f1 = Func(x1);
            double f2 = Func(x2);
            double En = (b - a) / 2;
            double x;

            while (En > E)
            {
                if (f1 <= f2)
                {
                    b = x2;
                    x2 = x1;
                    f2 = f1;
                    x1 = b - r * (b - a);
                    f1 = Func(x1);
                }
                else
                {
                    a = x1;
                    x1 = x2;
                    f1 = f2;
                    x2 = b - t * (b - a);
                    f2 = Func(x2);
                }
                En *= r;
            }
            x = (a + b) / 2;

            Console.WriteLine($"x = {x:f3} y = {Func(x):f4}");

        }

        public static void MethodParabol(double a, double b, double E)
        {
            double x1 = a;
            double x2 = (a + b) / 2;
            double x3 = b;
            double past = 1;
            double x = 0d;
            while (Math.Abs(past - x) > E)
            {
                if (x1 != x2 && x1 != x3 && x2 != x3)
                {
                    double a1 = (Func2(x2) - Func2(x1)) / (x2 - x1);
                    double a2 = (1 / (x3 - x2)) * ((Func2(x3) - Func2(x1)) / (x3 - x1) - (Func2(x2) - Func2(x1)) / (x2 - x1));
                    past = x;
                    x = (1d / 2) * (x1 + x2 - (a1 / a2));
                    List<double> x_mass = new List<double> { x1, x2, x3, x };
                    x_mass.Sort();
                    for (int i = 0; i < 2; i++)
                    {
                        if (Func2(x_mass[i]) >= Func2(x_mass[i + 1]) && Func2(x_mass[i + 1]) <= Func2(x_mass[i + 2]))
                        {
                            x1 = x_mass[i];
                            x2 = x_mass[i + 1];
                            x3 = x_mass[i + 2];
                        }
                    }
                }
            }
            Console.WriteLine($"x = {x:f4} y = {Func2(x):f4}");
        }

        static double Func(double x)
        {
            return x * x - 10d * x + 5d;
        }

        static double Func2(double x)
        {
            return Math.Pow(x, 3) + 3 * x * x - 2 * x + 1;
        }
    }
}
