using System;

public abstract class Goal
{
    protected string _name = "";
    protected string _description = "";
    // ?? private string _goalType = ""; // needed?
    protected int _pointsAccomplished = 0;
    protected bool _completed = false; // goal is completely done
    protected int _eventPoints = 0; // award for each completion of the goal
    //
    // these are specific to the different types of goals
    //
    private int _expectedEvents = 0; // number of times this will occur before completion
                                    // 0=Eternal, 1=Simple, >1=Checklist
    private int _completedEvents = 0;
    private int _bonusPoints = 0; // Checklist uses, but could apply to other for other reasons


    public Goal()
    {
        _name = GetString("What is the name of your goal?");
        _description = GetString("What is a short description of it?");
    }

    public Goal(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public string GetString(string prompt)
    {
        Console.Write($"{prompt} ");
        return(Console.ReadLine());
    }

//    public abstract string GetPrintString();
    public virtual string GetPrintString() // needs override for some goal types
    {
        return($"{_name} ({_description})");
    }

    public abstract void RecordAnEvent(); // each must provide a method to complete an event

    // return a string of fields that can be used to construct an instance of the derived goaltype
    public abstract string[] MakeStorageString(); 

    public int GetPointsAccomplished()
    {
        return(_pointsAccomplished);
    }
    public void SetPointsAccomplished(int points)
    {
        _pointsAccomplished = points;
    }

    public bool GetCompletionStatus()
    {
        return(_completed);
    }
    public void SetCompletionStatus(bool status)
    {
        _completed = status;
    }
}