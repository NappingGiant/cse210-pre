/*
    define each entry for the journal:
        prompt used
        date created
        response to the prompt
*/

public class JournalEntry
{
    public string _prompt = "";
    public string _entryDate = "";
    public string _response = "";

    public JournalEntry()
    {
    }

    public void Display()
    {
        Console.WriteLine($"{_entryDate} - {_prompt}\n {_response}\n");
    }

}