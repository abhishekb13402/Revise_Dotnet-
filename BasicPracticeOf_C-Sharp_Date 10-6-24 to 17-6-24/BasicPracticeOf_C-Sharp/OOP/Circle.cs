using System;

namespace BasicPracticeOf_C_Sharp.OOP
{
    public class Circle : Shape, IDrawable
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing Circle with Radius = {Radius}");
        }
    }
}
