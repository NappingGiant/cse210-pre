/*
class reference
---
_book: string
_chapter: int
_firstVerse: int
_lastVerse: int
_displayString: string
---
Reference(string book, int chapter, int firstVerse, int lastVerse): constructor
Reference(string book, int chapter, int Verse): constructor
GetDisplayText(): string
*/

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

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _firstVerse = verse;
        _displayString = $"{_book} {_chapter}:{_firstVerse}";
    }

    public Reference(string book, int chapter, int firstVerse, int lastVerse)
    {
        _book = book;
        _chapter = chapter;
        _firstVerse = firstVerse;
        _lastVerse = lastVerse;
        _displayString = $"{_book} {_chapter}:{_firstVerse}-{_lastVerse}";
    }

    public string GetDisplayText()
    {
        return(_displayString);
    }

    public string GetBook()
    {
        return(_book);
    }

    public int GetChapter()
    {
        return(_chapter);
    }

    public int GetFirstVerse()
    {
        return(_firstVerse);
    }

    public int GetLastVerse()
    {
        return(_lastVerse);
    }

}