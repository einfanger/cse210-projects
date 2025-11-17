using System;

public class EternalGoal : Goal
{
    private int _timesRecorded;

    public int TimesRecorded => _timesRecorded;

    public EternalGoal(string title, string description, int points)
        : base(title, description, points)
    {
        _timesRecorded = 0;
    }

    public override int RecordEvent()
    {
        _timesRecorded++;
        Console.WriteLine($"Eternal '{Title}' recorded. +{Points} pts");
        return Points;
    }

    public override string Display()
    {
        return $"[∞] Eternal: {Title} — {Description} (Recorded {TimesRecorded}x)";
    }

    public override GoalData ToData()
    {
        return new GoalData
        {
            Type = "Eternal",
            Title = Title,
            Description = Description,
            Points = Points,
            TimesRecorded = TimesRecorded
        };
    }
}
