using System.Collections.Generic;
using System.Linq;

namespace Datastructures_and_Algorithms
{
    /*
     * Problem acquired from: https://www.techiedelight.com/find-index-0-replaced-get-maximum-length-sequence-of-continuous-ones/
     * 
     * Given a binary array, find the index of 0 to be replaced with 1 to get the maximum length sequence of continuous ones. The solution should return the index of first occurence of 0, when multiple continuous sequence of maximum length is possible.

       Input : [0, 0, 1, 0, 1, 1, 1, 0, 1, 1]
       Output: 7
       Explanation: Replace index 7 to get the continuous sequence of length 6 containing all 1’s.

       Input : [0, 1, 1, 0, 0]
       Output: 0
       Explanation: Replace index 0 or 3 to get the continuous sequence of length 3 containing all 1’s. The solution should return the first occurence.

       Input : [1, 1]
       Output: -1
       Explanation: Invalid Input (all 1’s)
    */
    public class MaximumLengthSequenceOfContinuousOnes
    {
        internal class Interval
        {
            internal int? IndexOfZero { get; set; }
            internal int IntervalOfOnes { get; set; }
        }

        /// <summary>
        /// Output should default to -1 if all of the input values in the array is 1, or an error has occoured.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindIndexOfZero(int[] nums)
        {
            Interval currentInterval = null;

            List<Interval> Intervals = new List<Interval>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    if (currentInterval is null)
                    {
                        currentInterval = new Interval { IndexOfZero = i, IntervalOfOnes = 1 };
                    } else
                    {
                        if (currentInterval.IndexOfZero == i - 1)
                        {
                            Intervals.Add(currentInterval); // Since we're instantiating a new 'currentInterval', save the preceding one..
                            currentInterval = new Interval { IndexOfZero = i, IntervalOfOnes = 1 };
                        }
                    }                    
                } else // If the number isn't 0, then it must be 1
                {
                    currentInterval.IntervalOfOnes++;
                }
            }

            return Intervals.OrderByDescending(x => x.IntervalOfOnes).First().IndexOfZero.Value;
        }
    }
}
