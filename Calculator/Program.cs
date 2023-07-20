using Calculator;

namespace Calculator;
public class Program
{
    public static void Main(String[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Enter your operation:");
            string operation = Console.ReadLine();
            try
            {
                double result = new Operator().EvaluateExpression(operation);
                Console.WriteLine($"Result is {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Do you want to continue? (y or n):");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "y")
            {
                exit = true;
            }
            else
            {
                exit = false;
            }
        }

        Console.WriteLine("Exit program.");
    }
}