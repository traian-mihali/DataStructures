using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataStructures.Helpers
{
    public class StringHelper
    {
        private static readonly IList<char> leftBrackets = new List<char> { '(', '[', '{', '<' };
        private static readonly IList<char> rightBrackets = new List<char> { ')', ']', '}', '>' };


        public static char FirstNonRepeatingChar(string text)
        {
            Dictionary<char, int> characters = new Dictionary<char, int>();
            string source = text.ToLower();

            foreach (char c in source)
            {
                int count = characters.ContainsKey(c) ? characters[c] : 0;
                characters[c] = count + 1;
            }

            foreach (char c in source)
            {
                if (characters[c] == 1)
                    return c;
            }

            return Char.MinValue;
        }

        public static string Reversed(string str)
        {
            if (str == null)
                throw new ArgumentNullException();

            var stack = new Stack<char>();
            foreach (var c in str)
                stack.Push(c);

            var sb = new StringBuilder();
            while (stack.Count > 0)
                sb.Append(stack.Pop());

            return sb.ToString();
        }

        public static bool IsBalanced(string str)
        {

            var stack = new Stack<char>();

            foreach (var c in str)
            {
                if (IsLeftBracket(c))
                    stack.Push(c);


                if (IsRightBracket(c))
                {
                    if (stack.Count == 0) return false;

                    var top = stack.Pop();

                    if (!BracktesMatch(top, c))
                        return false;
                }
            }


            return stack.Count == 0;
        }

        private static bool IsLeftBracket(char c)
        {
            return leftBrackets.Contains(c);
        }

        private static bool IsRightBracket(char c)
        {
            return rightBrackets.Contains(c); ;
        }

        private static bool BracktesMatch(char left, char right)
        {
            return leftBrackets.IndexOf(left) == rightBrackets.IndexOf(right);
        }
    }
}
