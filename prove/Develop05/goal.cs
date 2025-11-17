using System;

public abstract class Goal
{
    private string _title;
    private string _description;
    private int _points;
    private bool _isComplete;

    public string Title => _title;
    public string Description => _description;
    public int Points => _points;
    public bool IsComplete => _isComplete;

    protected void SetComplete(bool v) => _isComplete = v;
    protected void SetDescription(string d) => _description = d;
    protected void SetTitle(string t) => _title = t;
    protected void SetPoints(int p) => _points = p;

    protected Goal() {}

    protected Goal(string title, string description, int points)
    {
        _title = title;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    public abstract int RecordEvent();
    public abstract string Display();
    public abstract GoalData ToData();
}
