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
    BreathingActivity _ba;

    private int totalTime;
    

    public Mindfulness()
    {
        // instantiate activites here
        _ba = new BreathingActivity();

        totalTime = 0;
        GoGoGo();
    }

    private void GoGoGo()
    {
        string choice = "";
        while(choice != "4")
        {
            choice = GetMenuChoice();
            switch(choice)
            {
                case "1":
                    totalTime += _ba.DoIt();
                    break;
                case "2":
                    Console.WriteLine("2-reflecting");
                    break;
                case "3":
                    Console.WriteLine("3-listing");
                    break;
                case "4":
                    Console.WriteLine($"\nTotal seconds spent in mindfulness activities: {totalTime}\n");
                    break;
                default:
                    Console.WriteLine("oi");
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