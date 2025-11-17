using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string title, string description, int points)
        : base(title, description, points) { }

    public override int RecordEvent()
    {
        if (IsComplete)
        {
            Console.WriteLine("That goal is already completed.");
            return 0;
        }

        SetComplete(true);
        Console.WriteLine($"Completed '{Title}' +{Points} pts");
        return Points;
    }

    public override string Display()
    {
        string mark = IsComplete ? "[X]" : "[ ]";
        return $"{mark} Simple: {Title} — {Description}";
    }

    public override GoalData ToData()
    {
        return new GoalData
        {
            Type = "Simple",
            Title = Title,
            Description = Description,
            Points = Points,
            IsComplete = IsComplete
        };
    }
}
