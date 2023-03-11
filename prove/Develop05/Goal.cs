using System;

public abstract class Goal
{
    protected string _name = "";
    protected string _description = "";
    protected int _pointsAccomplished = 0;
    protected bool _completed = false; // goal is completely done
    protected int _eventPoints = 0; // award for completion of the goal

    public Goal()
    {

    }

    public Goal(string name, string description)
    {
        _name = name;
        _description = description;
    }

//    public abstract string GetPrintString();
    public virtual string GetPrintString() // needs override for some goal types
    {
        return($"{_name} ({_description})");
    }

    public abstract int RecordAnEvent(); // each must provide a method to complete an event

    // return a string of fields that can be used to construct an instance of the derived goaltype
    public abstract string[] MakeStorageArray(); 

    // use the storage array to populate attributes in an empty goal object
    public abstract void PopulateFromStorageArray(string[] fields);

    public int GetPointsAccomplished()
    {
        return(_pointsAccomplished);
    }

    public bool GetCompletionStatus()
    {
        return(_completed);
    }

    public string GetName()
    {
        return(_name);
    }
}