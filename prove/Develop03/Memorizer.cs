/*
class ScriptureMemorizer
---
_scriptures: List<Scripture>
---
GetReference(): Reference
AddScripture(Reference reference): void
DisplayScriptureChoices(): void
GetChoice(): Reference
Memorize(Reference reference): void

*/
using System.Collections.Generic;
using System.Text.Json;
using System.Xml.Serialization;

public class Memorizer{

    private List<Scripture> _scriptures;

    private Storage _storage;
    private Random _rnd;

    public Memorizer()
    {
        // inialize stuff
        _rnd = new Random();

        // load the existing data
        _storage = new Storage("scriptures.json");
        _scriptures = _storage.Load(); // Load existing entries (file must exist)
        
        // Ok, all set so show a menu of options and go, go, go
        Menu();
    }

    public void Menu()
    {
        string choice = "-1";
        while(choice != "0")
        {
            Console.Write(  "Choices are:\n"  +
                            " 1. Add a Scripture\n" +
                            " 2. Display Scripture Choices\n" +
                            " 3. Memorize a Scripture\n" +
                            " 4. Load\n" +
                            " 5. Save\n" +
                            " 0. Exit\n" +
                            "What next? ");
            choice =  Console.ReadLine();
            if(choice == "1")
            {
                Console.WriteLine("\nAdd a Scripture");
                AddScripture();
            }
            else if(choice == "2")
            {
                Console.WriteLine("\nDisplay Scripture Choices");
                DisplayScriptureChoices();
            }
            else if(choice == "3")
            {
                Console.WriteLine("\nMemorize a Scripture"); // as of now, this will be cleared immediately
                int sel = _rnd.Next(0, _scriptures.Count);
                Memorize(_scriptures[sel]);
            }
            else if(choice == "4")
            {
                Console.WriteLine("\nLoad");
                Load();
            }
            else if(choice == "5")
            {
                Console.WriteLine("\nSave");
                Save();
            }
            else if(choice == "0")
            {
                Console.WriteLine("\nRemember well!\n");
            } 
            else
            {
                Console.WriteLine("\nPlease enter a valid choice\n");
            }
        }
    }

    private void AddScripture()
    {
        Console.Write("Book? ");
        string book = Console.ReadLine();
        int chapter = GetInt("Chapter? ");
        int firstVerse = GetInt("First Verse? ");
        int lastVerse = GetInt("Last Verse (or zero for none)? ");
        Console.Write("Text? ");
        string text = Console.ReadLine();
        Reference reference;
        if(lastVerse == 0)
        {
            reference = new Reference(book, chapter, firstVerse);
        }
        else
        {
            reference = new Reference(book, chapter, firstVerse, lastVerse);
        }
        Scripture script = new Scripture(reference, text);
        Console.WriteLine($"Adding {script.GetDisplayText()}");
        _scriptures.Add(script);
    }

    private void DisplayScriptureChoices()
    {
        foreach(Scripture scripture in _scriptures)
        {
            //Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine($"- {scripture.GetReference()}");
        }
        Console.WriteLine();
    }

    private void Memorize(Scripture scripture)
    {
        string response = "";
        bool allHidden = false;
        while((response != "quit") && (response != "q"))
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            if(allHidden)
            {
                Console.Write("\n(<enter> to return to menu, 'r' to restart, 'q' or 'quit' to return to menu) ");
            }
            else
            {
                Console.Write("\n(<enter> to continue, 'r' to restart, 'q' or 'quit' to return to menu) ");
            }
            response = Console.ReadLine().ToLower();
            if(response == "r")
            {
                scripture.UnHide();
                allHidden = false;
            }
            else if(allHidden)
            {
                break;
            }
            else if(response == "")
            {
                allHidden = scripture.HideRandomWords();
            }
        }
        scripture.UnHide(); // restore visibility before leaving
    }

    private int GetInt(string prompt)
    {
        bool goodInt = false;
        int validInt = -1;
        while(goodInt == false)
        {
            Console.Write(prompt);
            string response = Console.ReadLine();
            try
            {
                validInt = int.Parse(response);
                goodInt = true;
            }
            catch
            {
                Console.WriteLine("looking for an integer, please try again");
            }
        }
        return(validInt);
    }

    private void Load()
    {
        _scriptures = _storage.Load();
    }

    private void Save()
    {
        _storage.Save(_scriptures);
    }
}