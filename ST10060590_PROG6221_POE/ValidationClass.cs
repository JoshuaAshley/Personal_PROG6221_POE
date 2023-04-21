//created a namespace to hold all potential validation classes
namespace DataValidation
{
    //class code subject to change when the nature of the project changes from a console app to a GUI.
    public class Validation
    {
        //a method that validates a console input to ensure the correct format of a positive integer has been typed
        //also returns the correct validated input
        public int? GetValidInteger(string message)
        {
            //nullable variable
            int? value = null;

            //while the variable is null
            while (value == null)
            {
                //iput message
                Console.Write(message);
                //input
                string input = Console.ReadLine();

                //if the input is blank
                if (string.IsNullOrWhiteSpace(input))
                {
                    //sets the text console color to an error message indication color
                    Console.ForegroundColor = ConsoleColor.Red;
                    //error message
                    Console.WriteLine("Input cannot be null. Please try again.");
                    //resets the text console color
                    Console.ForegroundColor = ConsoleColor.Gray;
                    //run the while loop again
                    continue;
                }

                //tries to parse the value as an integer
                if (int.TryParse(input, out int result))
                {
                    //if the result of the parsed integer is a negative value
                    if (result < 0)
                    {
                        //sets the text console color to an error message indication color
                        Console.ForegroundColor = ConsoleColor.Red;
                        //error message
                        Console.WriteLine("Invalid input. Please enter a positive integer.");
                        //resets the text console color
                        Console.ForegroundColor = ConsoleColor.Gray;
                        //run the while loop again
                        continue;
                    }
                    //if parsed correctly and the result is positive, the value becomes the result
                    value = result;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    //sets the text console color to an error message indication color
                    Console.ForegroundColor = ConsoleColor.Red;
                    //if it cannot be parsed correctly, error message
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    //resets the text console color
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }

            //returns the correct value after going through full validation
            return value;
        }

        //a method that validates a console input to ensure the correct format of a positive double has been typed
        //also returns the correct validated input
        public static double? GetValidDouble(string message)
        {
            //nullable variable
            double? value = null;

            //while the variable is null
            while (value == null)
            {
                //input message
                Console.Write(message);
                //input
                string input = Console.ReadLine();

                //if the input is blank
                if (string.IsNullOrWhiteSpace(input))
                {
                    //sets the text console color to an error message indication color
                    Console.ForegroundColor = ConsoleColor.Red;
                    //error message
                    Console.WriteLine("Input cannot be null. Please try again.");
                    //resets the text console color
                    Console.ForegroundColor = ConsoleColor.Gray;
                    //run the while loop again
                    continue;
                }

                //tries to parse the value as a double
                if (double.TryParse(input, out double result))
                {
                    //if the result of the parsed double is a negative value
                    if (result < 0)
                    {
                        //sets the text console color to an error message indication color
                        Console.ForegroundColor = ConsoleColor.Red;
                        //error message
                        Console.WriteLine("Invalid input. Please enter a positive number.");

                        Console.ForegroundColor = ConsoleColor.Gray;
                        //run the while loop again
                        continue;
                    }
                    //if parsed correctly and the result is positive, the value becomes the result
                    value = result;
                }
                else
                {
                    //sets the text console color to an error message indication color
                    Console.ForegroundColor = ConsoleColor.Red;
                    //if it cannot be parsed correctly, error message
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }

            //returns the correct value after going through full validation
            return value;
        }

        //a method that validates a console input to ensure the correct format of a positive number or fraction has been typed
        //also returns the correct validated input
        public float ConvertFractionToFloat(string inputMessage)
        {
            //input message
            Console.Write(inputMessage);

            //while true, basically being an infinite loop
            while (true)
            {
                //input
                string fraction = Console.ReadLine();

                //float variable
                float result;

                //tries to parse the value as a float
                if (float.TryParse(fraction, out result))
                {
                    //if the result of the parsed double is a positive value
                    if (result >= 0)
                    {
                        //return the result and break the while loop, acts as a loop condition
                        //this will only happen with valid floats that do not have fractions included in the input
                        return result;
                    }
                    else
                    {
                        //sets the text console color to an error message indication color
                        Console.ForegroundColor = ConsoleColor.Red;
                        //error message
                        Console.Write("Invalid input. Please enter a non-negative number: ");
                        //resets the text console color
                        Console.ForegroundColor = ConsoleColor.Gray;
                        //run the while loop again
                        continue;
                    }
                }

                //this code will take place when the input includes fractions
                //the input uses the split function to create a string array of lengths up to 3
                string[] split = fraction.Split(new char[] { ' ', '/' });

                //if the length is either 2 or 3
                if (split.Length == 2 || split.Length == 3)
                {
                    //two variables are created which are used to determine the float from the fraction
                    int a, b;

                    //tries to parse the first two indexes as integer values 
                    if (int.TryParse(split[0], out a) && int.TryParse(split[1], out b))
                    {
                        //if parsed correclty and the length of the array is 2, that means the input has to be a fraction only
                        if (split.Length == 2)
                        {
                            //checks if both results from the parse are positive integers
                            if (a >= 0 && b >= 0)
                            {
                                //if so, then the result of the quotent of a and be can be casted to a float value and returned, which ends the inifinite loop
                                return (float)a / b;
                            }
                            else
                            {
                                //sets the text console color to an error message indication color
                                Console.ForegroundColor = ConsoleColor.Red;
                                //error message
                                Console.Write("Invalid input. Please enter non-negative integers: ");
                                //resets the text console color
                                Console.ForegroundColor = ConsoleColor.Gray;
                                //restart the while loop
                                continue;
                            }
                        }

                        //only occurs when the input has a number AND a fraction value
                        //third variable is created to store the final integer in the fraction input
                        int c;

                        //since this code is running, it means that the length of the array has to be 3
                        //tries to parse the value in the last index as an integer
                        if (int.TryParse(split[2], out c))
                        {
                            //if all variables are positive integers
                            if (a >= 0 && b >= 0 && c > 0)
                            {
                                //before a and b were values in the fraction, however now since c is the final value in the array, that means a is actually the number now, and b and c are the values in the fraction
                                //this means that a can be added to typcasted quotent of b and c and returned to get the float value, and the return will end the infinite loop
                                return a + (float)b / c;
                            }
                            else
                            {
                                //sets the text console color to an error message indication color
                                Console.ForegroundColor = ConsoleColor.Red;
                                //error message
                                Console.Write("Invalid input. Please enter non-negative integers and a positive denominator: ");
                                //resets the text console color
                                Console.ForegroundColor = ConsoleColor.Gray;
                                //restart the while loop
                                continue;
                            }
                        }
                    }
                }

                //sets the text console color to an error message indication color
                Console.ForegroundColor = ConsoleColor.Red;
                //else error message
                Console.Write("Not a valid fraction. Please enter in the form of (E.g. 1 1/3): ");
                //resets the text console color
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}