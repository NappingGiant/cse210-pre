using System;

public class EternalQuestion
{
    private StoreGoals _storeGoals;
    private List<Goal> _goals;
    private int _totalPoints;
    private string _mainMenuText = 
        "\nYou have {0} points.\n\n" +
        "Menu Options: \n" +
        "  1. Create New Goal\n" +
        "  2. List Goals\n" +
        "  3. Save Goals\n" +
        "  4. Load Goals\n" +
        "  5. Record Event\n" +
        "  6. Quit\n" +
        "Select a choice from the menu: ";
    private List<string> _mainMenuChoices = new List<string>{"1", "2", "3", "4", "5", "6"};
    private string _goalMenuText =
        "The types of Goals are:\n" +
        "  1. Simple Goal\n" +
        "  2. Eternal Goal\n" +
        "  3. Checklist Goal\n" +
        "  4. Oops, don't want to add right now\n" +
        "Which type of Goal would you like to create? ";
    private List<string> _goalMenuChoices = new List<string>{"1", "2", "3", "4"};


    public EternalQuestion()
    {
        _storeGoals = new StoreGoals();
        _goals = new List<Goal>();
        _totalPoints = 0;

        Console.Clear();
        Menu();
    }

    private void ListGoals()
    {
        Console.WriteLine("The goals are:");
        for(int i = 0; i < _goals.Count; i++)
        {
            string status = " ";
            if(_goals[i].GetCompletionStatus())
            {
                status = "X";
            }
            Console.WriteLine($"{i}. [{status}] {_goals[i].GetPrintString()}");

        }

    }

    private void Menu()
    {
        string choice = "";
        while(choice != "6")
        {
            choice = GetMenuChoice(_mainMenuText, _mainMenuChoices);
            switch(choice)
            {
                case "1":
                    GoalMenu();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    _storeGoals.Save(_goals);
                    break;
                case "4":
                    _storeGoals.Load(_goals);
                    CalculateTotalPoints();
                    break;
                case "5":
                    Console.WriteLine("Record Event not implemented yet");
                    CalculateTotalPoints();
                    break;
                case "6":
                    Console.WriteLine($"\nYou have {_totalPoints} points.\nGoodbye!");
                    break;
                default:
                    Console.WriteLine("oy");
                    break;
            }
        }
    }

    private void GoalMenu()
    {
        string choice = "";
        while(choice != "4")
        {
            choice = GetMenuChoice(_goalMenuText, _goalMenuChoices);
            switch(choice)
            {
                case "1":
                SimpleGoal _sg = new SimpleGoal();
                
                _goals.Add(_sg);
                choice = "4"; // ok, we're done here (AWKWARD!)
                break;

                case "2":
                EternalGoal _eg = new EternalGoal();
                
                _goals.Add(_eg);
                choice = "4";
                break;

                case "3":
                ChecklistGoal _cg = new ChecklistGoal();
                
                _goals.Add(_cg);
                choice = "4";
                break;
            }
        }
    }
    
    private string GetMenuChoice(string menuText, List<string> validChoices)
    {
        string choice = "";
        while(true)
        {
            Console.Write(string.Format(menuText, _totalPoints));
            choice = Console.ReadLine();
            if(validChoices.Contains(choice))
            {
                break;
            }
            Console.WriteLine($"'{choice}' isn't a valid choice. Try again...");
        }
        return(choice);
    }

    private void CalculateTotalPoints()
    {
        _totalPoints = 0;
        foreach(Goal goal in _goals)
        {
            _totalPoints += goal.GetPointsAccomplished();
        }

    }

}