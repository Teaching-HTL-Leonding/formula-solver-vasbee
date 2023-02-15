
System.Console.WriteLine("Enter formula: ");
string formula = Console.ReadLine()!;
int result = Evaluate(formula);
System.Console.WriteLine($"The result is {result}");

int Evaluate(string formula)
{
    int result = 0;
    formula = formula.Replace(" ", ""); 

    if (formula == "") { return 0; }
    bool minus = formula.Contains('-'); 
    bool plus = formula.Contains('+');

    if (!minus && !plus) { return int.Parse(formula); } 
    int indexOfOperator;
    char op = '+';

    do
    {
        indexOfOperator = FindIndexOfNextOperator(formula);

        if (indexOfOperator == -1)
        {
            if (op == '+') { result += int.Parse(formula); }
            else { result -= int.Parse(formula); }
        }
        else
        {
            string leftFormula = formula.Substring(0, indexOfOperator);
            if (op == '+') { result += int.Parse(leftFormula); }
            else { result -= int.Parse(leftFormula); }

            op = formula[indexOfOperator];
            formula = formula.Substring(indexOfOperator + 1);
        }

    } while (indexOfOperator != -1);

    return result;

}

int FindIndexOfNextOperator(string formula)
{
    int indexOfPlus = formula.IndexOf('+');
    int indexOfMinus = formula.IndexOf('-');

    if (indexOfPlus == -1) { return indexOfMinus; }
    if (indexOfMinus == -1) { return indexOfPlus; }

    return Math.Min(indexOfMinus, indexOfPlus);
}