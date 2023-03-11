using System;


public class ChecklistGoal : Goal
{
    private int _expectedEvents = 0;
    private int _completedEvents = 0;
    private int _bonusPoints = 0;

    public ChecklistGoal() : base() {}

    public ChecklistGoal(string name, string description, int eventPoints, int expectedEvents, int bonusPoints) : base(name, description)
    {
        base._eventPoints = eventPoints; // in this case, per-occurence points, sans bonus
        _expectedEvents = expectedEvents;
        _bonusPoints = bonusPoints;
    }

    public override int RecordAnEvent(int ignore)
    {
        _completedEvents += 1;
        int pointsToAward = base._eventPoints;
        if(_completedEvents >= _expectedEvents)
        {
            base._completed = true;
            pointsToAward += _bonusPoints;
        }
        base._pointsAccomplished += pointsToAward;
        return(pointsToAward);
    }

    public override string GetPrintString()
    {
        return($"{base.GetPrintString()}) --- {_completedEvents}/{_expectedEvents}");
    }

    public override string[] MakeStorageArray()
    {
        return(new string[] 
            {
                "CG",
                base._name,
                base._description,
                $"{base._eventPoints}",
                $"{base._pointsAccomplished}",
                $"{base._completed}",
                $"{_expectedEvents}",
                $"{_completedEvents}",
                $"{_bonusPoints}"
            }
        );
    }

    public override void PopulateFromStorageArray(string[] fields)
    {
        base._name = fields[1];
        base._description = fields[2];
        base._eventPoints = int.Parse(fields[3]);
        base._pointsAccomplished = int.Parse(fields[4]);
        base._completed = bool.Parse(fields[5]);
        _expectedEvents = int.Parse(fields[6]);
        _completedEvents = int.Parse(fields[7]);
        _bonusPoints = int.Parse(fields[8]);
    }

}