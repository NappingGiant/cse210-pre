using System;

public class BreathingActivity : Activity
{
    private string _activityName = "Breathing Activity";
    private string _description =
        "This activity will help you relax by walking you through breathing in and\n" +
        "out slowly. Clear your mind and focus on your breathing.";
    private int _inBreath = 3;
    private int _outBreath = 5;

    public BreathingActivity() : base()
    {
        return;
    }

    public int DoIt()
    {
        Start(_activityName, _description);
        StartTimer();
        while(TimeRemains())
        {
            Breathe();
        }
        int elapsedTime = ElapsedTime();
        Finish(elapsedTime, _activityName);
        return(elapsedTime);
    }

    private void Breathe()
    {
        Console.Write("\nBreath in...  ");
        DoCountdown(_inBreath);
        Console.Write("\nBreath out...  ");
        DoCountdown(_outBreath);
        Console.WriteLine();
    }


}