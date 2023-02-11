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

    public Memorizer()
    {
        _scriptures = new List<Scripture>();
        _storage = new Storage("scriptures.json");
        // testing only
        Reference tref = new Reference("Philippians", 3, 18);
        Scripture tscr = new Scripture(tref, "I can do all things through Christ which strengtheneth me.");
        _scriptures.Add(tscr);
        //
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
                Console.WriteLine("\nAdd a Scripture\n");
                AddScripture();
            }
            else if(choice == "2")
            {
                Console.WriteLine("\nDisplay Scripture Choices\n");
                DisplayScriptureChoices();
            }
            else if(choice == "3")
            {
                Console.WriteLine("\nMemorize a Scripture\n");
                Memorize(_scriptures[0]); // just choose the first (only) scripture for now
            }
            else if(choice == "4")
            {
                Console.WriteLine("\nLoad\n");
                Load();
            }
            else if(choice == "5")
            {
                Console.WriteLine("\nSave\n");
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
            Console.WriteLine(scripture.GetDisplayText());
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
            response = Console.ReadLine();
            if(allHidden)
            {
                break;
            }
            if(response == "")
            {
                allHidden = scripture.HideWords();
            }
            else if(response == "r")
            {
                scripture.UnHide();
            }
        }
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