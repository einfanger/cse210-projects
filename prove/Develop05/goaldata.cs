public class GoalData
{
    public string Type { get; set; } = "";
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public int Points { get; set; }
    public bool IsComplete { get; set; }

    public int RequiredCount { get; set; }
    public int CurrentCount { get; set; }
    public int BonusPoints { get; set; }

    public int TimesRecorded { get; set; }
}
