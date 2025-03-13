using System;
using System.Collections.Generic;

public class Resume
{
    // Member variables
    private string _name;
    private List<Job> _jobs;

    // Constructor to start the name and the list of jobs
    public Resume(string name)
    {
        _name = name;
        _jobs = new List<Job>();
    }

    // Method to add a job to the resume
    public void AddJob(Job job)
    {
        _jobs.Add(job);
    }

    // Method to display resume details
    public void DisplayResume()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (var job in _jobs)
        {
            job.DisplayJobDetails();  // Calling the Job class method to display job details
        }
    }
}
