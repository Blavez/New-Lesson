using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Work
{
    class Class1
    {
        public static void Count()
        {
            List<int> a = new List<int> { 1, 2, 4, 3, 5, 4, 4, 2, 6 };
            foreach (int val in a.Distinct())
            {
                Console.WriteLine(val + " - " + a.Where(x => x == val).Count() + " раз");
            }
        }
}
}
