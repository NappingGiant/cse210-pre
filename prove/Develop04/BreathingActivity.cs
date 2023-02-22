using System;

public class BreathingActivity : Activity
{
    private string _activityName = "Breathing Activity";
    private string _description =   "This activity will help you relax by walking you through breathing in and\n" +
                            "out slowly. Clear your mind and focus on your breathing.";
    const int _inBreath = 4;
    const int _outBreath = 6;

    public BreathingActivity() : base()
    {
        return;
    }

    public int DoIt()
    {
        Start(_activityName, _description);
        StartTimer();
        while(!TimeIsUp())
        {
            Breathe();
        }
        int elapsedTime = ElapsedTime();
        Finish();
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