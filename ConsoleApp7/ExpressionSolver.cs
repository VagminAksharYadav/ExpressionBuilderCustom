using System;
using NCalc;

namespace ExpressionSolver
{
    internal class ExpressionSolver
    {
        public static bool IsValidExpression(string expression)
        {
            try
            {
                Expression exp = new Expression(expression);
                exp.EvaluateFunction += CustomFunctions; // Add custom functions
                exp.EvaluateParameter += CustomParameters;
                exp.Evaluate();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static double SolveExpression(string expression)
        {
            Expression exp = new Expression(expression);
            exp.EvaluateFunction += CustomFunctions; // Add custom functions
            exp.EvaluateParameter += CustomParameters;
            return Convert.ToDouble(exp.Evaluate());
        }
        private static void CustomParameters(string name, ParameterArgs args)
        {
            if (name.Equals("pi"))
            {
                args.Result = Math.PI;
            }
        }
            private static void CustomFunctions(string name, FunctionArgs args)
        {
            if (name.Equals("sqrt"))
            {
                if (args.Parameters.Length == 1)
                {
                    double value = Convert.ToDouble(args.Parameters[0].Evaluate());
                    args.Result = Math.Sqrt(value);
                }
                else
                {
                    throw new ArgumentException("sqrt function requires exactly one argument.");
                }
            }
            else if (name.Equals("sin"))
            {
                if (args.Parameters.Length == 1)
                {
                    double angle = Convert.ToDouble(args.Parameters[0].Evaluate());
                    args.Result = Math.Sin(angle);
                }
                else
                {
                    throw new ArgumentException("sin function requires exactly one argument (angle in radians).");
                }
            }
            else if (name.Equals("cos"))
            {
                if (args.Parameters.Length == 1)
                {
                    double angle = Convert.ToDouble(args.Parameters[0].Evaluate());
                    args.Result = Math.Cos(angle);
                }
                else
                {
                    throw new ArgumentException("cos function requires exactly one argument (angle in radians).");
                }
            }
            else if (name.Equals("tan"))
            {
                if (args.Parameters.Length == 1)
                {
                    double angle = Convert.ToDouble(args.Parameters[0].Evaluate());
                    args.Result = Math.Tan(angle);
                }
                else
                {
                    throw new ArgumentException("tan function requires exactly one argument (angle in radians).");
                }
            }
            else if (name.Equals("exp"))
            {
                if (args.Parameters.Length == 1)
                {
                    double value = Convert.ToDouble(args.Parameters[0].Evaluate());
                    args.Result = Math.Exp(value);
                }
                else
                {
                    throw new ArgumentException("exp function requires exactly one argument.");
                }
            }
            else if (name.Equals("log"))
            {
                if (args.Parameters.Length == 1)
                {
                    double value = Convert.ToDouble(args.Parameters[0].Evaluate());
                    args.Result = Math.Log(value);
                }
                else
                {
                    throw new ArgumentException("log function requires exactly one argument.");
                }
            }
            else if (name.Equals("log10"))
            {
                if (args.Parameters.Length == 1)
                {
                    double value = Convert.ToDouble(args.Parameters[0].Evaluate());
                    args.Result = Math.Log10(value);
                }
                else
                {
                    throw new ArgumentException("log10 function requires exactly one argument.");
                }
            }
            else if (name.Equals("min"))
            {
                if (args.Parameters.Length == 2)
                {
                    double value1 = Convert.ToDouble(args.Parameters[0].Evaluate());
                    double value2 = Convert.ToDouble(args.Parameters[1].Evaluate());
                    args.Result = Math.Min(value1, value2);
                }
                else
                {
                    throw new ArgumentException("min function requires exactly two arguments.");
                }
            }
            else if (name.Equals("max"))
            {
                if (args.Parameters.Length == 2)
                {
                    double value1 = Convert.ToDouble(args.Parameters[0].Evaluate());
                    double value2 = Convert.ToDouble(args.Parameters[1].Evaluate());
                    args.Result = Math.Max(value1, value2);
                }
                else
                {
                    throw new ArgumentException("max function requires exactly two arguments.");
                }
            }
            else if (name.Equals("avg"))
            {
                if (args.Parameters.Length >= 1)
                {
                    double sum = 0;
                    foreach (Expression expression in args.Parameters)
                    {
                        double value = Convert.ToDouble(expression.Evaluate());
                        sum += value;
                    }
                    double avg = sum / args.Parameters.Length;
                    args.Result = avg;
                    
                }
                else
                {
                    throw new ArgumentException("avg function requires at least one argument.");
                }
            }
            else if (name.Equals("std"))
            {
                if (args.Parameters.Length >= 2)
                {
                    double[] values = new double[args.Parameters.Length];
                    for (int i = 0; i < args.Parameters.Length; i++)
                    {
                        values[i] = Convert.ToDouble(args.Parameters[i].Evaluate());
                    }
                    double mean = values.Average();
                    double sumOfSquaredDifferences = values.Select(val => Math.Pow(val - mean, 2)).Sum();
                    double variance = sumOfSquaredDifferences / (values.Length - 1);
                    args.Result = Math.Sqrt(variance);
                }
                else
                {
                    throw new ArgumentException("std function requires at least two arguments.");
                }
            }
            else if (name.Equals("abs"))
            {
                if (args.Parameters.Length == 1)
                {
                    double value = Convert.ToDouble(args.Parameters[0].Evaluate());
                    args.Result = Math.Abs(value);
                }
            }
            else
            {
             
                throw new ArgumentException($"Function '{name}' is not supported.");
            }
        }

    }
}
