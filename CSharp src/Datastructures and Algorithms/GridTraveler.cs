using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Datastructures_and_Algorithms
{
    /*
    Say that you are a traveler on a 2D grid. You begin in the top-left corner and your goal is to 
    travel to the bottom-right corner. You may only move down or right (therefore diagonally is also excluded).

    In how many unique ways can you travel to the goal on a grid with dimensions m * n?

    Write a function GridTraveler(m, n) that calculates this.
    */
    public class GridTraveler
    {
        /// <summary>
        /// Calculates the amount of ways you can travel through a grid with the dimensions m * n (argument parameters).
        /// Constraints assumed in this method are the following:
        /// You can only move down or right.
        /// The argument parameters have a value of 0 or above.
        /// </summary>
        /// <param name="m">Number of rows in the grid</param>
        /// <param name="n">Number of columns in the grid</param>
        /// <returns>The amount of ways you can travel in a grid with the dimensions of the argument parameters.</returns>
        public static int Travel(int m, int n)
        {
            // There is only one way to get from start to finish in a 1 by 1 grid. Which is to say, nothing.
            if (m == 1 && n == 1)
            {
                Debug.WriteLine(1);
                return 1;
            }
            // Having either 0 rows or columns, there essentially isn't a grid to traverse.
            if (m == 0 || n == 1) return 0;

            // Recurse through the method, branching both 'down' and 'right', if none of the above base cases were met.
            return Travel(m - 1, n) + Travel(m, n - 1);
        }
    }
}