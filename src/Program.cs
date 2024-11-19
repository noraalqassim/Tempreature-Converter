class Program
{
    //Basic conversion
    static string TempConvert(double temperature, string originalUnit)
    {
        double convertedTemp = 0;
        string newUnit;
        //To convert from Celsius to Fahrenheit: F = (C * 9) / 5 + 32;
        if (originalUnit == "C")
        {
            convertedTemp = temperature * 9 / 5 + 32;
            newUnit = "F";
            } 
        //To convert from Fahrenheit to Celsius: C = (F – 32) * 5 / 9;
        else 
        {
            convertedTemp = (temperature - 32) * 5 / 9;
            newUnit = "C";
        }

        return $"{convertedTemp.ToString()} {newUnit}";
    }
    
    static void Main()
    {
      //Level 1: Basic conversion
        Console.WriteLine("Level 1 Output ");
        Console.WriteLine(TempConvert(32, "F")); 
        Console.WriteLine(TempConvert(100, "C")); 

        Console.WriteLine("Level 2 and 3 Output ");
      //Level 2: Additional requirement: Asking for user input
        while (true)
        {
            Console.WriteLine("Enter a temperature and its unit (C or F), or type 'Quit' to exit:");
            string input = Console.ReadLine();
        //Level 3: Advanced requirement: Continuous interaction
            if (input.Equals("Quit", StringComparison.OrdinalIgnoreCase)) //I use "StringComparison.OrdinalIgnoreCase" method becuse I don't know what the user will enter "Quit", "quit" or "QUIT".
            {
                Console.WriteLine("Program terminated.");
                break;
            }

            string[] inputParts = input.Split(' '); //Split the string into two parts

            if (inputParts.Length != 2)
            {
                Console.WriteLine("Invalid input format.");
                continue; 
            }

            if (!double.TryParse(inputParts[0],
                    out var temperature)) //"double.TryParse" method : to conver string to double number
            {
                Console.WriteLine("**Invalid input**. Please enter a numeric temperature.");
                continue; 
            }

            var unit = inputParts[1].ToUpper();
            if (unit != "C" && unit != "F")
            {
                Console.WriteLine("**Invalid scale**. Please enter 'C' for Celsius or 'F' for Fahrenheit.");
                continue; 
            }

            var result = TempConvert(temperature, unit);
            Console.WriteLine($"Converted: {input} = {result}");
        }
    }
}
