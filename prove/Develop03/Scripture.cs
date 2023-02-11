using System;

///
/// <summary>
/// holds a scripture Reference and text
/// </summary>
///
public class Scripture
{
    private Reference _reference;
    private string _text;
    private List<Word> _words;
    private int _wordCount;
    private bool _allHidden; 
    private Random _rnd;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _text = text;
        _words = new List<Word>();
        string[] words = text.Split();
        foreach(string word in words)
        {
            Word newWord = new Word(word);
            _words.Add(newWord);
        }
        _wordCount = _words.Count;
        _allHidden = false;
        _rnd = new Random();
    }

    ///
    /// <summary>
    /// return a reference to Reference, so the caller can refer to it.
    /// </summary>
    ///
    public Reference GetReferenceObject()
    {
        return(_reference);
    }
    
    ///
    /// <summary>
    /// return a string of the original scripture text, with no hidden words
    /// </summary>
    ///
    public string GetText()
    {
        return(_text);
    }

    ///
    /// <summary>
    /// return a string of the scripture text, with hidden words if set to such
    /// </summary>
    ///
    public string GetDisplayText()
    {
        string displayText = "";
        foreach(Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return(_reference.GetDisplayText() + " - " + displayText.TrimEnd());
    }

    ///
    /// <summary>
    /// return a list of indexes to words that are visible (not hidden)
    /// </summary>
    ///
    private List<int> GetVisibleWords()
    {
        List<int> visibleWords = new List<int>();
        for(int i = 0; i < _words.Count; i++)
        {
            if(_words[i].IsVisible())
            {
                visibleWords.Add(i);
            }
        }
        return(visibleWords);
    }

    ///
    /// <summary>
    /// change random words to be hidden (i.e., show underscores instead of the word)
    /// and return a boolean where true means all words are hidden
    /// </summary>
    ///
    public bool HideRandomWords(int changeCount = 3)
    {
        // to hold a list of words still visible
        List<int> visibleWords = new List<int>();
        int count = 0;
        while(count < changeCount)
        {
            // get a list of indexes to words still visible
            visibleWords = GetVisibleWords();
            if(visibleWords.Count > 0)
            {
                // choose a random word index and set the word to hidden
                int seq = _rnd.Next(visibleWords.Count);
                _words[visibleWords[seq]].Hide();
            }
            else // all words are hidden, get out of this loop
            {
                _allHidden = true;
                break;
            }
            count += 1;
        }
        return(_allHidden);
    }

    ///
    /// <summary>
    /// make all of the words in the text visible
    /// </summary>
    ///
    public void UnHide()
    {
        foreach(Word word in _words)
        {
            word.Show();
        }
        _allHidden = false;
    }

    ///
    /// <summary>
    /// return a string of the scripture reference
    /// </summary>
    ///
    public string GetReference()
    {
        return(_reference.GetDisplayText());
    }
}