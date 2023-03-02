using System;

public class ListingActivity : Activity
{
    private string _activityName = "Listing Activity";
    private string _description =
        "This activity will help you reflect on the good things in your life by\n" +
        "having you list as many things as you can in a certain area.";
    private List<string> _prompts = new List<string>{
        "When have you felt the Holy Ghost this month?",
        "When have you seen the hand of the Lord this month?",
        "Who are the people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?",
    };
    private int _promptsNext = -1;

    public ListingActivity() : base()
    {
    }

    public int DoIt()
    {
        // common header
        base.Start(_activityName, _description);

        // show a prompt to consider
        Console.WriteLine($"\nList as many responses as you can to the following prompt:\n --- {GetPrompt()} ---");
        base.TextWithCountdown("You may begin in: ");
        Console.WriteLine();

        // now get (and drop) input lines until time is up
        int listCount = 0;
        base.StartTimer();
        while(base.TimeRemains())
        {
            Console.Write("> ");
            // only count the item if there was something typed
            if(Console.ReadLine() != "")
            {
                listCount++; // echoes of K&R?
            }
        }
        int elapsedTime = base.ElapsedTime();
        Console.WriteLine($"You listed {listCount} items!");

        // common closer
        base.Finish(elapsedTime, _activityName);
        return(elapsedTime);
    }

    private string GetPrompt()
    {
        // point to the next (previous) prompt in the list
        _promptsNext -= 1;

        // check if the list is exhausted
        if(_promptsNext < 0)
        {
            // (re)shuffle the list and point to the last entry
            base.ShuffleStringList(_prompts);
            _promptsNext = _prompts.Count() - 1;
        }

        // return the current list entry
        return(_prompts[_promptsNext]);

    }

}