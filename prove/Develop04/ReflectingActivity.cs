using System;

public class ReflectingActivity : Activity
{
    private string _activityName = "ReflectingActivity";
    private string _description =
        "This activity will help you reflect on times in your life when you have\n" +
        "shown strength and resilience. This will help you recognize the power you\n" +
        "have and how you can use it in other aspects of your life.";

    private List<string> _prompts = new List<string>{
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped somebody in trouble."
    };
    private List<string> _questions = new List<string>{
        "How did you feel when this experience was complete?",
        "What is your favorite thing about this experience?",
        "What did you learn from this experience?"
    };
    private Random _rnd;

    public ReflectingActivity() : base()
    {
        _rnd = new Random();
        return;
    }

    public int DoIt()
    {
        Start(_activityName, _description);
        DoPrompt();
        Console.Clear();
        StartTimer();
        while(TimeRemains())
        {
            DoQuestion();
            DoSpinner(10);
        }
        
        int elapsedTime = ElapsedTime();
        Finish(elapsedTime, _activityName);
        return(elapsedTime);
    }

    private void DoPrompt()
    { 
        string prompt = _prompts[_rnd.Next(_prompts.Count)];
        Console.WriteLine($"\nConsider the following prompt:\n\n --- {prompt} ---\n");
        Console.Write("When you have something in mind,  press <enter> to continue ");
        Console.ReadLine();
        Console.WriteLine("\nNow ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may be begin in  ");
        DoCountdown();
    }

    private void DoQuestion()
    {
        string question = _questions[_rnd.Next(_questions.Count)];
        Console.Write($"> {question}  ");
    }


}