using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing", "This activity will help you relax by guiding you through slow breathing.")
    { }

    public void Run()
    {
        DisplayStartingMessage();

        for (int i = 0; i < _duration / 6; i++)
        {
            Console.Write("\nBreathe in... ");
            ShowCountDown(3);
            Console.Write("Now breathe out... ");
            ShowCountDown(3);
        }

        DisplayEndingMessage();
    }
}
