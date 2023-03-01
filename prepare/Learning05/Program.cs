using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning05 World!");

        Test();
    }

    static void Test()
    {
        List<Shape> _shapes = new List<Shape>();

        _shapes.Add(new Square("Blue", 12));
        _shapes.Add(new Rectangle("Green", 8, 4));
        _shapes.Add(new Circle("Red", 10));

        foreach(Shape shape in _shapes)
        {
            Console.WriteLine($"The {shape.GetColor()} {shape.GetType()} has an area of {shape.GetArea()}");
        }

    }
}