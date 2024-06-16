using System;

namespace BasicPracticeOf_C_Sharp.OOP
{
    public abstract class Shape
    {
        public abstract double CalculateArea();

        // Concrete method
        public void Display()
        {
            Console.WriteLine("Displaying shape details");
        }
    }
}
