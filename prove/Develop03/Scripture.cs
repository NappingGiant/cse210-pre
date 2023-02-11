/*
class Scripture
---
_reference: Reference
_text: string
_words: List<Word>
_hiddenState: int
---
Scripture(Reference, text): constructor
HideWords(int count=3): void
GetDisplayText(): string
UnHide(): void
GetHiddenState(): int
*/

using System;

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

    public Reference GetReferenceObject()
    {
        return(_reference);
    }
    
    public string GetText()
    {
        return(_text);
    }

    public string GetDisplayText()
    {
        string displayText = "";
        foreach(Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return(_reference.GetDisplayText() + " - " + displayText.TrimEnd());
    }

    public bool HideWords(int count = 3)
    {
        for(int i = 0; i < count; i++)
        {
            _words[_rnd.Next(_wordCount)].Hide();
        }
        // now see if all of the words are hidden
        _allHidden = true ;
        foreach(Word word in _words)
        {
            if(word.IsVisible())
            {
                _allHidden = false;
                break;
            }
        }
        return(_allHidden);
    }

    public void UnHide()
    {
        foreach(Word word in _words)
        {
            word.Show();
        }
    }

    public string GetReference()
    {
        return(_reference.GetDisplayText());
    }
}