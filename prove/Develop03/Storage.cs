
using System.Text.Json;

// Resources:
// https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/how-to?pivots=dotnet-7-0
// https://www.w3schools.com/cs/cs_properties.php
// https://stackoverflow.com/questions/50343016/deserialize-json-array-to-c-sharp-list-object
// https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/customize-properties?pivots=dotnet-7-0

///
/// <summary>
/// internal class used to write/read information in JSON format to/from a file
/// </summary>
///
class scriptureStore
{
    // HAHA! the Json deserializer doesn't want to work with names that begin with an underscore!
    public string book{ get; set; }
    public int chapter{ get; set; }
    public int firstVerse{ get; set; }
    public int lastVerse{ get; set; }
    public string text{ get; set; }

    public scriptureStore(string book, int chapter, int firstVerse, int lastVerse, string text)
    {
        this.book = book;
        this.chapter = chapter;
        this.firstVerse = firstVerse;
        this.lastVerse = lastVerse;
        this.text = text;
    }
}


///
/// <summary>
/// Storage class specific to the the scripture memorizer
/// </summary>
///
public class Storage
{
    private string _fileName;

    public Storage(string fileName)
    {
        _fileName = fileName;
    }

    ///
    /// <summary>
    /// convert List<Scripture> to something that the JSON serializer can use (List<scriptureStorage>)
    /// </storage>
    ///
    public void Save(List<Scripture> daList)
    {
        Console.WriteLine("Storage-Save");

        // build a simplified list of the information in each scripture in the incoming List
        // (cuz I didn't know better in creating the original classes)
        List<scriptureStore> _scriptureStore = new List<scriptureStore>();
        foreach(Scripture scripture in daList)
        {
            Reference rf = scripture.GetReferenceObject();
            scriptureStore ss = new scriptureStore(rf.GetBook(), rf.GetChapter(), rf.GetFirstVerse(), rf.GetLastVerse(), scripture.GetText());
            _scriptureStore.Add(ss);
        }

        // convert the simplified list to JSON format (NOTE that it has newlines)
        var options = new JsonSerializerOptions{WriteIndented = true, IncludeFields = true};
        string jsonString = JsonSerializer.Serialize(_scriptureStore, options);

        // write the JSON string to the storage file
        using (StreamWriter outputFile = new StreamWriter(_fileName))
        {
            outputFile.WriteLine(jsonString);
        }
    }

    ///
    /// <summary>
    /// Read the JSON file and format the data to a List<Scripture> that the Memorizer uses
    /// </summary>
    ///
    public List<Scripture> Load()
    {
        string jsonString = "";
        // read in the JSON representation of the save scripture list
            try
            {
                jsonString = System.IO.File.ReadAllText(_fileName);
            }
            catch(Exception e)
            {
                Console.WriteLine($"{_fileName} could not be read");
                Console.WriteLine(e.Message, e.GetType());
            }


        // convert the JSON string to a List of storageScripture
        List<scriptureStore> _scriptureStore = new List<scriptureStore>();
        var options = new JsonSerializerOptions{IncludeFields = true};
        _scriptureStore = JsonSerializer.Deserialize<List<scriptureStore>>(jsonString, options)!;


        // convert List<scriptureStore> to List<Scripture>
        List<Scripture> newList = new List<Scripture>();
        foreach(scriptureStore ss in _scriptureStore)
        {
            Reference r;
            if(ss.lastVerse == 0)
            {
                r = new Reference(ss.book, ss.chapter, ss.firstVerse);
            }
            else
            {
                r = new Reference(ss.book, ss.chapter, ss.firstVerse, ss.lastVerse);
            }
            Scripture s = new Scripture(r, ss.text);
            newList.Add(s);
        }
        // return the List
        return(newList);
    }

}