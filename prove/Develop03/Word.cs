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

    ///
    /// <summary>
    /// returns word visibility
    /// </summary>
    ///
    public bool IsVisible()
    {
        return(_visible);
    }

    ///
    /// <summary>
    /// set word visibility to false
    /// </summary>
    ///
    public void Hide()
    {
        _visible = false;
    }

    ///
    /// <summary>
    /// set word visibility to true
    /// </summary>
    ///
    public void Show()
    {
        _visible = true;
    }

    ///
    /// <summary>
    /// return the word if set to visible, else underscores
    /// </summary>
    ///
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