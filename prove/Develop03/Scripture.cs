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
    Reference _reference;
    string _text;
    List<Word> _words;
    int _hiddenState; // 1 = not hidden, 0 = partially hidden, -1 = completely hidden

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
        _hiddenState = 1;
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

    public void HideWords()
    {
        _words[3].Hide();
        _words[5].Hide();
    }


}