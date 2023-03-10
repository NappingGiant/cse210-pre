using System;


public class ChecklistGoal : Goal
{
    private int _expectedEvents = 0;
    private int _completedEvents = 0;
    public ChecklistGoal() : base()
    {

    }

    public override void RecordAnEvent()
    {
        
    }

    public override string GetPrintString()
    {
        return($"{base.GetPrintString()}) --- {_completedEvents}/{_expectedEvents}");
    }

}