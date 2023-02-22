using System;

public class ListingActivity : Activity
{
    private string _activityName = "ListingActivity";
    private string _description =
        "This activity will help you reflect on the good things in your life by\n" +
        "having you list as many things as you can in a certain area.";
    private List<string> _prompts = new List<string>{
        "When have you felt the Holy Ghost this month?",
        "When have you seen the hand of the Lord this month?"
    };
    private Random _rnd;

    public ListingActivity() : base()
    {
        _rnd = new Random();
        return;
    }

    public int DoIt()
    {
        Start(_activityName, _description);
        DoPrompt();
        StartTimer();
        int listCount = 0;
        while(TimeRemains())
        {
            Console.Write("> ");
            Console.ReadLine();
            listCount++;
        }
        int elapsedTime = ElapsedTime();
        Console.WriteLine($"You listed {listCount} items!");
        Finish(elapsedTime, _activityName);
        return(elapsedTime);
    }

    private void DoPrompt()
    {
        string prompt = _prompts[_rnd.Next(_prompts.Count)];
        Console.WriteLine($"\nList as many responses as you can to the following prompt:\n --- {prompt} ---");
        Console.Write("You may begin in   ");
        DoCountdown();
        Console.WriteLine();
    }

}