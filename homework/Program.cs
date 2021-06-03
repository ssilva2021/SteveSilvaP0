using System;

namespace homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("What is your age?");
            String age = Console.ReadLine();
            Console.WriteLine("What is your name?");
            String name = Console.ReadLine();
            Console.WriteLine($"Hello {name}! You are {age} years old");
        }
    }
}
