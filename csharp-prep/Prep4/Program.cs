using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        var list = new List<int>();

        while (true)
        {
            Console.Write("Enter number: ");
            int newInput = int.Parse(Console.ReadLine());

            if (newInput != 0)
            {
                list.Add(newInput);
            }
            else
            {
                break;
            }
        }

        var sum = list.Sum();
        double average = (double)sum / list.Count;
        var max = list.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}
