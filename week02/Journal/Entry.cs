using System;

public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public void Display()
    {
        Console.WriteLine($"{Date} - {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine(new string('-', 50));
    }
}
