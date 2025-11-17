using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class QuestManager
{
    private List<Goal> _goals = new();
    private int _score = 0;

    public int Score => _score;

    public void AddGoal(Goal g) => _goals.Add(g);

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet!");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].Display()}");
    }

    public void RecordEvent(int index)
    {
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid number.");
            return;
        }

        int earned = _goals[index].RecordEvent();
        _score += earned;

        Console.WriteLine($"Total Score: {_score}");
    }

    public void Save(string filename)
    {
        List<GoalData> data = new();

        foreach (var g in _goals)
            data.Add(g.ToData());

        var wrapper = new SaveWrapper
        {
            Score = _score,
            Goals = data
        };

        File.WriteAllText(filename, JsonSerializer.Serialize(wrapper));
        Console.WriteLine("Saved.");
    }

    public void Load(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();

        string json = File.ReadAllText(filename);
        SaveWrapper wrapper = JsonSerializer.Deserialize<SaveWrapper>(json);

        _score = wrapper.Score;

        foreach (var gd in wrapper.Goals)
        {
            Goal g;

            switch (gd.Type)
            {
                case "Simple":
                    g = new SimpleGoal(gd.Title, gd.Description, gd.Points);
                    if (gd.IsComplete)
                        g.RecordEvent();
                    break;

                case "Eternal":
                    var eg = new EternalGoal(gd.Title, gd.Description, gd.Points);
                    for (int i = 0; i < gd.TimesRecorded; i++)
                        eg.RecordEvent();
                    g = eg;
                    break;

                case "Checklist":
                    var cg = new ChecklistGoal(gd.Title, gd.Description, gd.Points, gd.RequiredCount, gd.BonusPoints);
                    for (int i = 0; i < gd.CurrentCount; i++)
                        cg.RecordEvent();
                    g = cg;
                    break;

                default:
                    continue;
            }

            _goals.Add(g);
        }

        Console.WriteLine("Loaded.");
    }

    private class SaveWrapper
    {
        public int Score { get; set; }
        public List<GoalData> Goals { get; set; }
    }
}
