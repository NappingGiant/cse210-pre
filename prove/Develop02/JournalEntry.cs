/*
    define each entry for the journal:
        prompt used
        date created
        response to the prompt
*/

public class JournalEntry
{
    public string prompt = "";
    public string entryDate = "";
    public string response = "";

    public JournalEntry()
    {
    }

    public void Display()
    {
        Console.WriteLine($"{entryDate} - {prompt}\n{response}\n");
    }

}