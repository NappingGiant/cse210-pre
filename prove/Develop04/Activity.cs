using System;

// https://www.w3schools.com/cs/cs_variables_constants.php
// https://stackoverflow.com/questions/45959959/how-to-measure-elapsed-time-using-datetime-class

public class Activity
{
    private int _duration;
    private DateTime _endTime;
    private DateTime _startTime;
    private string[] _spinnerText = {"/", "-", "\\", "|"};
    private int _spinnerTextLength;
    const int _spinnerDuration = 5;
    const int _countDownDuration = 5;

    public Activity()
    {
        _spinnerTextLength = _spinnerText.Count();
    }

    public void Start(string activityName, string description)
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {activityName}.\n\n{description}\n");
        RequestLength();
        Console.Clear();
        Console.Write("Get ready...  ");
        DoSpinner(_spinnerDuration);
    }

    public void Finish(int elapsedTime, string activityName)
    {
        Console.WriteLine("\nWell done!!");
        DoSpinner();
        Console.WriteLine($"You have completed another {elapsedTime} seconds of the {activityName}");
        DoSpinner();
    }
    
    public void RequestLength()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
    }

    public void DoSpinner(int length = _spinnerDuration)
    {
        for(int i = 0; i < length; i++)
        {
            for(int j = 0; j < _spinnerTextLength; j++)
            {
                Console.Write($"\b{_spinnerText[j]}");
                Thread.Sleep((int)(1000 / _spinnerTextLength));
            }

        }
        Console.WriteLine("\b ");
    }

    public void DoCountdown(int length = _countDownDuration)
    {
        for(int i = length; i > 0; i--)
        {
            Console.Write($"\b\b{i,2:D}");
            Thread.Sleep(1000);
        }
        Console.Write("\b\b  ");
    }

    public void DoProgressBar(int length)
    {
        
    }
    
    public void StartTimer()
    {
        _startTime = DateTime.Now;
        _endTime = _startTime.AddSeconds(_duration);
    }

    public bool TimeRemains()
    {
        return(DateTime.Now < _endTime);
    }

    public int ElapsedTime()
    {
        return((int)((DateTime.Now - _startTime).TotalSeconds + 0.500));
    }

}