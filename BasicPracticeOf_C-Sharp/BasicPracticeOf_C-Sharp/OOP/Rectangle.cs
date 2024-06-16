using System;

namespace BasicPracticeOf_C_Sharp.OOP
{
    public class Rectangle : Shape,IDrawable
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public override double CalculateArea()
        {
            return Length * Width;
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing Rectangle with Length = {Length} and Width = {Width}");
        }
    }
}
