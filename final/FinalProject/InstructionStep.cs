using System;

public class InstructionStep
{
    public int StepNumber { get; set; }
    public string Description { get; set; }

    public override string ToString()
    {
        return $"Step {StepNumber}: {Description}";
    }
}
