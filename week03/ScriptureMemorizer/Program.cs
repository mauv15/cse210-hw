using System;

class Program
{
    static void Main()
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);

        string scriptureText = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        
        Scripture scripture = new Scripture(reference, scriptureText);

        while (!scripture.IsCompletelyHidden())
        {
            scripture.Display(); 

            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "quit")
                break;

            scripture.HideWords(3); 
        }

        scripture.Display();
        Console.WriteLine("\nProgram ended.");
    }
}
