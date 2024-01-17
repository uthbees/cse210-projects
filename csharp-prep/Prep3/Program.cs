using System;

class Program
{
    static void Main(string[] args)
    {
        var randomGenerator = new Random();
        int target = randomGenerator.Next(1, 101);

        while (true)
        {
            Console.Write("What is your guess? ");
            int guess = int.Parse(Console.ReadLine());

            if (guess < target)
            {
                Console.WriteLine("Higher!");
            }
            else if (guess > target)
            {
                Console.WriteLine("Lower!");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                break;
            }
        }
    }
}
