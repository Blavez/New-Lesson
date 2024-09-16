using System;

namespace Work
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Привет мир";
            int i = s.CharCount();
            Console.WriteLine(i);
            Class1.Count();
            Console.Read();
        }
    }

    public static class StringExtension
    {
        public static int CharCount(this string str)
        {
            int counter = 0;
            counter = str.Length;
            return counter;
        }
    }
}
