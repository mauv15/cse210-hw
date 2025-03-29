using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Introduction to C#", "Dani Krossing", 340);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "I love this content!"));

        Video video2 = new Video("Every single feature of C# in 10 minutes", "Train To Code", 590);
        video2.AddComment(new Comment("David", "This was really insightful."));
        video2.AddComment(new Comment("Eve", "I never knew about these features!"));
        video2.AddComment(new Comment("Frank", "Clear and concise, thank you."));

        Video video3 = new Video("5 Design Patterns That Are ACTUALLY Used By Developers", "Alex Hyett", 566);
        video3.AddComment(new Comment("Grace", "Super useful for my project!"));
        video3.AddComment(new Comment("Hank", "I need to rewatch this!"));
        video3.AddComment(new Comment("Ivy", "Best explanation I've seen."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}
