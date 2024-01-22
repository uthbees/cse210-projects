using System;

class Program
{
    static void Main(string[] args)
    {
        var job1 = new Job();
        job1._company = "Apple";
        job1._jobTitle = "Software Engineer";
        job1._startYear = "2020";
        job1._endYear = "2021";
        
        var job2 = new Job();
        job2._company = "Microsoft";
        job2._jobTitle = "Sysadmin";
        job2._startYear = "2019";
        job2._endYear = "2022";
        
        var resume = new Resume();
        resume._name = "John Doe";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);
        
        resume.Display();
    }
}
