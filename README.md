# ExpressionBuilderC#
This is an ExpressionBuilder I built to handle low level logic to built custom equations that can be saved
  The following functions are supported:
-  Modulus (%)
-  Exponentiation (^)
-  Square Root (sqrt)
-  Trigonometric Functions (sin, cos, tan)
-  Logarithmic Functions (log, log10)
-  Minimum Function (min)
-  Maximum Function (max)
-  Average Function (avg)
-  Standard Deviation (std)
-  π (pi)
-  Absolute value (abs)
-  Basic arithmetic operators (+, -, *, /)

Entire code was written in C# [.NET 6.0]

You can make custom equations like this here:
(2 + 3 * (5 - 1)) / (4 + (8 / 2) * (3 + 1)) - (6 - (7 * (8 + 9))) * (((10 - 11) + 12) / 13 - (14 * 15)) + exp(2) + log(10) - log10(100) + sqrt(25) + sin(0.5) + cos(1) - tan(0.8) + min(3, 7) + max(10, 20) + avg(2, 5, 8, 11, 14) + std(10, 11, 11, 12313) + pi

The above equation is an example you can use any equation you want after running this. I added database logic which you can change to your requirements.
The code is extendable just go to the ExpressionSolver.cs to add more functionaility. 

Now you might be wondering what is the point of saving the equation to a database. I made a python script to pull the equation data and replace all numbers without changing syntax with variables and save it to another table so when called a person can just input the variables to reuse the equation. This was intended to be used by offices that have custom calculations that need to be done and can be reused later on.

The output of the above equation which made it into variables is here:
(A1 + A2 * (A3 - A4)) / (A5 + (A6 / A7) * (A8 + A9)) - (A10 - (A11 * (A12 + A13))) * (((A14 - A15) + A16) / A17 - (A18 * A19)) + exp(A20) + log(A21) - log10(A22) + sqrt(A23) + sin(A24) + cos(A25) - tan(A26) + min(A27, A28) + max(A29, A30) + avg(A31, A32, A33, A34, A35) + std(A36, A37, A38, A39) + pi

I have provided the PythonScript.py. Run that seperately or embed it into your application. I did not insert the equation into any database just printed the output.
If you would like to add that you would be welcome to.

If theres any issues in the code breaking or not successfully working. You can contact me through vagminaksharyadav@gmail.com. 
Please remember the database used here was MySQL Workbench. If you want to use another database configure it correctly.

As you can see now all you would have to do is replace the variables to reuse the equation.
