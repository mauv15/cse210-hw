using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create some activities
        var running = new Running("03 Nov 2022", 30, 3.0);  // Running for 30 min, 3 miles
        var cycling = new Cycling("03 Nov 2022", 45, 15.0); // Cycling for 45 min, 15 mph
        var swimming = new Swimming("03 Nov 2022", 40, 20); // Swimming for 40 min, 20 laps

        // Create a list to hold the activities
        List<Activity> activities = new List<Activity>
        {
            running,
            cycling,
            swimming
        };

        // Display the summary for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
