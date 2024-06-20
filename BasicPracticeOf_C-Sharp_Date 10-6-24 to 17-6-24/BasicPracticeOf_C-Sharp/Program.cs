using BasicPracticeOf_C_Sharp.Calculator;
using BasicPracticeOf_C_Sharp.OOP;
using BasicPracticeOf_C_Sharp.string_manipulation;
using BasicPracticeOf_C_Sharp.Temperature_Converter;
using System;

namespace BasicPracticeOf_C_Sharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                try
                {
                    Console.WriteLine("\nChoose an option:");
                    Console.WriteLine("1. Calculator");
                    Console.WriteLine("2. Temperature Converter");
                    Console.WriteLine("3. String Manipulation");
                    Console.WriteLine("4. OOP Examples Animal");
                    Console.WriteLine("5. OOP Examples Shape");
                    Console.WriteLine("0. Exit");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Calculator();
                            break;
                        case 2:
                            Temperature_Converter();
                            break;
                        case 3:
                            String_Manipulation();
                            break;
                        case 4:
                            OOP_Example_Animal();
                            break;
                        case 5:
                            OOP_Example_Shape();
                            break;
                        case 0:
                            exit = true;
                            Console.WriteLine("Exiting program...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option (1-4).");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();

        }

        private static void OOP_Example_Shape()
        {
            Circle myCircle = new Circle(5);
            Rectangle myRectangle = new Rectangle(3, 4);

            Console.WriteLine($"Circle Area: {myCircle.CalculateArea()}");
            myCircle.Display();
            myCircle.Draw();

            Console.WriteLine();

            Console.WriteLine($"Rectangle Area: {myRectangle.CalculateArea()}");
            myRectangle.Display();
            myRectangle.Draw();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();

        }

        private static void OOP_Example_Animal()
        {
            Dog myDog = new Dog("Buddy", 3, "Labrador");
            Cat myCat = new Cat("Whiskers", 4, true);

            Console.WriteLine($"Name: {myDog.Name}, Age: {myDog.Age}, Breed: {myDog.Breed}");
            myDog.MakeSound();
            myDog.WhichBreed();

            Console.WriteLine($"Name: {myCat.Name}, Age: {myCat.Age}, Islazy: {myCat.IsLazy}");
            myDog.MakeSound();
            myCat.IsItLazy();

            Console.WriteLine();
        }

        private static void String_Manipulation()
        {
            string_manipulation_code string_Manipulation_ = new string_manipulation_code();
            bool exit = false;

            while (!exit)
            {
                try
                {
                    Console.WriteLine("\nChoose an operation to perform:");
                    Console.WriteLine("1. String Length");
                    Console.WriteLine("2. Reverse String");
                    Console.WriteLine("3. Split String with space");
                    Console.WriteLine("4. String Lowercase Conversion");
                    Console.WriteLine("5. String Uppercase Conversion");
                    Console.WriteLine("6. String Concatenation");
                    Console.WriteLine("7. String Comparison");
                    Console.WriteLine("8. Character Count");
                    Console.WriteLine("9. Substring Extraction");
                    Console.WriteLine("0. Exit");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter a string:");
                            string str = Console.ReadLine();
                            Console.WriteLine($"String Length is = {string_Manipulation_.StrLength(str)}");
                            break;
                        case 2:
                            Console.WriteLine("Enter a string:");
                            string reverseStr = Console.ReadLine();
                            Console.WriteLine($"Reverse String is = {string_Manipulation_.StringReverse(reverseStr)}");
                            break;
                        case 3:
                            Console.WriteLine("Enter a sentence:");
                            string splitStr = Console.ReadLine();
                            Console.WriteLine("Split String with space:");
                            string_Manipulation_.String_Splitting_with_space(splitStr);
                            break;
                        case 4:
                            Console.WriteLine("Enter a sentence:");
                            string lowerStr = Console.ReadLine();
                            Console.WriteLine($"String Lowercase Conversion is = {string_Manipulation_.String_Lowercase_Conversion(lowerStr)}");
                            break;
                        case 5:
                            Console.WriteLine("Enter a sentence:");
                            string upperStr = Console.ReadLine();
                            Console.WriteLine($"String Uppercase Conversion is = {string_Manipulation_.String_Uppercase_Conversion(upperStr)}");
                            break;
                        case 6:
                            Console.WriteLine("Enter two strings for concatenation:");
                            Console.Write("String 1: ");
                            string str1 = Console.ReadLine();
                            Console.Write("String 2: ");
                            string str2 = Console.ReadLine();
                            Console.WriteLine($"String Concatenation is = {string_Manipulation_.String_Concatenation(str1, str2)}");
                            break;
                        case 7:
                            Console.WriteLine("Enter two strings for comparison:");
                            Console.Write("String 1: ");
                            string cmpStr1 = Console.ReadLine();
                            Console.Write("String 2: ");
                            string cmpStr2 = Console.ReadLine();
                            Console.WriteLine($"String Comparison is = {string_Manipulation_.String_Comparison(cmpStr1, cmpStr2)}");
                            break;
                        case 8:
                            Console.WriteLine("Enter a string:");
                            string countStr = Console.ReadLine();
                            Console.Write("Enter character to count: ");
                            char charToCount = Console.ReadKey().KeyChar;
                            Console.WriteLine();
                            string_Manipulation_.Character_Count(countStr, charToCount);
                            break;
                        case 9:
                            Console.WriteLine("Enter a string:");
                            string substrStr = Console.ReadLine();
                            Console.Write("Enter start index: ");
                            int start = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter length: ");
                            int length = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Substring is = {string_Manipulation_.Substring_Extraction(substrStr, start, length)}");
                            break;
                        case 0:
                            exit = true;
                            Console.WriteLine("Exiting program...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        private static void Temperature_Converter()
        {
            Temperature_Converter_Code temprature = new Temperature_Converter_Code();
            Console.WriteLine("Enter celsius value:");
            double celsius = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter fahrenheit value:");
            double fahrenheit = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"{celsius}°C is equal to {temprature.CelsiusToFahrenheit(celsius)}°F");

            Console.WriteLine($"{fahrenheit}°F is equal to {temprature.FahrenheitToCelsius(fahrenheit)}°C");

        }

        private static void Calculator()
        {
            try
            {
                CalculatorCode calculator = new CalculatorCode();
                while (true)
                {
                    Console.WriteLine("\nChoose an option:");
                    Console.WriteLine("1. Add");
                    Console.WriteLine("2. Subtract");
                    Console.WriteLine("3. Multiply");
                    Console.WriteLine("4. Divide");
                    Console.WriteLine("5. Exit");

                    var choice = Console.ReadLine();

                    if (choice == "5")
                    {
                        break;
                    }

                    Console.WriteLine("Enter num1:");
                    double num1 = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Enter num2:");
                    double num2 = Convert.ToDouble(Console.ReadLine());


                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine($"Result: {calculator.Add(num1, num2)}");
                            break;
                        case "2":
                            Console.WriteLine($"Result: {calculator.Sub(num1, num2)}");
                            break;
                        case "3":
                            Console.WriteLine($"Result: {calculator.Mul(num1, num2)}");
                            break;
                        case "4":
                            if (num2 == 0)
                            {
                                Console.WriteLine("Cannot divide by zero.");
                            }
                            else
                            {
                                Console.WriteLine($"Result: {calculator.Div(num1, num2)}");
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please choose a valid option.");
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
    }
}
