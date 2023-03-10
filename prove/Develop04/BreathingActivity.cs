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
        // common opener
        base.Start(_activityName, _description);

        // jump right in
        base.StartTimer();
        while(base.TimeRemains())
        {
            Breathe(); // breath in, breath out, turn purple
        }
        int elapsedTime = base.ElapsedTime();

        // common closer
        base.Finish(elapsedTime, _activityName);
        return(elapsedTime);
    }

    private void Breathe()
    {
        TextWithCountdown("\nBreathe in...", _inBreath);
        TextWithCountdown("Now breathe out...", _outBreath);
    }


}