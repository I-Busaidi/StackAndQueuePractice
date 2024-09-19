using System.Collections;
using System.Text;

namespace StackAndQueue
{
    internal class Program
    {
        static void PostfixExpression() // Calculate a postfix expression using a stack
        {
            int FirstNo;
            int LastNo;
            int IntCheck;
            float result;
            string UserInput;
            Stack<int> stack = new Stack<int>();
            Console.WriteLine("Enter the postfix expression to calculate:");
            UserInput = Console.ReadLine();
            for (int i = 0; i < UserInput.Length; i++)
            {
                //if the char is an operator, pop two numbers to be used as operands, then push the result into stack.
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
                // if the char is a number, push into the stack.
                else if (int.TryParse(UserInput[i].ToString(), out IntCheck))
                {
                    stack.Push(UserInput[i] - '0');
                }
            }
            // pop the result after completing all the operations to be printed.
            result = stack.Pop();
            Console.WriteLine("Result = {0}", result);
        }
        static void ReverseString() // Reverse an input string using a stack.
        {
            StringBuilder result = new StringBuilder();
            string UserInput;
            Stack<char> stack = new Stack<char>();
            Console.WriteLine("Enter the string to reverse:");
            UserInput = Console.ReadLine();
            // push the input string in the stack as characters.
            for (int i = 0; i < UserInput.Length; i++)
            {
                stack.Push(UserInput[i]);
            }
            result.Clear();
            // pop the charcters out and append to a stringbuilder, Last-in, First-out nature of the stack will reverse the printed string.
            foreach (char c in stack)
            {
                result.Append(c.ToString());
            }
            Console.WriteLine("Result: {0}",result);
        }
        static void CheckParenthesis() // Check if parenthesis are balanced.
        {
            string UserInput;
            Stack<char> stack = new Stack<char>();
            Console.WriteLine("Enter the parenthesis:");
            UserInput = Console.ReadLine();
            for(int i = 0; i < UserInput.Length; i++)
            {
                if ((UserInput[i] != ')') || (UserInput[i] != '('))
                {
                    Console.WriteLine("Invalid input, must only contain parentheses \"(\" , \")\"");
                    return;
                }
                //if the stack is empty, push without peeking.
                else if (stack.Count == 0)
                {
                    stack.Push(UserInput[i]);
                }
                else
                {
                    //if the top element in the stack matches the input char, push into the stack.
                    if (stack.Peek() == UserInput[i])
                    {
                        stack.Push(UserInput[i]);
                    }
                    //if the top element does not match, pop the top element.
                    else
                    {
                        stack.Pop();
                    }
                }
            }
            //if the stack has elements left, it means not all parenthesis got resolved.
            if (stack.Count > 0)
            {
                Console.WriteLine("Parenthesis are not balanced.");
            }
            else
            {
                Console.WriteLine("Parenthesis are balanced.");
            }
        }
        static void MaximumElement() // Print the maximum element in a stack.
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
            result = stack.Max(); // gets the maximum value in a stack.
            Console.WriteLine("Maximum value is: {0}", result);
        }
        static void SortStack() // Sorting a stack elements with only 1 additional stack. No other datastructures allowed (except for printing).
        {
            int UserInput;
            int NoOfPops;
            bool FoundGreater = true;
            StringBuilder sb = new StringBuilder();
            Stack<int> MainStack = new Stack<int>(); // the main stack that will have the sorted values.
            Stack<int> SecondaryStack = new Stack<int>(); // the secondary stack will be used to store values popped from the main stack temporarely.
            Console.WriteLine("\nEnter the numbers one by one:");
            while(int.TryParse(Console.ReadLine(),out UserInput))
            {
                Console.WriteLine("\nEnter the next number, or \"s\" to show sorted stack:");
                sb.Append(UserInput).Append(" ");
                NoOfPops = 0; // will be used to calculate how many pops were made to fit the next integer into the sorted stack (main stack).
                if (MainStack.Count == 0)
                {
                    MainStack.Push(UserInput);
                }
                else
                {
                    foreach (int i in MainStack)
                    {
                        // if the input int is smaller than some or all the elements in the stack, count how many pops are needed.
                        if (UserInput > i)
                        {
                            NoOfPops++;
                            FoundGreater = false;
                        }
                    }
                    // if no smaller elements found in the stack, push the input.
                    if (FoundGreater)
                    {
                        MainStack.Push(UserInput);
                    }
                    // if smaller elements were found, pop until reaching the number of pops needed that were counted above.
                    else
                    {
                        // storing popped elements from the main stack into the secondary (temporary) stack.
                        for (int i = 0; i < NoOfPops; i++)
                        {
                            SecondaryStack.Push(MainStack.Pop());
                        }
                        // push the new element into the main stack.
                        MainStack.Push(UserInput);
                        // push back the elements from the secondary stack into the main stack.
                        for (int i = 0;i < NoOfPops;i++)
                        {
                            MainStack.Push(SecondaryStack.Pop());
                        }
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("Entered numbers: "+sb.ToString());
            sb.Clear();
            // printing the result.
            foreach(int num in MainStack)
            {
                sb.Append(num).Append(" ");
            }
            Console.WriteLine("Sorted numbers: "+sb.ToString());
        }
        static void QueueReverse() // Reversing a queue using a queue and a stack.
        {
            int UserInput;
            StringBuilder sb = new StringBuilder();
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();
            Console.WriteLine("Enter the numbers, or type \"exit\" to exit");
            // pushing the user input into the queue.
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
            // dequeue from queue and push into stack.
            while(queue.Count > 0)
            {
                stack.Push(queue.Dequeue());
            }
            // pop from stack back into the queue, resulting in a reversed string.
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
        static void QueuePalindromeCheck() // Checking for palindrome using stack and queue.
        {
            string UserInput;
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();
            Console.WriteLine("Enter the string to check for palindrome:");
            UserInput = Console.ReadLine();
            // insert input into the queue and stack.
            for (int i = 0; i < UserInput.Length; i++)
            {
                queue.Enqueue(UserInput[i]);
                stack.Push(UserInput[i]);
            }
            // pop from stack and dequeue from queue, and check if the elements match, if not then print not a palindrome.
            for (int i = 0;i < UserInput.Length; i++)
            {
                if (queue.Dequeue() != stack.Pop())
                {
                    Console.WriteLine("Input is not a palindrome.");
                    return;
                }
            }
            // if the loop is not interrupted then the input is a palindrome.
            Console.WriteLine("Input is a palindrome.");
        }
        static void QueueSlidingWindow() // Using queue to create a sliding window that checks the greatest numbers in the window and print them.
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
            // initially put the number of element determined by user into the sliding window. Then store the max value.
            for (int i = 0; i < K; i++)
            {
                window.Enqueue(queue.Dequeue());
            }
            results.Add(window.Max());
            //while queue has elements, dequeue the first element and enqueue the element from the main queue into the end of window, and store max value.
            while (queue.Count > 0) //repeated until the main queue elements are emptied.
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
                "\n5. Sort a stack" +
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
                        SortStack();
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
