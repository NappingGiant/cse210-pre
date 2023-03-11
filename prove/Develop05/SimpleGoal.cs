using System;

public class SimpleGoal : Goal
{
    public SimpleGoal() : base() {}

    public SimpleGoal(string name, string description, int points) : base(name, description)
    {
        base._eventPoints = points;
    }

    public override int RecordAnEvent()
    {
        base._pointsAccomplished = base._eventPoints;
        base._completed = true;
        return(base._eventPoints);
    }
    public override string[] MakeStorageArray()
    {
        return(new string[] 
            {
                "SG",
                base._name,
                base._description,
                $"{base._eventPoints}",
                $"{base._pointsAccomplished}",
                $"{base._completed}"
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
    }

}