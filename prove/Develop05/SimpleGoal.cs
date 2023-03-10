using System;

public class SimpleGoal : Goal
{
    public SimpleGoal() : base()
    {
        string foo = base.GetString("What is the amount of points associated with this goal?");
        base._eventPoints = int.Parse(foo);
    }

    public override void RecordAnEvent()
    {
        base._pointsAccomplished = base._eventPoints;
        base._completed = true;
    }
    public override string[] MakeStorageString()
    {
        return(new string[] 
            {
                base._name,
                base._description,
                $"{base._eventPoints}",
                $"{base._pointsAccomplished}",
                $"{base._completed}"
            }
        );
    }

}