class Program
{
    static void Main(string[] args)
    {
        var square = new Square("blue", 5);
        Console.WriteLine(square.GetColor());
        Console.WriteLine(square.GetArea());

        var rectangle = new Rectangle("green", 10, 20);
        Console.WriteLine(rectangle.GetColor());
        Console.WriteLine(rectangle.GetArea());

        var circle = new Circle("red", 10);
        Console.WriteLine(circle.GetColor());
        Console.WriteLine(circle.GetArea());

        var shapes = new List<Shape>
        {
            square, rectangle, circle
        };

        foreach (var shape in shapes)
        {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
        }
    }
}
