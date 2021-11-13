using System;
using System.Collections.Generic;

namespace Optimization
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double E = 0.01;
            /*
            Console.WriteLine("Метод Дихотомии");
            Laba2.MethodDechotomia(a, b, E);
            Console.WriteLine("Метод поразрядного поиска");
            Laba2.MethodFind(a, b, E);
            Console.WriteLine("Метод золотого сечения");
            Laba2.MethodGoldSech(a, b, E);
            Console.WriteLine("Метод парабол");
            Laba2.MethodParabol(a, b, E);*/
            Laba3.MethodLomanih(a, b, E);
        }

        
    }
}
