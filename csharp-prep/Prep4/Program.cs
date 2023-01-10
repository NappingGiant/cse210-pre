using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // declare our variables
        List<int> numbers = new List<int>();
        int num ;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        // get a list of numbers from the user
        do
        {
            Console.Write("Enter number: ");
            num = int.Parse(Console.ReadLine());
            if(num != 0)
            {
                numbers.Add(num);
            }
        } while(num != 0);

        //>> could've done the following with a loop ...
        int numbersSum = 0;
        float numbersAverage ;
        int numbersMax = numbers[0]; // initialize largest number with a valid value
        foreach (int n in numbers)
        {
            numbersSum += n;
            if(n > numbersMax)
            {
                numbersMax = n ;
            }
        }
        // https://stackoverflow.com/questions/1042099/how-do-i-convert-int-decimal-to-float-in-c
        numbersAverage = ((float)numbersSum) / numbers.Count ;

        //>> ... or use library functions of lists
        // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-7.0
        Console.WriteLine($"The sum is: {numbers.Sum()}");
        Console.WriteLine($"The average is: {numbers.Average()}");
        Console.WriteLine($"The largest number is: {numbers.Max()}");
        //>> didn't find a library function for smallest positive, and needed results from above loop
        int minPositive = numbers.Max();
        foreach(int n in numbers)
        {
            if((n >= 0) && (n < minPositive))
            {
                minPositive = n ;
            }
        }
        Console.WriteLine($"The smallest positive number is: {minPositive}");

        Console.WriteLine("The sorted list is:");
        numbers.Sort();
        foreach(int n in numbers)
        {
            Console.WriteLine(n);
        }
        
    }
}