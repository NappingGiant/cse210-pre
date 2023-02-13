using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning04 World!");
        Console.WriteLine();
        
        Assignment assignment1 = new Assignment("Bozo T. Clown", "Humor");
        Console.WriteLine(assignment1.GetSummary());
        Console.WriteLine();

        MathAssignment ma1 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(ma1.GetSummary());
        Console.WriteLine(ma1.GetHomeworkList());
        Console.WriteLine();
        
        WritingAssignment wr1 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(wr1.GetSummary());
        Console.WriteLine(wr1.GetWritingInformation());
        Console.WriteLine();
    }
}