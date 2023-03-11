using System;
using System.IO;

public class StoreGoals
{
    private string _delim = "⁞";

    public StoreGoals()
    {

    }

    public void Save(List<Goal> goalList)
    {
        string filename = GetFileName();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach(Goal goal in goalList)
            {
                string[] goalArray = goal.MakeStorageArray();
                string goalLine =  String.Join(_delim, goalArray);
                outputFile.WriteLine(goalLine);
            }
        }

    }

    public void Load(List<Goal> goalList)
    // https://stackoverflow.com/questions/4311226/list-passed-by-ref-help-me-explain-this-behaviour
    {
        string filename = "";
        bool success = false;
        string[] inlines = {};
        while(success == false)
        {
            filename = GetFileName();
            try
            {
                inlines = System.IO.File.ReadAllLines(filename);
                success = true;
            }
            catch(Exception e)
            {
                Console.WriteLine($"{filename} could not be read");
                Console.WriteLine(e.Message, e.GetType());
                Console.WriteLine($"Try a valid filename...");
            }
        }

        // ok, got the data, now make the List
        //List<Goal> goalList = new List<Goal>();
        goalList.Clear();
        foreach(string line in inlines)
        {
            string[] fields = line.Split(_delim);
            switch(fields[0])
            {
                case "SG":
                    SimpleGoal sg = new SimpleGoal();
                    sg.PopulateFromStorageArray(fields);
                    goalList.Add(sg);
                    break;
                
                case "EG":
                    EternalGoal eg = new EternalGoal();
                    eg.PopulateFromStorageArray(fields);
                    goalList.Add(eg);
                    break;

                case "CG":
                    ChecklistGoal cg = new ChecklistGoal();
                    cg.PopulateFromStorageArray(fields);
                    goalList.Add(cg);
                    break;
                default:
                    throw new ArgumentException();
            }

        }
        return;
    }

    public string GetFileName()
    {
        string filename = "";
        while(filename == "")
        {
            Console.Write($"Enter a filename > ");
            filename = Console.ReadLine();
            if(filename == "")
            {
                Console.WriteLine($"A filename is required!");
            }
        }
        return(filename);
    }

}