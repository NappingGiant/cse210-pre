using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Develop02 World!");

        Journal myJournal = new Journal();

        string selection = "";
        while(selection != "0")
        {
            Console.Write($"What to do, what to do\n 1-Add an entry\n 2-Show all entries\n 3-Save to a file\n 4-Read from a file\n 0-Exit\n (1, 2, 3, 4, 0) >");
            selection = Console.ReadLine();
            Console.WriteLine("");

            if(selection == "1")
            {
                myJournal.AddEntry();
            }
            else if(selection == "2")
            {
                myJournal.DisplayAll();
            }
            else if(selection == "3")
            {
                myJournal.SaveToFile();
            }
            else if(selection == "4")
            {
                myJournal.ReadFromFile();
            }
            else if(selection == "0")
            {
                Console.WriteLine("Thanks for playing. Bye!\n");
            }
            else
            {
                Console.WriteLine($"\nHuh? What is '{selection}' for?");
            }

        }
    }
}