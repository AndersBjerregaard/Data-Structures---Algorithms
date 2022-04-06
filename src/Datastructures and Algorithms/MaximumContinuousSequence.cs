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
    public class MaximumContinuousSequence
    {
        internal class Interval
        {
            internal int? IndexOfZero { get; set; }
            internal int IntervalOfOnes { get; set; }
        }

        /// <summary>
        /// Output should default to -1 if all of the input values in the array is 1, or an error has occoured.
        /// It is very important for the purpose of run-time, to have at most a time complexity of O(n).
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindIndexOfZero(int[] nums)
        {
            Interval currentInterval = new Interval { IndexOfZero = null, IntervalOfOnes = 0 };

            List<Interval> Intervals = new List<Interval>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    if (currentInterval.IndexOfZero is null) // Meaning the current interval has not hit a '0' yet
                    {
                        currentInterval.IndexOfZero = i;
                        currentInterval.IntervalOfOnes++;
                    } else // We've hit a new 0, so save the last one and instantiate a new interval. And add any exisisting interval of 1's to the new one.
                    {
                        Intervals.Add(currentInterval);
                        int existingIntervalOfOnes = currentInterval.IntervalOfOnes - 1;
                        currentInterval = new Interval { IndexOfZero = i, IntervalOfOnes = existingIntervalOfOnes };
                    }
                } else // If the number isn't 0, then it must be 1
                {
                    currentInterval.IntervalOfOnes++;
                }
                // If we're at the end of the array, save the current interval
                if (i == nums.Length - 1)
                    Intervals.Add(currentInterval);
            }

            // If no 0 was in the argument array, then return '-1' as response to an invalid input
            if (Intervals[0].IndexOfZero is null)
            {
                return -1;
            }

            return Intervals.OrderByDescending(x => x.IntervalOfOnes).First().IndexOfZero.Value;
        }

        /// <summary>
        /// We can efficiently solve this problem in linear time and constant space. The idea is to traverse the given array and maintain an index of the previous zero encountered. We can then easily find out the total number of 1’s between the current zero and the last zero for each subsequent zeroes. For each element, check if the maximum sequence of continuous 1’s ending at that element (including the last zero, which is now replaced by 1) exceeds the maximum sequence found so far. If yes, update the maximum sequence to the current sequence length and index of optimal zero and index the last zero encountered.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindIndexOfZeroOtherImplementation(int[] nums)
        {
            int max_count = 0; // Stores the maximum number of 1's (including 0)
            int max_index = -1; //Stores the index of 0 to be replaced

            int prev_zero_index = -1; // Stores the index of previous zero
            int count = 0; // Stores the current count of zeroes

            // Consider each index 'i' in the array
            for (int i = 0; i < nums.Length; i++)
            {
                // If the current element is 1
                if (nums[i] == 1)
                    count++;
                // If the current element is 0
                else
                {
                    // Reset count to 1 + number of ones to the left of current 0
                    count = i - prev_zero_index;

                    // Update 'prev_zero_index' to the current index
                    prev_zero_index = i;
                }

                // Update maximum count and index of 0 to be replaced if required
                if (count > max_count)
                {
                    max_count = count;
                    max_index = prev_zero_index;
                }
            }

            // Return index of 0 to be replaced or -1 if the array contains all 1's
            return max_index;
        }
    }
}
