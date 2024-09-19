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
                    if (FirstNo <= LastNo)
                    {
                        stack.Push(LastNo - FirstNo);
                    }
                    else
                    {
                        stack.Push(FirstNo - LastNo);
                    }
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
            int UserInput;
            Stack<int> stack = new Stack<int>();
            Console.WriteLine("Enter the numbers, or type \"s\" to start operation.");
            while (int.TryParse(Console.ReadLine(), out UserInput))
            {
                stack.Push(UserInput);
                Console.WriteLine("\nEnter the next number, or type \"s\" to start operation.");
            }
            result = stack.Max();
            Console.WriteLine("Maximum value is: {0}", result);
        }
        static void SortStack()
        {
            int UserInput;
            Stack<int> MainStack = new Stack<int>();
            Stack<int> SecondaryStack = new Stack<int>();
            Console.WriteLine("\nEnter the numbers:");
            while(int.TryParse(Console.ReadLine(),out UserInput))
            {
                MainStack.Push(UserInput);
                Console.WriteLine("Enter the next number, or \"s\" to start sorting.");
            }
        }
        static void QueueReverse()
        {
            int UserInput;
            StringBuilder sb = new StringBuilder();
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();
            Console.WriteLine("Enter the numbers, or type \"exit\" to exit");
            while (int.TryParse(Console.ReadLine(), out UserInput))
            {
                queue.Enqueue(UserInput);
                Console.WriteLine("\nEnter the next number:");
            }
            Console.Clear();
            Console.WriteLine("Queue content before reversing:");
            foreach(int value in queue)
            {
                sb.Append(value).Append(" ");
            }
            Console.WriteLine(sb.ToString());
            while(queue.Count > 0)
            {
                stack.Push(queue.Dequeue());
            }
            while(stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }
            sb.Clear();
            Console.WriteLine("Queue content after reversing:");
            foreach (int value in queue)
            {
                sb.Append(value).Append(" ");
            }
            Console.WriteLine(sb.ToString());
        }
        static void QueuePalindromeCheck()
        {
            string UserInput;
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();
            Console.WriteLine("Enter the string to check for palindrome:");
            UserInput = Console.ReadLine();
            for (int i = 0; i < UserInput.Length; i++)
            {
                queue.Enqueue(UserInput[i]);
                stack.Push(UserInput[i]);
            }
            for (int i = 0;i < UserInput.Length; i++)
            {
                if (queue.Dequeue() != stack.Pop())
                {
                    Console.WriteLine("Input is not a palindrome.");
                    return;
                }
            }
            Console.WriteLine("Input is a palindrome.");
        }
        static void QueueSlidingWindow()
        {
            int UserInput;
            int K;
            StringBuilder sb = new StringBuilder();
            Queue<int> queue = new Queue<int>();
            Queue<int> window = new Queue<int>();
            List<int> results = new List<int>();
            Console.WriteLine("Enter the numbers:");
            while (int.TryParse(Console.ReadLine(), out UserInput) || (queue.Count < 2))
            {
                queue.Enqueue(UserInput);
                if(queue.Count < 2)
                {
                    Console.WriteLine("\nEnter the next number:\n");
                }
                else
                {
                    Console.WriteLine("\nEnter the next number, or type \"s\" to start operation.\n");
                }
            }
            Console.Clear();
            Console.WriteLine($"Enter the size of the sliding window. (between 2 to {queue.Count})");
            while(!int.TryParse(Console.ReadLine(), out K) || (K > queue.Count) || (K < 2))
            {
                if (K > queue.Count)
                {
                    Console.WriteLine("\nSize of sliding window must be >= queue size.\n");
                }
                else if (K < 1)
                {
                    Console.WriteLine("\nSize of sliding window must be 2 or more.");
                }
            }
            foreach (int i in queue)
            {
                sb.Append(i).Append(", ");
            }
            Console.Clear ();
            Console.WriteLine("Queue elements: "+sb.ToString());
            for (int i = 0; i < K; i++)
            {
                window.Enqueue(queue.Dequeue());
            }
            results.Add(window.Max());
            while (queue.Count > 0)
            {
                window.Dequeue();
                window.Enqueue (queue.Dequeue());
                results.Add(window.Max());
            }
            sb.Clear();
            for (int i = 0; i < results.Count ;i++)
            {
                sb.Append(results[i]).Append(", ");
            }
            Console.WriteLine("Result: "+sb.ToString());
        }
        static void MainMenu()
        {
            bool ExitMenu = false;
            int UserChoice;
            string Menu = ("Choose an operation:" +
                "\n1. Calculate postfix expression." +
                "\n2. Reverse a string." +
                "\n3. Check parenthesis balance." +
                "\n4. Find maximum element." +
                "\n5. Sort a stack. (Under Maintenance)" +
                "\n6. Reverse a queue." +
                "\n7. Check if queue is a palindrome." +
                "\n8. Maximum element in a sliding window." +
                "\n\n0. Exit.\n\n");
            do
            {
                Console.Clear();
                Console.WriteLine(Menu);
                while (!int.TryParse(Console.ReadLine(), out UserChoice) || (UserChoice > 8) || (UserChoice < 0))
                {
                    Console.Clear();
                    Console.WriteLine(Menu);
                    Console.WriteLine("\nInvalid input, please try again:\n");
                }
                Console.Clear();
                switch (UserChoice)
                {
                    case 0:
                        ExitMenu = true;
                        break;

                    case 1:
                        PostfixExpression();
                        break;
                        
                    case 2:
                        ReverseString();
                        break;

                    case 3:
                        CheckParenthesis();
                        break;

                    case 4:
                        MaximumElement();
                        break;

                    case 5:
                        Console.WriteLine("Function is Under Maintenance, Please Try Again Later.");
                        //SortStack();
                        break;

                    case 6:
                        QueueReverse();
                        break;

                    case 7:
                        QueuePalindromeCheck();
                        break;

                    case 8:
                        QueueSlidingWindow();
                        break;
                }
                Console.WriteLine("\nPress any key...");
                Console.ReadKey();
            } while (!ExitMenu);
        }
        static void Main(string[] args)
        {
            MainMenu();
        }
    }
}
