using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure
{
    public class Calculator
    {
        public static decimal Evaluate(string[] infixTokens)
        {
            var postfixTokens = ConvertToPostfix(infixTokens);

            string[] operators = {"+", "-", "*", "/"};
            var stk = new Stack<string>();

            foreach(var tok in postfixTokens)
            {
                if (operators.Contains(tok))
                {
                    var n2 = decimal.Parse(stk.Pop());
                    var n1 = decimal.Parse(stk.Pop());
                    var res = Calc(tok, n1, n2);
                    stk.Push(res.ToString());
                }
                else
                {
                    stk.Push(tok);
                }

                System.Console.WriteLine(string.Join(" ", stk));
            }

            string result = stk.Pop();
            return decimal.Parse(result);
        }

        private static string[] ConvertToPostfix(string[] infix)
        {
            var postfix = new List<string>();
            var stk = new Stack<string>();

            foreach(var tok in infix)
            {
                if (tok == "(")
                {
                    stk.Push(tok);
                }
                else if(tok == ")")
                {
                    while(stk.Count > 0)
                    {
                        var t = stk.Pop();
                        if (t == "(") break;

                        postfix.Add(t);
                    }
                }
                else if(tok == "+" || tok == "-")
                {
                    while(stk.Count > 0 && stk.Peek() != "(")
                    {
                        postfix.Add(stk.Pop());
                    }

                    stk.Push(tok);
                }
                else if(tok == "*" || tok == "/")
                {
                    while(stk.Count > 0 && (stk.Peek() == "*" || stk.Peek() == "/"))
                    {
                        postfix.Add(stk.Pop());
                    }

                    stk.Push(tok);
                }
                else
                {
                    postfix.Add(tok);
                }
            }

            while(stk.Count > 0)
            {
                postfix.Add(stk.Pop());
            }

            System.Console.WriteLine(string.Join(", ", postfix));

            return postfix.ToArray();
        }

        private static decimal Calc(string op, decimal n1, decimal n2)
        {
            decimal result = 0;

            switch(op)
            {
                case "+": result = n1 + n2; break;
                case "-": result = n1 - n2; break;
                case "*": result = n1 * n2; break;
                case "/": result = n1 / n2; break;
                default: throw new InvalidOperationException();
            }

            return result;
        }

        public static void Test()
        {
            var str = "2 * ( 3 + 4 ) - 12";
            var strArr = str.Split(" ");
            System.Console.WriteLine(string.Join(",", strArr));
            System.Console.WriteLine(Evaluate(strArr));
        }
    }
}