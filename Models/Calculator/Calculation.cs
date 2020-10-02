using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelegramCalcBot.Models.Calculator
{
    public class ReversePolishNotion
    {
        public static int GetPriority(char s)
        {
            switch (s)
            {
                case '(':
                    return 0;
                case ')':
                    return 1;
                case '+':
                case '-':
                    return 2;
                case '*':
                case '/':
                    return 3;
                case '^':
                    return 4;
                default:
                    return -1;
            }
        }
        private static String DoWithEllement(char item, Stack<char> symbol)
        {
            String part = " ";
            if (GetPriority(item) > GetPriority(symbol.Peek()) || GetPriority(item) == 0)
            {
                symbol.Push(item);
                if (GetPriority(symbol.Peek()) == 1)
                {
                    symbol.Pop();
                    symbol.Pop();
                }
            }
            else
            {
                part += symbol.Pop();
                part += DoWithEllement(item, symbol);
            }

            return part;

        }
        public static String Get_RPN(String term)
        {
            List<char> standart_operators = new List<char>(new char[] { '(', ')', '^', '*', '/', '+', '-' });
            Stack<char> symbol = new Stack<char>();
            String finish = "";
            symbol.Push(' ');
            foreach (var item in term)
            {
                if (!standart_operators.Contains(item))
                {
                    finish += item;
                }
                else
                {

                    finish += DoWithEllement(item, symbol);
                }
            }
            int c = symbol.Count;
            for (int i = 0; i < c; i++)
            {
                finish += ' ';
                finish += symbol.Pop();
            }

            return finish;
        }
    }
    public class Calculation
    {
        private static double Operators(double a, double b, char n)
        {
            switch (n)
            {
                case '+':
                    return (a + b);
                case '-':
                    return (b - a);
                case '*':
                    return (a * b);
                case '/':
                    return (b / a);
                case '^':
                    return (Math.Pow(b, a));
            }
            return 0;
        }

        

        public static double Computation(String finish)
        {
            Stack<double> value = new Stack<double>();
            String[] strlist = finish.Split(' ');
            foreach (var item in strlist)
            {
                if (!item.Equals(""))
                {
                    if (item.Length == 1 && ReversePolishNotion.GetPriority(Convert.ToChar(item)) > 0)
                    {
                        value.Push(Operators(value.Pop(), value.Pop(), Convert.ToChar(item)));
                    }
                    else if (item.Length >= 1)
                    {
                        value.Push(Convert.ToInt32(item));
                    }
                }
            }
            return value.Pop();
        }
    }
}