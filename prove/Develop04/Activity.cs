using System;

// https://www.w3schools.com/cs/cs_variables_constants.php
// https://stackoverflow.com/questions/45959959/how-to-measure-elapsed-time-using-datetime-class
// https://stackoverflow.com/questions/273313/randomize-a-listt

public class Activity
{
    private int _duration;
    private DateTime _endTime;
    private DateTime _startTime;
    //private string[] _spinnerText = {"'", "\"", "|", "/", "-", "\\", };
    //private string[] _spinnerText = {"|", "/", "-", "\\", "|", "/", "-", "\\", "|", "/", "-", "\\", };
    private string[] _spinnerText = {"|", "/", "-", "\\"};
    private int _spinnerTextLength;
    const int _spinnerDuration = 5;
    const int _countDownDuration = 5;
    protected Random _rnd;

    public Activity()
    {
        _rnd = new Random();
        _spinnerTextLength = _spinnerText.Count();
    }

    public void Start(string activityName, string description)
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {activityName}.\n\n{description}\n");
        RequestLength();
        Console.Clear();
        TextWithSpinner("Get ready...");
    }

    public void Finish(int elapsedTime, string activityName)
    {
        TextWithSpinner("\nWell done!!\n");
        TextWithSpinner($"You have completed another {elapsedTime} seconds of the {activityName}\n");
    }
    
    private void RequestLength()
    {
        // TODO: make this safe
        int inPut = 0;
        while(inPut <= 0)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            try
            {
                inPut = int.Parse(Console.ReadLine());
            }
            catch(Exception e)
            {
                Console.WriteLine($"Please enter a valid integer value! ({e.Message})");
                inPut = 0;
            } 
            if(inPut < 0)
            {
                Console.WriteLine("Please enter a positive integer value!");
            }
        }
        _duration = inPut;
    }

    public void TextWithSpinner(string text, int length = _spinnerDuration)
    {
        Console.Write($"\n{text} ");
        DoSpinner(length);
    }

    public void TextWithCountdown(string text, int length = _countDownDuration)
    {
        Console.Write($"\n{text}  ");
        DoCountdown(length);
    }

    public void DoSpinner(int length = _spinnerDuration)
    {
        int sleepTime = (int)(1000 / _spinnerTextLength);
        for(int i = 0; i < length; i++) // count the seconds in this loop
        {
            for(int j = 0; j < _spinnerTextLength; j++) // do the entire animation once per second
            {
                Console.Write($"\b{_spinnerText[j]}");
                Thread.Sleep(sleepTime); // but how much time does the code add???
            }

        }
        Console.Write("\b ");
    }

    public void DoCountdown(int length = _countDownDuration)
    {
        // allow for length > 9 (but less than 100)
        for(int i = length; i > 0; i--)
        {
            Console.Write($"\b\b{i,2:D}");
            Thread.Sleep(1000);
        }
        Console.Write("\b\b  ");
    }

    public void DoProgressBar(int length)
    {
        Console.WriteLine("not implemented yet");
    }
    
    public void StartTimer()
    {
        _startTime = DateTime.Now;
        _endTime = _startTime.AddSeconds(_duration);
    }

    public bool TimeRemains()
    {
        return(DateTime.Now <= _endTime);
    }

    public int ElapsedTime()
    {
        return((int)((DateTime.Now - _startTime).TotalSeconds + 0.500)); // fudge 0.5 to simulate rounding
    }

    public void ShuffleStringList<T>(List<T> inList)
    {
        // does an in-place shuffle of a List<>
        // https://stackoverflow.com/questions/273313/randomize-a-listt

        int n = inList.Count;  
        while (n > 1) {  
            n--;  
            int k = _rnd.Next(n + 1);  
            T value = inList[k];  
            inList[k] = inList[n];  
            inList[n] = value;  
        }  
    }


}