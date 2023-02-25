using System;

public class ReflectingActivity : Activity
{
    private string _activityName = "Reflecting Activity";
    private string _description =
        "This activity will help you reflect on times in your life when you have\n" +
        "shown strength and resilience. This will help you recognize the power you\n" +
        "have and how you can use it in other aspects of your life.";

    private List<string> _prompts = new List<string>{
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped somebody in trouble.",
        "Think of a time when you followed through with a promise even though it required sacrifice on your part",
        "Think of a time when you stood up for someone else.",
        "Think of a time when you helped somone in need",
        "Think of a time when you did something truly selfless",
    };
    private int _promptsNext = -1;
    private List<string> _questions = new List<string>{
        "How did you feel when this experience was complete?",
        "What is your favorite thing about this experience?",
        "What did you learn from this experience?",
        "How did the Lord prepare you for this experience?",
        "How would it help your family to journal this experience?",
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "What made this time different than other times when you were not as successful?",
        "What could you learn from this experience that applies to other situations?",
        "How can you keep this experience in mind in the future?",
    };
    private int _questionsNext = -1;

    public ReflectingActivity() : base()
    {
    }

    public int DoIt()
    {
        // common header
        Start(_activityName, _description);

        // show prompt and wait for <enter>
        string prompt = GetRandomPrompt();
        Console.WriteLine($"\n\nConsider the following prompt:\n\n --- {prompt} ---\n");
        Console.Write("When you have something in mind,  press <enter> to continue ");
        Console.ReadLine();

        // stage 2: prompt to ponder question
        Console.WriteLine("\nNow ponder on each of the following questions as they relate to this experience.");
        TextWithCountdown("You may begin in", 5);

        // now show questions, pausing for 10 seconds each
        Console.Clear();
        StartTimer();
        while(TimeRemains())
        {
            TextWithSpinner($"> {GetRandomQuestion()} ", 10);
        }
        
        // time is up, get total elapsed, display common closing and return total elapse
        int elapsedTime = ElapsedTime();
        Finish(elapsedTime, _activityName);
        return(elapsedTime);
    }

    private string GetRandomPrompt()
    {
        // point to the next (previous) prompt in the list
        _promptsNext -= 1;

        // check if the list is exhausted
        if(_promptsNext < 0)
        {
            // (re)shuffle the list and point to the last entry
            ShuffleStringList(_prompts);
            _promptsNext = _prompts.Count() - 1;
        }

        // return the current list entry
        return(_prompts[_promptsNext]);

    }

    private string GetRandomQuestion()
    {
        // point to the next (previous) prompt in the list
        _questionsNext -= 1;

        // check if the list is exhausted
        if(_questionsNext < 0)
        {
            // (re)shuffle the list and point to the last entry
            ShuffleStringList(_questions);
            _questionsNext = _questions.Count() - 1;
        }

        // return the current list entry
        return(_questions[_questionsNext]);
    }
}