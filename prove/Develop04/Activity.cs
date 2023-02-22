using System;

public class Activity
{
    private int _duration;
    private DateTime _endTime;
    private DateTime _startTime;
    private string[] _spinnerText = {"/", "-", "\\", "|"};
    private int _spinnerTextLength;
    const int _spinnerDuration = 5;
    

    public Activity()
    {
        _spinnerTextLength = _spinnerText.Count();
    }

    public void Start(string activityName, string description)
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {activityName}.\n\n{description}\n");
        RequestLength();
        Console.Write("Get ready...  ");
        DoSpinner(_spinnerDuration);
    }

    public void Finish()
    {
        
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
        Console.WriteLine("\b \n");
    }

    public void DoCountdown(int length)
    {
        for(int i = length; i > 0; i--)
        {
            Console.Write($"\b{i}");
            Thread.Sleep(1000);
        }
        Console.Write("\b ");
    }
    
    public void StartTimer()
    {
        _startTime = DateTime.Now;
        _endTime = _startTime.AddSeconds(_duration);
    }

    public bool TimeIsUp()
    {
        return(DateTime.Now > _endTime);
    }

    public int ElapsedTime()
    {
        // https://stackoverflow.com/questions/45959959/how-to-measure-elapsed-time-using-datetime-class
        return((int)((DateTime.Now - _startTime).TotalMilliseconds/1000));
    }

}