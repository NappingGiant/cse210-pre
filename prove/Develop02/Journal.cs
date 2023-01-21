

using System.IO; 
public class Journal
{
    public List<JournalEntry> journalEntries = new List<JournalEntry>();

    Prompt prompt = new Prompt();

    public Journal()
    {
    }

    public void AddEntry()
    {
        // create a working JournalEntry
        JournalEntry entry = new JournalEntry();

        // get a random prompt
        entry._prompt = prompt.Get();

        // prompt and get the response
        Console.WriteLine(entry._prompt);
        entry._response = Console.ReadLine();

        // if there is a response, add the entry to the journal
        if(entry._response !="")
        {
            // get the current date
            DateTime theCurrentTime = DateTime.Now;
            entry._entryDate = theCurrentTime.ToShortDateString();

            journalEntries.Add(entry);
            Console.WriteLine("* Entry Added\n");
        }
        else
        {
            Console.WriteLine("* Entry NOT Added due to no response\n");
        }
    }

    public void DisplayAll()
    {
        Console.WriteLine($"Showing {journalEntries.Count} journal entries:\n");
        foreach(JournalEntry entry in journalEntries)
        {
            entry.Display();
        }

        Console.WriteLine("End of Journal\n");

    }

    public void SaveToFile()
    {
        //TODO: prompt for fileName
        string fileName = "journal.txt";

        Console.WriteLine($"Ok, saving the journal to {fileName}");
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach(JournalEntry entry in journalEntries)
            {
                outputFile.WriteLine($"{entry._entryDate}|{entry._prompt}|{entry._response}");
            }
        }
        Console.WriteLine($"{journalEntries.Count} journal entries written\n");
    }

    public void ReadFromFile()
    {
        //TODO: prompt for fileName
        string filename = "journal.txt";

        // remove any existing entries in the journal
        Console.WriteLine("Clearing any existing entries in the journal");
        journalEntries.Clear();

        Console.WriteLine($"Reading a journal from {filename}");
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

        Console.WriteLine($"{journalEntries.Count} entries added to the journal\n");
    }

}