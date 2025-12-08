public class InstructionStep
{
    public int StepNumber { get; set; }
    public string Text { get; set; }

    public InstructionStep(int number, string text)
    {
        StepNumber = number;
        Text = text;
    }
}
