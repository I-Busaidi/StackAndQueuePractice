using System.Collections;
using System.Text;

namespace StackAndQueue
{
    internal class Program
    {
        static void PostfixExpression()
        {
            int FirstNo;
            int LastNo;
            float result;
            string UserInput;
            Stack<int> stack = new Stack<int>();
            Console.WriteLine("Enter the postfix expression to calculate:");
            UserInput = Console.ReadLine();
            for (int i = 0; i < UserInput.Length; i++)
            {
                if (UserInput[i] == '*')
                {
                    FirstNo = stack.Pop();
                    LastNo = stack.Pop();
                    stack.Push(LastNo * FirstNo);
                }
                else if (UserInput[i] == '+')
                {
                    FirstNo = stack.Pop();
                    LastNo = stack.Pop();
                    stack.Push(LastNo + FirstNo);
                }
                else if (UserInput[i] == '-')
                {
                    FirstNo = stack.Pop();
                    LastNo = stack.Pop();
                    stack.Push(LastNo - FirstNo);
                }
                else if (UserInput[i] == '/')
                {
                    FirstNo = stack.Pop();
                    LastNo = stack.Pop();
                    stack.Push(LastNo / FirstNo);
                }
                else
                {
                    stack.Push(UserInput[i] - '0');
                }
            }
            result = stack.Pop();
            Console.WriteLine("Result = {0}", result);
        }
        static void ReverseString()
        {
            StringBuilder result = new StringBuilder();
            string UserInput;
            Stack<char> stack = new Stack<char>();
            Console.WriteLine("Enter the string to reverse:");
            UserInput = Console.ReadLine();
            for (int i = 0; i < UserInput.Length; i++)
            {
                stack.Push(UserInput[i]);
            }
            result.Clear();
            foreach (char c in stack)
            {
                result.Append(c.ToString());
            }
            Console.WriteLine("Result: {0}",result);
        }
        static void CheckParenthesis()
        {
            string UserInput;
            Stack<char> stack = new Stack<char>();
            Console.WriteLine("Enter the parenthesis:");
            UserInput = Console.ReadLine();
            for(int i = 0; i < UserInput.Length; i++)
            {
                if (stack.Count == 0)
                {
                    stack.Push(UserInput[i]);
                }
                else
                {
                    if (stack.Peek() == UserInput[i])
                    {
                        stack.Push(UserInput[i]);
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
            }
            if (stack.Count > 0)
            {
                Console.WriteLine("Parenthesis are not balanced.");
            }
            else
            {
                Console.WriteLine("Parenthesis are balanced.");
            }
        }
        static void MaximumElement()
        {
            int result;
            string UserInput;
            Stack<int> stack = new Stack<int>();
            Console.WriteLine("Enter the numbers:");
            UserInput = Console.ReadLine();
            for (int i = 0; i < UserInput.Length; i++ )
            {
                stack.Push(UserInput[i] - '0');
            }
            result = stack.Max();
            Console.WriteLine("Maximum value is: {0}", result);
        }
        static void SortStack()
        {
            int PopValue=-1;
            int PushValue=-1;
            Stack<int> FirstStack = new Stack<int>();
            Stack<int> SecondStack = new Stack<int>();
            Console.WriteLine("Enter a sequence of numbers:");
            string UserInput = Console.ReadLine();
            for(int i = 0;i< UserInput.Length;i++ )
            {
                PushValue = UserInput[i]-'0';
                if ( PushValue > PopValue)
                {
                    FirstStack.Push(UserInput[i] - '0');
                }
                

            }
        }
        static void Main(string[] args)
        {
            //PostfixExpression();
            //ReverseString();
            //CheckParenthesis();
            //MaximumElement();
        }
    }
}
