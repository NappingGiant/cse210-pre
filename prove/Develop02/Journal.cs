using System.IO; 

/*
 Journal
    Add 0-Freeform journal entry, no prompt, multiple paragraphs, end on empty paragraph, store with newlines between paragraphs
*/

public class Journal
{
    // make a place to hold the journal entries
    List<JournalEntry> journalEntries = new List<JournalEntry>();

    // the Prompt class has a list of prompts to use
    Prompt prompter = new Prompt();

    string ilp = "│ "; // information line prefix (menu, notifices, etc.)
    
    // file line delimiter
    string delim = "|";

    // newline placeholder for writing to file
    string repl = "ˑ";

    Storage files; // Storage class for file IO (initialized in the constructor)

    // constructor
    public Journal()
    {
        files = new Storage(ilp);
    }

    /* AddEntry():
        get a random prompt and display it on the console
        read the user response from the console
        if there's an empty response, just return
        if there's a response, create a journal entry and add it to the journal
    */
    void addEntry(string prompt, string response)
    {
        // if there is a response, add the entry to the journal
        if(response !="")
        {
            // create a working JournalEntry
            JournalEntry entry = new JournalEntry();
            entry.prompt = prompt;
            entry.response = response;

            // get the current date
            DateTime theCurrentTime = DateTime.Now;
            entry.entryDate = theCurrentTime.ToShortDateString();

            journalEntries.Add(entry);
            Console.WriteLine($"\n{ilp}journal entry Added\n{ilp}");
        }
        else // empty response, so just exit
        {
            Console.WriteLine($"\n{ilp}journal entry NOT Added due to no response\n{ilp}");
        }
    }

    public void promptedEntry()
    {
        // get a random prompt
        string prompt = prompter.Get();

        // prompt for and get the response
        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();

        addEntry(prompt, response);
    }

    /* freeEntry()
        unprompted entry, multiple paragraphs
    */
    public void freeEntry()
    {
        Console.WriteLine("Use <enter> to add a paragraph. An empty paragraph ends entry.");

        string response = "";
        string inText = "*"; // something to get the while loop going
        while(inText != "")
        {
            Console.Write("> ");
            inText = Console.ReadLine();
            if(inText != "")
            {
                response += inText + "\n\n";
            }
            else
            {
                response = response.TrimEnd(char.Parse("\n"));
            }
        }

        addEntry("", response);
    }


    /* DisplayAll():
        loop through the responses in the journal, displaying each one
    */
    public void DisplayAll()
    {
        //Console.WriteLine($"{lp}showing {journalEntries.Count} journal entries:\n");
        Console.WriteLine($"{ilp}Number of journal entries to show: {journalEntries.Count}\n");
        foreach(JournalEntry entry in journalEntries)
        {
            entry.Display(); // use the JournalEntry's Display method
        }
        Console.WriteLine($"{ilp}end of journal\n");
    }

    /* Save():
        save the journal entries to a text file, one per line
    */
    public void Save()
    {
        Console.WriteLine($"{ilp}Ok, saving the journal");
        files.clearLines(); // remove any existing data in the file IO List
        foreach(JournalEntry entry in journalEntries)
        {
            string response = entry.response.Replace("\n", repl); // convert newlines to a special character
            files.addLine($"{entry.entryDate}{delim}{entry.prompt}{delim}{response}");
        }
        string filename = files.writeFile();
        Console.WriteLine($"{ilp}{journalEntries.Count} journal entries written to {filename}\n");
    }

    /* Load():
        clear the existing journal entries
        read journal entries from a file, one per line
        parse each line and add an entry to the journal
    */
    public void Load()
    {
        // remove any existing entries in the journal
        Console.WriteLine($"{ilp}Clearing any existing entries in the journal");
        journalEntries.Clear();

        Console.WriteLine($"{ilp}Reading a journal");
        //string[] lines = System.IO.File.ReadAllLines(filename);
        string filename = files.readFile();

        foreach(string line in files.lines)
        {
            JournalEntry entry = new JournalEntry();
            string[] parts = line.Split(delim);

            entry.entryDate = parts[0];
            entry.prompt = parts[1];
            entry.response = parts[2].Replace(repl, "\n"); // convert newline placeholder back to newline

            journalEntries.Add(entry);
        }

        Console.WriteLine($"{ilp}{journalEntries.Count} entries added to the journal from {filename}\n");
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
            Console.WriteLine($"{ilp}There are {journalEntries.Count} entries in the journal");
            Console.Write($"{ilp}Whadda ya wanna do now?\n{ilp} 0-Write (no prompt)\n{ilp} 1-Write (answer prompt)\n{ilp} 2-Display All\n{ilp} 3-Load\n{ilp} 4-Save\n{ilp} 5-Exit\n{ilp}Your choice? ");
            selection = Console.ReadLine();
            Console.WriteLine();

            if(selection == "1")
            {
                promptedEntry();
            }
            else if(selection == "0")
            {
                freeEntry();
            }
            else if(selection == "2")
            {
                DisplayAll();
            }
            else if(selection == "4")
            {
                Save();
            }
            else if(selection == "3")
            {
                Load();
            }
            else if(selection == "5")
            {
                Console.WriteLine($"Thanks for playing. Bye!\n");
            }
            else
            {
                Console.WriteLine($"\n{ilp}Huh? What is '{selection}' for?");
            }
        }
    }
}