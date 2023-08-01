import re
import mysql.connector

def parse_equation(equation):
    #Regular expression pattern to find numbers and function names in the equation
    pattern = r'\b\d+(\.\d+)?\b|\b(?:exp|log10|log|sqrt|sin|cos|tan|min|max|avg|std|pi)\b'

    #List of variables to replace numbers
    variables = ['A{}'.format(i+1) for i in range(equation.count('0')+equation.count('1')+equation.count('2')+equation.count('3')+equation.count('4')+equation.count('5')+equation.count('6')+equation.count('7')+equation.count('8')+equation.count('9'))]

    #Dictionary of function names that should not be replaced
    function_names = {
        'exp', 'log10', 'log', 'sqrt', 'sin', 'cos', 'tan', 'min', 'max', 'avg', 'std', 'pi'
    }

    def replace_match(match):
        #Get the matched string
        match_str = match.group(0)

        #If the matched string is in the function_names dictionary, return it as it is
        if match_str in function_names:
            return match_str

        #Otherwise, replace the number with the variable name
        return variables.pop(0) if variables else match_str

    #Replace numbers with variables in the equation
    parsed_equation = re.sub(pattern, replace_match, equation)

    return parsed_equation
#Database configuration for local MySQL server
db_config = {
    'host': '',
    'port': ,
    'user': '',
    'password': '',
    'database': '',
}

# Connect to the local MySQL database
conn = mysql.connector.connect(**db_config)
cursor = conn.cursor()

try:
    #Fetch equations from the SavedEquations table
    cursor.execute("SELECT equation FROM SavedEquations")
    equations = cursor.fetchall()

    #Process each equation and print the parsed result
    for equation in equations:
        parsed_equation = parse_equation(equation[0])
        print(parsed_equation)

except Exception as e:
    print("Error:", e)

finally:
    # Close the database connection
    cursor.close()
    conn.close()
