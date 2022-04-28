using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructures_and_Algorithms
{
    public class Fibonacci
    {
        /// <summary>
        /// This is a function that aims to return the number of a given position (n), from the fibonacci sequence.
        /// Additionally, this function aims to 
        /// </summary>
        /// <param name="n">The index of the number from the fibonacci sequence.</param>
        /// <returns>A number from the fibonacci sequence.</returns>
        public static int Fib(int n)
        {
            if (n <= 2) return 1;

            return Fib(n - 1) + Fib(n - 2);
        }
    }
}
