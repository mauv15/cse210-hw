using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            int pointsEarned = _goals[goalIndex].RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"You earned {pointsEarned} points!");
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    public void ShowGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"\nCurrent Score: {_score}");
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                string type = parts[0];

                switch (type)
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])) { });
                        if (bool.Parse(parts[4])) ((SimpleGoal)_goals[^1]).RecordEvent();
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;
                    case "ChecklistGoal":
                        var checklistGoal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                        for (int c = 0; c < int.Parse(parts[6]); c++) checklistGoal.RecordEvent();
                        _goals.Add(checklistGoal);
                        break;
                }
            }

            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    public int GetGoalCount()
    {
        return _goals.Count;
    }
}
