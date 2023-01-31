using System.IO;

public class Storage
{
    public List<string> _lines = new List<string>();

    // line prefix, initialized in the constructor
    string _lp;

    public Storage(string lineLead)
    {
        _lp = lineLead;
    }

    // clear the List used for transferring file data in and out
    public void ClearLines()
    {
        _lines.Clear();
    }

    // add a line to the List
    public void AddLine(string line)
    {
        _lines.Add(line);
    }

    public string GetFileName()
    {
        string filename = "";
        while(filename == "")
        {
            Console.Write($"{_lp}Enter a filename > ");
            filename = Console.ReadLine();
            if(filename == "")
            {
                Console.WriteLine($"{_lp}A filename is required!");
            }
        }
        return(filename);
    }

    public string ReadFile()
    {
        string filename = "";
        bool success = false;
        while(success == false)
        {
            filename = GetFileName();
            try
            {
                string[] inlines = System.IO.File.ReadAllLines(filename);
                _lines = inlines.ToList();
                success = true;
            }
            catch(Exception e)
            {
                Console.WriteLine($"{_lp}{filename} could not be read");
                Console.WriteLine(_lp, e.Message, e.GetType());
                Console.WriteLine($"{_lp}Try a valid filename...");
            }
        }
        //https://stackoverflow.com/questions/1440265/how-to-add-a-string-to-a-string-array-theres-no-add-function
        return(filename);
    }

    public string WriteFile()
    {
        string filename = GetFileName();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach(string line in _lines)
            {
                outputFile.WriteLine(line);
            }
        }
        return(filename);
    }
}