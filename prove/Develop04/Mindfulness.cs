using System;

class Mindfulness
{
    private string _menuText =
        "Menu Options:\n" +
        "  1. Start breathing activity\n" +
        "  2. Start reflecting activity\n" +
        "  3. Start listing activity\n" +
        "  4. Quit\n" +
        "Select a choice from the menu: ";
    private List<string> _validChoices = new List<string>{"1", "2", "3", "4"};
    private BreathingActivity _ba;
    private ReflectingActivity _ra;
    private ListingActivity _la;

    private int totalTime;
    private int _baTime = 0;
    private int _raTime = 0;
    private int _laTime = 0;
    

    public Mindfulness()
    {
        // instantiate activites here
        _ba = new BreathingActivity();
        _ra = new ReflectingActivity();
        _la = new ListingActivity();

        totalTime = 0;
        Menu();
    }

    private void Menu()
    {
        string choice = "";
        while(choice != "4")
        {
            choice = GetMenuChoice();
            switch(choice)
            {
                case "1":
                    _baTime += _ba.DoIt();
                    break;
                case "2":
                    _raTime += _ra.DoIt();
                    break;
                case "3":
                    _laTime += _la.DoIt();
                    break;
                case "4":
                    Console.WriteLine($"\nTotal time spent in mindfulness activities: {totalTime} seconds\n");
                    break;
                default:
                    Console.WriteLine("oy");
                    break;
            }
        }
    }
    
    private string GetMenuChoice()
    {
        string inThing = "";
        while(true)
        {
            Console.Clear();
            Console.WriteLine($"You have completed {_baTime + _raTime + _laTime} seconds of mindfulness activities");
            Console.Write(_menuText);
            inThing = Console.ReadLine();
            if(_validChoices.Contains(inThing))
            {
                break;
            }
            Console.WriteLine($"'{inThing}' isn't a valid choice. Try again...");
        }
        return(inThing);
    }
}