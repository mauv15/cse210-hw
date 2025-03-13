using System;
using System.IO;

class Program
{
    private static Journal journal = new Journal();
    private static Prompt prompt = new Prompt();

    static void Main(string[] args)
    {
        ShowMenu();
    }

    static void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Quit");

            Console.Write("Select an option (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteEntry();
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    SaveJournal();
                    break;
                case "4":
                    LoadJournal();
                    break;
                case "5":
                    Quit();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void WriteEntry()
    {
        string randomPrompt = prompt.GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {randomPrompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Entry entry = new Entry(randomPrompt, response, date);
        journal.AddEntry(entry);
    }

    static void DisplayJournal()
    {
        journal.DisplayEntries();
    }

    static void SaveJournal()
    {
        Console.Write("Enter the filename to save the journal: ");
        string filename = Console.ReadLine();
        try
        {
            using (StreamWriter file = new StreamWriter(filename))
            {
                foreach (var entry in journal.Entries)
                {
                    file.WriteLine($"{entry.Date} - {entry.Prompt}");
                    file.WriteLine(entry.Response);
                    file.WriteLine(new string('-', 50));
                }
            }
            Console.WriteLine($"Journal saved to {filename}.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving journal: {e.Message}");
        }
    }

    static void LoadJournal()
    {
        Console.Write("Enter the filename to load the journal: ");
        string filename = Console.ReadLine();
        try
        {
            using (StreamReader file = new StreamReader(filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split(new string[] { " - " }, StringSplitOptions.None);
                    string date = parts[0];
                    string promptText = parts[1];
                    string response = file.ReadLine();
                    file.ReadLine(); // Skip the separator line
                    Entry entry = new Entry(promptText, response, date);
                    journal.AddEntry(entry);
                }
            }
            Console.WriteLine($"Journal loaded from {filename}.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading journal: {e.Message}");
        }
    }

    static void Quit()
    {
        Console.WriteLine("Exiting the journal program. Goodbye!");
    }
}
