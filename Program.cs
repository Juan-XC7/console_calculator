using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_calculator_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double result = 0; // Initialize the result
            string history = ""; // Initialize calculation history

            while (true)
            {
                UpdateHistoryBoard(history, result);

                bool isHistoryEmpty = history.Length == 0;
                double number1 = isHistoryEmpty ? GetNumber() : result;

                string operation = GetValidOperation();
                double number2 = GetNumber();
                result = CalculateOperation(number1, number2, operation); // Update the result

                history = CreateHistory(history, isHistoryEmpty, number1, number2, operation);
            }
        }

        public static string CreateHistory(string history, bool isHistoryEmpty, double number1, double number2, string operation)
        {
            if (isHistoryEmpty)
            {
                history += number1.ToString() + " " + operation.ToString() + " " + number2.ToString() + " ";
            }
            else
            {
                history += operation.ToString() + " " + number2.ToString() + " ";
            }

            return history;
        }

        public static void UpdateHistoryBoard(string history, double result)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"{history}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Result: {result} \n");
            Console.ResetColor();
        }

        public static double CalculateOperation(double number1, double number2, string operation)
        {
            switch (operation)
            {
                case "+":
                    return number1 + number2;
                case "-":
                    return number1 - number2;
                case "*":
                    return number1 * number2;
                case "/":
                    if (number2 != 0)
                    {
                        return number1 / number2;
                    }
                    else
                    {
                        Console.WriteLine("Cannot divide by zero.");
                        return 0;
                    }
                default:
                    Console.WriteLine($"Invalid operation: {operation}");
                    return double.NaN;
            }
        }

        public static double GetNumber()
        {
            double number;
            bool isValidInput = false;

            do
            {
                Console.Write("Number: ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out number))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            } while (!isValidInput);

            return number;
        }

        public static string GetValidOperation()
        {
            string[] allowedOperations = { "+", "-", "*", "/" };
            string selectedOperation;

            do {
                Console.Write("Select your operation (+, -, *, /): ");
                selectedOperation = Console.ReadLine();

                if (!ArrayContainsValue(allowedOperations, selectedOperation))
                {
                    Console.WriteLine("Invalid operation selected.");
                }
            } while (!ArrayContainsValue(allowedOperations, selectedOperation)) ;

            return selectedOperation;
        }

        static bool ArrayContainsValue(string[] array, string value)
        {
            return Array.IndexOf(array, value) != -1;
        }
    }
}