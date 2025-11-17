using System;

public class ChecklistGoal : Goal
{
    private int _requiredCount;
    private int _currentCount;
    private int _bonusPoints;

    public int RequiredCount => _requiredCount;
    public int CurrentCount => _currentCount;
    public int BonusPoints => _bonusPoints;

    public ChecklistGoal(string title, string description, int points, int required, int bonus)
        : base(title, description, points)
    {
        _requiredCount = required;
        _currentCount = 0;
        _bonusPoints = bonus;
    }

    public override int RecordEvent()
    {
        if (IsComplete)
        {
            Console.WriteLine("Checklist already completed.");
            return 0;
        }

        _currentCount++;
        int earned = Points;

        Console.WriteLine($"Checklist '{Title}' progress: {_currentCount}/{_requiredCount}  +{Points} pts");

        if (_currentCount >= _requiredCount)
        {
            SetComplete(true);
            earned += _bonusPoints;
            Console.WriteLine($"Completed checklist! Bonus +{_bonusPoints} pts");
        }

        return earned;
    }

    public override string Display()
    {
        string mark = IsComplete ? "[X]" : "[ ]";
        return $"{mark} Checklist: {Title} — {Description} ({_currentCount}/{_requiredCount})";
    }

    public override GoalData ToData()
    {
        return new GoalData
        {
            Type = "Checklist",
            Title = Title,
            Description = Description,
            Points = Points,
            RequiredCount = RequiredCount,
            CurrentCount = CurrentCount,
            BonusPoints = BonusPoints,
            IsComplete = IsComplete
        };
    }
}
