using System;

namespace ExpressionSolver
{
    internal class Program
    {
        static void Main()
        {
            // Provide your MySQL server details here
            string server = "";
            int port = ;
            string database = "";
            string username = "";
            string password = "";

            // Create an instance of DatabaseHandler
            DatabaseHandler databaseHandler = new DatabaseHandler(server, port, database, username, password);

            Console.WriteLine("Expression Solver: [All the functions in () is the Syntax]");
            Console.WriteLine("Supported functionalities:");
            Console.WriteLine("1. Basic arithmetic operators (+, -, *, /)");
            Console.WriteLine("2. Exponentiation (^)");
            Console.WriteLine("3. Square Root (sqrt)");
            Console.WriteLine("4. Trigonometric Functions (sin, cos, tan)");
            Console.WriteLine("5. Exponential Function (exp)");
            Console.WriteLine("6. Logarithmic Functions (log, log10)");
            Console.WriteLine("7. Minimum Function (min)");
            Console.WriteLine("8. Maximum Function (max)");
            Console.WriteLine("9. Average Function (avg)");
            Console.WriteLine("10. Standard Deviation (std)");
            Console.WriteLine("11. π (pi)");
            Console.WriteLine("12. Absolute value (abs)");
            Console.WriteLine("13. Modulus (%)");
            Console.WriteLine("Enter a mathematical expression (e.g., 2+3*(5-1)):");

            string expression = Console.ReadLine();
            bool isValidExpression = ExpressionSolver.IsValidExpression(expression);

            if (isValidExpression)
            {
                double result = ExpressionSolver.SolveExpression(expression);
                Console.WriteLine($"Result: {result}");

                // Save the equation to the LogsOfEquations table
                databaseHandler.SaveLogEquation(expression, result);

                // Check if the user wants to save the equation to the SavedEquations table
                Console.WriteLine("Do you want to save this equation? (yes/no)");
                string saveOption = Console.ReadLine().ToLower();
                if (saveOption == "yes")
                {
                    Console.WriteLine("Enter a name for the equation:");
                    string equationName = Console.ReadLine();

                    // Save the equation to the SavedEquations table
                    databaseHandler.SaveEquation(equationName, expression);
                }
            }
            else
            {
                Console.WriteLine("Invalid expression. Please check the syntax.");
            }
        }
    }
}
