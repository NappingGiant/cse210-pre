using System.IO;

public class Storage
{
    public List<string> lines = new List<string>();

    // line prefix, initialized in the constructor
    string lp;

    public Storage(string lineLead)
    {
        lp = lineLead;
    }

    // clear the List used for transferring file data in and out
    public void clearLines()
    {
        lines.Clear();
    }

    // add a line to the List
    public void addLine(string line)
    {
        lines.Add(line);
    }

    public string getFileName()
    {
        string filename = "";
        while(filename == "")
        {
            Console.Write($"{lp}Enter a filename > ");
            filename = Console.ReadLine();
            if(filename == "")
            {
                Console.WriteLine($"{lp}A filename is required!");
            }
        }
        return(filename);
    }

    public string readFile()
    {
        string filename = "";
        bool success = false;
        while(success == false)
        {
            filename = getFileName();
            try
            {
                string[] inlines = System.IO.File.ReadAllLines(filename);
                lines = inlines.ToList();
                success = true;
            }
            catch(Exception e)
            {
                Console.WriteLine($"{lp}{filename} could not be read");
                Console.WriteLine(lp, e.Message, e.GetType());
                Console.WriteLine($"{lp}Try a valid filename...");
            }
        }
        //https://stackoverflow.com/questions/1440265/how-to-add-a-string-to-a-string-array-theres-no-add-function
        return(filename);
    }

    public string writeFile()
    {
        string filename = getFileName();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach(string line in lines)
            {
                outputFile.WriteLine(line);
            }
        }
        return(filename);
    }
}