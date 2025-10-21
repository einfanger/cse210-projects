using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Alma", 7, 11, 12);
        string text = "And he shall go forth, suffering pains and afflictions and temptations of every kind; " +
                      "and this that the word might be fulfilled which saith he will take upon him the pains and the sicknesses of his people. " +
                      "And he will take upon him death, that he may loose the bands of death which bind his people; " +
                      "and he will take upon him their infirmities, that his bowels may be filled with mercy, " +
                      "according to the flesh, that he may know according to the flesh how to succor his people according to their infirmities.";

        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press ENTER to hide more words or type 'quit' to end.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine("🔥 You did it! Every word is hidden. You’ve got this scripture down! 🔥");
                break;
            }

            scripture.HideRandomWords();
        }
    }
}
