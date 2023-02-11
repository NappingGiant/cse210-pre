using System;

class Program
{
    static void Main(string[] args)
    {
       
        //Console.WriteLine("Hello Develop03 World!");
        //TestWord("grape");
        //TestWord("blueberry");
        //TestWord("period.");
        //TestReference();
        //TestScripture();
        
        Memorizer mem = new Memorizer();
    }

    static void TestWord(string word)
    {
        Word testWord = new Word(word);
        Console.WriteLine($"new word: {testWord.GetDisplayText()}");
        testWord.Hide();
        Console.WriteLine($"hide word: {testWord.GetDisplayText()}");
        testWord.Show();
        Console.WriteLine($"show word: {testWord.GetDisplayText()}");
    }

    static void TestReference()
    {
        Reference ref1 = new Reference("Alma", 7, 23, 24);
        Console.WriteLine(ref1.GetDisplayText());
        Reference ref2 = new Reference("Philippians", 4, 13);
        Console.WriteLine(ref2.GetDisplayText());
    }

    static void TestScripture()
    {
        Reference ref1 = new Reference("Phil.", 4, 13);
        string text1 = "I can do all things through Christ which strengheneth me.";
        Scripture script1 = new Scripture(ref1, text1);
        Console.WriteLine(script1.GetDisplayText());
        script1.HideRandomWords();
        Console.WriteLine(script1.GetDisplayText());
    }

}