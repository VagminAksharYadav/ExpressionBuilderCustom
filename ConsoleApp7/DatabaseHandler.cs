using System;
using MySql.Data.MySqlClient;

namespace ExpressionSolver
{
    internal class DatabaseHandler
    {
        private string connectionString;

        public DatabaseHandler(string server, int port, string database, string username, string password)
        {
            connectionString = $"server={server};port={port};database={database};user={username};password={password};";
        }

        public void SaveEquation(string equationName, string equation)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Save equation to the SavedEquations table
                    string saveEquationQuery = "INSERT INTO SavedEquations (EquationName, Equation) VALUES (@name, @equation)";
                    using (MySqlCommand command = new MySqlCommand(saveEquationQuery, connection))
                    {
                        command.Parameters.AddWithValue("@name", equationName);
                        command.Parameters.AddWithValue("@equation", equation);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void SaveLogEquation(string equation, double result)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Save equation and result to the LogsOfEquations table
                    string saveLogEquationQuery = "INSERT INTO LogsOfEquations (Equation, Result) VALUES (@equation, @result)";
                    using (MySqlCommand command = new MySqlCommand(saveLogEquationQuery, connection))
                    {
                        command.Parameters.AddWithValue("@equation", equation);
                        command.Parameters.AddWithValue("@result", result);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
