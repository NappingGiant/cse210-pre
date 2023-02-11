using System;

///
/// <summary>
/// Holds a scripture reference (book, chapter, verse(s)) to display in the form "<book> <chapter>:<verse>[-<verse>]
/// </summary>
///
public class Reference
{
    private string _book;
    private int _chapter;
    private int _firstVerse;
    private int _lastVerse = 0; // zero means only one verse
    private string _displayString;

    // single-verse constructor
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _firstVerse = verse;
        // built the display string
        _displayString = $"{_book} {_chapter}:{_firstVerse}";
    }

    // multiple verse constructor
    public Reference(string book, int chapter, int firstVerse, int lastVerse)
    {
        _book = book;
        _chapter = chapter;
        _firstVerse = firstVerse;
        _lastVerse = lastVerse;
        // built the display string
        _displayString = $"{_book} {_chapter}:{_firstVerse}-{_lastVerse}";
    }

    ///
    /// <summary>
    /// return a string of the entire reference (book chapter:verse[-verse])
    /// </summary>
    ///
    public string GetDisplayText()
    {
        return(_displayString);
    }

    ///
    /// <summary>
    ///  return the name of the scripture book
    /// </summary>
    ///
    public string GetBook()
    {
        return(_book);
    }

    ///
    /// <summary>
    ///  eturn the chapter number
    /// </summary>
    ///
    public int GetChapter()
    {
        return(_chapter);
    }

    ///
    /// <summary>
    /// return the verse, or starting verse if more than one
    /// </summary>
    ///
    public int GetFirstVerse()
    {
        return(_firstVerse);
    }

    ///
    /// <summary>
    /// return the value of the lastVerse
    /// </summary>
    ///
    public int GetLastVerse()
    {
        return(_lastVerse);
    }

}