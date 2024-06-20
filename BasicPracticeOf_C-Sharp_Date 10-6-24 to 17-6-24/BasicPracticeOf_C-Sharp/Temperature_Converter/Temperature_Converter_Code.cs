namespace BasicPracticeOf_C_Sharp.Temperature_Converter
{
    public class Temperature_Converter_Code
    {
        public double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }

        public double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }
}
