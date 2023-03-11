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
        "Which type of Goal would you like to create? ";
    private List<string> _goalMenuChoices = new List<string>{"1", "2", "3", };


    public EternalQuestion()
    {
        _storeGoals = new StoreGoals();
        _goals = new List<Goal>();
        _totalPoints = 0;

        Console.Clear();
        Menu();
    }

    private void ListAllGoals()
    {
        Console.WriteLine("The goals are:");
        for(int i = 0; i < _goals.Count; i++)
        {
            string status = " ";
            if(_goals[i].GetCompletionStatus())
            {
                status = "X";
            }
            Console.WriteLine($"{i + 1}. [{status}] {_goals[i].GetPrintString()}");
        }
    }

    private void DoEvent()
    {
        List<int> available = new List<int>();
        int idx = 0;
        int seq = 0;
        Console.WriteLine("The incomplete goals are:");
        foreach(Goal goal in _goals)
        {
            if(!goal.GetCompletionStatus())
            {
                available.Add(idx);
                Console.WriteLine($"  {seq + 1}. {goal.GetName()}");
                seq += 1;
            }
            idx += 1;
        }
        int sel = GetInt("Which goal did you accomplish?");
        if((sel > seq) || (sel < 1))
        {
            Console.Write($"'{sel}' is not a valid choice!\nIGNORING any accomplishment\nPress <enter> to continue...");
            Console.ReadLine();
        }
        else
        {
            int award = _goals[available[sel - 1]].RecordAnEvent();
            Console.WriteLine($"Congratulations! You have earned {award} points!");
            CalculateTotalPoints();
            Console.WriteLine($"You now have {_totalPoints} points.");
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
                    ListAllGoals();
                    break;
                case "3":
                    _storeGoals.Save(_goals);
                    break;
                case "4":
                    _storeGoals.Load(_goals);
                    CalculateTotalPoints();
                    break;
                case "5":
                    DoEvent();
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
        choice = GetMenuChoice(_goalMenuText, _goalMenuChoices);
        string name = GetString("What is the name of your goal?");
        string description = GetString("What is a short description of it?");
        switch(choice)
        {
            case "1":
                int points = GetInt("How many points will be awarded on completion?");
                SimpleGoal _sg = new SimpleGoal(name, description, points);
                _goals.Add(_sg);
                break;

            case "2":
                points = GetInt("How many points will be awarded each time this is done?");
                EternalGoal _eg = new EternalGoal(name, description, points); 
                _goals.Add(_eg);
                break;

            case "3":
                int expectedEvents = GetInt("How many times do you want to do this?");
                int eventPoints = GetInt("How many points will be awarded each time this is done?");
                int bonusPoints = GetInt("How many bonus points for completing all of them?");
                ChecklistGoal _cg = new ChecklistGoal(name, description, eventPoints, expectedEvents, bonusPoints);
                _goals.Add(_cg);
                break;
        }
        Console.WriteLine($"Goal '{name}' has been added to the list of goals.");
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
        return;
    }


    private string GetString(string prompt)
    {
        Console.Write($"{prompt} ");
        return(Console.ReadLine());
    }

    private int GetInt(string prompt)
    {
        int baz = 0;
        string qux = "";
        while(true)
        {
            Console.Write($"{prompt} ");
            qux = Console.ReadLine();
            if(int.TryParse(qux, out baz))
            {
                break;
            }
            else
            {
                Console.WriteLine($"Nah. '{qux}' doesn't work. I'm looking for a number...");
            }
        }
        return(baz);
    }


}