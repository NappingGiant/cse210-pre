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
        "What did you learn from this experience?",
        "How did the Lord prepare you for this experience?",
    };

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
        // TODO: don't reuse until the entire list has been used
        string prompt = _prompts[_rnd.Next(_prompts.Count)];
        return(prompt);
    }

    private string GetRandomQuestion()
    {
        // TODO: don't reuse until the entire list has been used
        string question = _questions[_rnd.Next(_questions.Count)];
        return(question);
    }
}