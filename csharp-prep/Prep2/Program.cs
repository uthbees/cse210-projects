using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        float gradePercentage = float.Parse(Console.ReadLine());

        Console.WriteLine(
            $"Your letter grade is {DetermineLetterGrade(gradePercentage)}{DetermineGradeSign(gradePercentage)}");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations on passing the course!");
        }
        else
        {
            Console.WriteLine("Sorry you failed. Hopefully you'll do better next time!");
        }

        static char DetermineLetterGrade(float gradePercentage)
        {
            switch (gradePercentage)
            {
                case >= 90:
                    return 'A';
                case >= 80:
                    return 'B';
                case >= 70:
                    return 'C';
                case >= 60:
                    return 'D';
                default:
                    return 'F';
            }
        }

        static string DetermineGradeSign(float gradePercentage)
        {
            var gradeSign = "";

            if (gradePercentage % 10 >= 7)
            {
                gradeSign = "+";
            }
            else if (gradePercentage % 10 < 3)
            {
                gradeSign = "-";
            }

            if (gradePercentage > 90 && gradeSign == '+'.ToString() || gradePercentage < 60)
            {
                gradeSign = "";
            }

            return gradeSign;
        }
    }
}
