using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1 - Chain of Responsibility");
            Console.WriteLine("2 - Mediator");
            Console.WriteLine("5 - Memento");
            Console.WriteLine("0 - Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: Task1.Task1.Run(); break;
                case 2: Task2.Task2.Run(); break;
                case 5: Task5.Task5.Run(); break;
            }
        }
    }
}