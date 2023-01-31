using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction t1 = new Fraction();
        Console.WriteLine($"{t1.GetFractionString()}\n{t1.GetDecimalValue()}\n");

        Fraction t2 = new Fraction(5);
        Console.WriteLine($"{t2.GetFractionString()}\n{t2.GetDecimalValue()}\n");

        Fraction t3 = new Fraction(3, 4);
        Console.WriteLine($"{t3.GetFractionString()}\n{t3.GetDecimalValue()}\n");

        Fraction t4 = new Fraction(1, 3);
        Console.WriteLine($"{t4.GetFractionString()}\n{t4.GetDecimalValue()}\n");
    }
}