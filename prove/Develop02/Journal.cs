using System.IO; 

/*
 Journal
    Add 0-Freeform journal entry, no prompt, multiple paragraphs, end on empty paragraph, store with newlines between paragraphs
*/

public class Journal
{
    // make a place to hold the journal entries
    List<JournalEntry> _journalEntries = new List<JournalEntry>();

    // the Prompt class has a list of prompts to use
    Prompt _prompter = new Prompt();

    string _ilp = "│ "; // information line prefix (menu, notifices, etc.)
    
    // file line delimiter
    string _delim = "|";

    // newline placeholder for writing to file
    string _repl = "ˑ";

    Storage _files; // Storage class for file IO (initialized in the constructor)

    // constructor
    public Journal()
    {
        _files = new Storage(_ilp);
    }

    /* AddEntry():
        get a random prompt and display it on the console
        read the user response from the console
        if there's an empty response, just return
        if there's a response, create a journal entry and add it to the journal
    */
    void AddEntry(string prompt, string response)
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

            _journalEntries.Add(entry);
            Console.WriteLine($"\n{_ilp}journal entry Added\n{_ilp}");
        }
        else // empty response, so just exit
        {
            Console.WriteLine($"\n{_ilp}journal entry NOT Added due to no response\n{_ilp}");
        }
    }

    public void PromptedEntry()
    {
        // get a random prompt
        string prompt = _prompter.Get();

        // prompt for and get the response
        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();

        AddEntry(prompt, response);
    }

    /* freeEntry()
        unprompted entry, multiple paragraphs
    */
    public void FreeEntry()
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

        AddEntry("", response);
    }


    /* DisplayAll():
        loop through the responses in the journal, displaying each one
    */
    public void DisplayAll()
    {
        //Console.WriteLine($"{lp}showing {journalEntries.Count} journal entries:\n");
        Console.WriteLine($"{_ilp}Number of journal entries to show: {_journalEntries.Count}\n");
        foreach(JournalEntry entry in _journalEntries)
        {
            entry.Display(); // use the JournalEntry's Display method
        }
        Console.WriteLine($"{_ilp}end of journal\n");
    }

    /* Save():
        save the journal entries to a text file, one per line
    */
    public void Save()
    {
        Console.WriteLine($"{_ilp}Ok, saving the journal");
        _files.ClearLines(); // remove any existing data in the file IO List
        foreach(JournalEntry entry in _journalEntries)
        {
            string response = entry.response.Replace("\n", _repl); // convert newlines to a special character
            _files.AddLine($"{entry.entryDate}{_delim}{entry.prompt}{_delim}{response}");
        }
        string filename = _files.WriteFile();
        Console.WriteLine($"{_ilp}{_journalEntries.Count} journal entries written to {filename}\n");
    }

    /* Load():
        clear the existing journal entries
        read journal entries from a file, one per line
        parse each line and add an entry to the journal
    */
    public void Load()
    {
        // remove any existing entries in the journal
        Console.WriteLine($"{_ilp}Clearing any existing entries in the journal");
        _journalEntries.Clear();

        Console.WriteLine($"{_ilp}Reading a journal");
        //string[] lines = System.IO.File.ReadAllLines(filename);
        string filename = _files.ReadFile();

        foreach(string line in _files._lines)
        {
            JournalEntry entry = new JournalEntry();
            string[] parts = line.Split(_delim);

            entry.entryDate = parts[0];
            entry.prompt = parts[1];
            entry.response = parts[2].Replace(_repl, "\n"); // convert newline placeholder back to newline

            _journalEntries.Add(entry);
        }

        Console.WriteLine($"{_ilp}{_journalEntries.Count} entries added to the journal from {filename}\n");
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
            Console.WriteLine($"{_ilp}There are {_journalEntries.Count} entries in the journal");
            Console.Write($"{_ilp}Whadda ya wanna do now?\n{_ilp} 0-Write (no prompt)\n{_ilp} 1-Write (answer prompt)\n{_ilp} 2-Display All\n{_ilp} 3-Load\n{_ilp} 4-Save\n{_ilp} 5-Exit\n{_ilp}Your choice? ");
            selection = Console.ReadLine();
            Console.WriteLine();

            if(selection == "1")
            {
                PromptedEntry();
            }
            else if(selection == "0")
            {
                FreeEntry();
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
                Console.WriteLine($"\n{_ilp}Huh? What is '{selection}' for?");
            }
        }
    }
}