using System;

namespace Task1
{
    public static class Task1
    {
        public static void Run()
        {
            var op = new OperatorHandler();
            var tech = new TechSupportHandler();
            var senior = new SeniorSupportHandler();
            var admin = new AdminSupportHandler();

            op.SetNext(tech);
            tech.SetNext(senior);
            senior.SetNext(admin);

            while (true)
            {
                Console.WriteLine("\nEnter problem level (1-4), 0 to exit:");
                int level = int.Parse(Console.ReadLine());

                if (level == 0) break;

                op.Handle(level);
            }
        }
    }

    abstract class SupportHandler
    {
        protected SupportHandler next;

        public void SetNext(SupportHandler handler)
        {
            next = handler;
        }

        public abstract void Handle(int level);
    }

    class OperatorHandler : SupportHandler
    {
        public override void Handle(int level)
        {
            Console.WriteLine("Operator: checking...");

            if (level == 1)
                Console.WriteLine("Solved by Operator");
            else
                next?.Handle(level);
        }
    }

    class TechSupportHandler : SupportHandler
    {
        public override void Handle(int level)
        {
            Console.WriteLine("Tech Support: checking...");

            if (level == 2)
                Console.WriteLine("Solved by Tech Support");
            else
                next?.Handle(level);
        }
    }

    class SeniorSupportHandler : SupportHandler
    {
        public override void Handle(int level)
        {
            Console.WriteLine("Senior Support: checking...");

            if (level == 3)
                Console.WriteLine("Solved by Senior Support");
            else
                next?.Handle(level);
        }
    }

    class AdminSupportHandler : SupportHandler
    {
        public override void Handle(int level)
        {
            if (level == 4)
                Console.WriteLine("Solved by Admin");
            else
                Console.WriteLine("No handler found → restart menu");
        }
    }
}