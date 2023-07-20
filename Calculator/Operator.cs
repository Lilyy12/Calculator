namespace Calculator
{
    public class Operator
    {
        public Operator()
        {
        }
        public double EvaluateExpression(string expression)
        {
            return ParseAddSubtract(expression);
        }

        private double ParseAddSubtract(string expression)
        {
            int index = 0;
            double left = ParseMultiplyDivide(expression, ref index);

            while (index < expression.Length)
            {
                char operation = expression[index++];

                if (operation == '+')
                    left += ParseMultiplyDivide(expression, ref index);
                else if (operation == '-')
                    left -= ParseMultiplyDivide(expression, ref index);
            }

            return left;
        }

        private double ParseMultiplyDivide(string expression, ref int index)
        {
            double left = ParseUnary(expression, ref index);

            while (index < expression.Length)
            {
                char operation = expression[index];

                if (operation != '*' && operation != '/')
                    break;

                index++;
                double right = ParseUnary(expression, ref index);

                if (operation == '*')
                    left *= right;
                else if (operation == '/')
                    left /= right;
            }

            return left;
        }

        private double ParseUnary(string expression, ref int index)
        {
            char operation = expression[index];
            if (operation == '-')
            {
                index++;
                return -ParseNumber(expression, ref index);
            }
            else
            {
                return ParseNumber(expression, ref index);
            }
        }

        private double ParseNumber(string expression, ref int index)
        {
            string number = "";
            while (index < expression.Length && (char.IsDigit(expression[index]) || expression[index] == '.'))
            {
                number += expression[index++];
            }

            return double.Parse(number);
        }
    }
}
