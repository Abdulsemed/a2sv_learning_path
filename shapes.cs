using System;
using System.Diagnostics;

class MainClass
{
    public class Shape
    {
        private string Name = "unknown";
        public Shape(string name)
        {
            Name = name;
        }

        public string getName() { return $"The shape is {Name}"; }
        public virtual double CalculateArea()
        {
            return 0;
        }
    }
    public class Circle : Shape
    {
        private double Radius;
        public Circle(double radius, string name):base(name)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius*Radius;
        }
    }
    public class Rectangle : Shape
    {
        private double Width;
        private double Height;

        public Rectangle(double width, double height, string name):base(name)
        {
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }
    public class Triangle : Shape
    {
        private double Base;
        private double Height;

        public Triangle(double _base, double height, string name) : base(name)
        {
            Base = _base;
            Height = height;
        }
        public override double CalculateArea()
        {
            return (Base * Height) / 2;
        }
    }

    public void PrintShapeArea( Shape obj)
    {
        Console.WriteLine(obj.getName());
        Console.WriteLine("The area is "
            + obj.CalculateArea());
    }

    public static void Main(string[] args)
    {
        MainClass mainClass = new MainClass();

        Circle circle = new Circle(12, "circle");
        mainClass.PrintShapeArea(circle);

        Rectangle rectangle = new Rectangle(10, 5, "rectangle");
        mainClass.PrintShapeArea(rectangle);

        Triangle triangle = new Triangle(5, 4, "Triangle");
        mainClass.PrintShapeArea(triangle);

    }


}
