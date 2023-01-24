using System.IO; 
public class Journal
{
    // make a place to hold the journal entries
    List<JournalEntry> journalEntries = new List<JournalEntry>();

    // the Prompt class has a list of prompts to use
    Prompt prompt = new Prompt();

    // information line prefix
    //const string lp = ". ";
    string lp = "│ ";

    // constructor (not used)
    public Journal()
    {
    }

    /*
        get a random prompt and display it on the console
        read the user response from the console
        if there's an empty response, just return
        if there's a response, create a journal entry and add it to the journal
    */
    public void AddEntry()
    {
        // create a working JournalEntry
        JournalEntry entry = new JournalEntry();

        // get a random prompt
        entry._prompt = prompt.Get();

        // prompt for and get the response
        Console.WriteLine(entry._prompt);
        Console.Write("> ");
        entry._response = Console.ReadLine();

        // if there is a response, add the entry to the journal
        if(entry._response !="")
        {
            // get the current date
            DateTime theCurrentTime = DateTime.Now;
            entry._entryDate = theCurrentTime.ToShortDateString();

            journalEntries.Add(entry);
            Console.WriteLine($"\n{lp}journal entry Added\n{lp}");
        }
        else // empty response, so just exit
        {
            Console.WriteLine($"\n{lp}journal entry NOT Added due to no response\n{lp}");
        }
    }

    /*
        loop through the responses in the journal, displaying each one
    */
    public void DisplayAll()
    {
        //Console.WriteLine($"{lp}showing {journalEntries.Count} journal entries:\n");
        Console.WriteLine($"{lp}Number of journal entries to show: {journalEntries.Count}\n");
        foreach(JournalEntry entry in journalEntries)
        {
            entry.Display(); // use the JournalEntry's Display method
        }
        Console.WriteLine($"{lp}end of journal\n");
    }

    /*
        TODO: prompt for a file name
        save the journal entries to a text file, one per line
    */
    public void SaveToFile()
    {
        //TODO: prompt for fileName
        string fileName = "journal.txt";

        Console.WriteLine($"{lp}Ok, saving the journal to {fileName}");
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach(JournalEntry entry in journalEntries)
            {
                outputFile.WriteLine($"{entry._entryDate}|{entry._prompt}|{entry._response}");
            }
        }
        Console.WriteLine($"{lp}{journalEntries.Count} journal entries written\n");
    }

    /*
        TODO: prompt for a file name
        clear the existing journal entries
        read journal entries from a file, one per line
        parse each line and add an entry to the journal
    */
    public void ReadFromFile()
    {
        //TODO: prompt for fileName
        string filename = "journal.txt";

        // remove any existing entries in the journal
        Console.WriteLine($"{lp}Clearing any existing entries in the journal");
        journalEntries.Clear();

        Console.WriteLine($"{lp}Reading a journal from {filename}");
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach(string line in lines)
        {
            JournalEntry entry = new JournalEntry();
            string[] parts = line.Split("|");

            entry._entryDate = parts[0];
            entry._prompt = parts[1];
            entry._response = parts[2];

            journalEntries.Add(entry);
        }

        Console.WriteLine($"{lp}{journalEntries.Count} entries added to the journal\n");
    }

    /* 
        display a list of choices on the console and wait for user response
        act on the response by calling the appropriate method
        loop back to display the list of choices
    */
    public void Menu()
    {
        Console.WriteLine("\nWelcome to the Journal Program :)");
        string selection = "";
        while(selection != "5")
        {
            Console.Write($"{lp}Here are the options:\n{lp} 1-Write\n{lp} 2-Display\n{lp} 3-Load\n{lp} 4-Save\n{lp} 5-Exit\n{lp}Your choice? ");
            selection = Console.ReadLine();
            Console.WriteLine();

            if(selection == "1")
            {
                AddEntry();
            }
            else if(selection == "2")
            {
                DisplayAll();
            }
            else if(selection == "4")
            {
                SaveToFile();
            }
            else if(selection == "3")
            {
                ReadFromFile();
            }
            else if(selection == "5")
            {
                Console.WriteLine($"Thanks for playing. Bye!\n");
            }
            else
            {
                Console.WriteLine($"\n{lp}Huh? What is '{selection}' for?");
            }
        }
    }
}