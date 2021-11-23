using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    class Laba5
    {
        public static void MethodGradientSpusk()
        {
            double E = 0.01;
            double alfa = 0.001;
            double x1 = 0;
            double x2 = 0;
            double y1, y2;
            double fx = Func(x1, x2);
            var grad = FuncGradient(x1, x2);
            while (Math.Abs(getNorma(grad)) > E)
            {
                y1 = x1 - alfa * grad.Key;
                y2 = x2 - alfa * grad.Value;
                grad = FuncGradient(x1, x2);
                double fy = Func(y1, y2);
                if (fy < fx)
                {
                    x1 = y1;
                    x2 = y2;
                    fx = fy;
                }
                else
                {
                    alfa /= 2;
                }
            }
            Console.WriteLine($"x1 = {x1:f4} x2 = {x2:f4}");
        }

        public static double Func(double x1, double x2)
        {
            return 211 * x1 * x1 - 420 * x1 * x2 + 211 * x2 * x2 - 192 * x1 + 50 * x2 - 25;
        }

        public static KeyValuePair<double, double> FuncGradient(double x1, double x2)
        {
            return new KeyValuePair<double, double>(422 * x1 - 420 * x2 - 192, 422 * x2 - 420 * x1 + 50);
        }
        public static double getNorma(KeyValuePair<double, double> gradient)
        {
            return Math.Sqrt(Math.Pow(gradient.Key, 2) + Math.Pow(gradient.Value, 2));
        }
    }
}
