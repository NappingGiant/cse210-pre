using System;

class Program
{
    static void Main(string[] args)
    {
        string inText ; // for user input
        int magicNumber ; // the target number
        int guess ; // the most recent guess
        int guesses ; // the number of guesses for the current target
        int maxNumber = 100 ; // the highest number in the range of random numbers
        Random randomGenerator = new Random();
        string doAgain = "y"; // y to do a guessing sequence

        Console.WriteLine("Hello Cool World!\n");

        while(doAgain == "y")
        {
            // get a target number
            magicNumber = randomGenerator.Next(1, maxNumber + 1);
            Console.WriteLine($"OK, I've got a number between 1 and {maxNumber} inclusive...");

            // loop, requesting guesses at the target and stating higher or lower or equal
            // exit on equal
            guess = -1 ;  
            guesses = 0 ;
            while (guess != magicNumber) 
            {
                Console.Write("What is your guess? ");
                inText = Console.ReadLine();
                guess = int.Parse(inText);
                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                guesses++;
            } 

            Console.WriteLine("You guessed it!");
            Console.WriteLine($"It took you {guesses} guesses.\n");

            // do another?
            Console.Write("Do another? (y/n)");
            doAgain = Console.ReadLine();
        }
    }
}