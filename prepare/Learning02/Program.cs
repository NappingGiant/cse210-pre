using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Intel";
        job1._jobTitle = "Loose Cannon";
        job1._startYear = 2000;
        job1._endYear = 2016;

        Job job2 = new Job();
        job2._company = "Providence Health System";
        job2._jobTitle = "Troublemaker";
        job2._startYear = 1995;
        job2._endYear = 2000;

        Resume myResume = new Resume();
        myResume._name = "Mortimer Schnerd";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}