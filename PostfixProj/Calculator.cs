using MyStackProj;

namespace PostfixProj;

public class PostfixCalculator
{
    public static int Evaluate(string expression)
    {
        var stack = new MyStack<int>();
        var tokens = expression.Split(' ');

        foreach (var token in tokens)
        {
            if (int.TryParse(token, out int number))
            {
                stack.Push(number);
            }
            else
            {
                int b = stack.Pop();
                int a = stack.Pop();

                switch (token)
                {
                    case "+":
                        stack.Push(a + b);
                        break;
                    case "-":
                        stack.Push(a - b);
                        break;
                    case "*":
                        stack.Push(a * b);
                        break;
                    case "/":
                        stack.Push(a / b);
                        break;
                }
            }
        }

        return stack.Pop();
    }
}
