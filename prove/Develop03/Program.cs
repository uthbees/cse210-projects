class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture(new Reference("1 Nephi", 2, 14, 15),
            "And it came to pass that my father did speak unto them in the valley of Lemuel, with power, being filled " +
            "with the Spirit, until their frames did shake before him. And he did confound them, that they durst not " +
            "utter against him; wherefore, they did as he commanded them. And my father dwelt in a tent."
        );

        bool looping = true;
        while (looping)
        {
            Console.Clear();
            scripture.Display();
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish.");

            string input = Console.ReadLine();
            if (input == "quit" || scripture.AllWordsAreHidden())
            {
                looping = false;
            }
            else
            {
                scripture.HideRandomWords(3);
            }
        }
    }
}
