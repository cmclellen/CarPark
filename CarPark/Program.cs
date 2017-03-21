using System;

namespace CarPark
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new UICoordinator(Console.In, Console.Out)
                .Run();
        }
    }
}