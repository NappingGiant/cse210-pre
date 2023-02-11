/*
class Word
---
_word: string
_visible: boolean
_hiddenText: string
---
Word(string word): constructor
Hide(): void
Show(): void
GetDisplayText(): string

*/
using System;
///
/// <summary>
/// Store a string that can be 'hidden' by replacing all characters with underscores.
/// </summary>
///
public class Word
{
    private string _word;
    private bool _visible;
    private string _hiddenWord;

    public Word(string word)
    {
        _word = word;
        _visible = true;
        _hiddenWord = new string('_', word.Length);
    }

    public bool IsVisible()
    {
        return(_visible);
    }

    public void Hide()
    {
        _visible = false;
    }

    public void Show()
    {
        _visible = true;
    }

    public string GetDisplayText()
    {
        if(_visible)
        {
            return(_word);
        }
        else
        {
            return(_hiddenWord);
        }
    }

}