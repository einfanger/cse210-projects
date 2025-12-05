public class InstructionStep
{
    public int StepNumber { get; set; }
    public string Text { get; set; }

    public InstructionStep(int stepNumber, string text)
    {
        StepNumber = stepNumber;
        Text = text;
    }
}
