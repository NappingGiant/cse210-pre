using System;

public class LevelGoal: Goal
{
    private int _threshhold = 0;
    public LevelGoal() : base() {}

    public LevelGoal(string name, string description, string reward, int threshhold) : base(name, description)
    {
        base._name = name;
        base._description = description;
        base._eventPoints = 0; // no new points...this is a physical reward :o
        base._reward = reward;
        _threshhold = threshhold;
    }

    public override int RecordAnEvent(int totalPoints)
    {
        if(totalPoints >= _threshhold)
        {
            base._completed = true;
        }
        return(0);
    }

    public override string GetPrintString()
    {
        return($"{base.GetPrintString()}) --- (at {_threshhold} points)");
    }

     public override string[] MakeStorageArray()
    {
        return(new string[] 
            {
                "LG",
                base._name,
                base._description,
                $"{base._eventPoints}",
                $"{base._pointsAccomplished}",
                $"{base._completed}",
                base._reward,
                $"{_threshhold}"
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
        base._reward = fields[6];
        _threshhold = int.Parse(fields[7]);
    }

    public int GetThreshhold()
    {
        return(_threshhold);
    }
}