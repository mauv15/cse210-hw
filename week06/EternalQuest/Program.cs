using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine("\n--- Eternal Quest Menu ---");
            manager.ShowScore();
            Console.WriteLine("\n1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal(manager);
                    break;
                case "2":
                    manager.ShowGoals();
                    break;
                case "3":
                    RecordGoalEvent(manager);
                    break;
                case "4":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    manager.SaveToFile(saveFile);
                    break;
                case "5":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    manager.LoadFromFile(loadFile);
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void CreateNewGoal(GoalManager manager)
    {
        Console.WriteLine("\nWhat type of goal would you like to create?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose an option: ");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points for this goal: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                manager.AddGoal(new SimpleGoal(name, description, points));
                break;
            case "2":
                manager.AddGoal(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times to complete? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                manager.AddGoal(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    static void RecordGoalEvent(GoalManager manager)
    {
        manager.ShowGoals();
        Console.Write("Which goal did you accomplish? (Enter number): ");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            manager.RecordEvent(index - 1);
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
}
