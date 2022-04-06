using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructures_and_Algorithms
{
    /*

    Given a circular integer array, find a continuous subarray with the largest sum in it.

    Input : [2, 1, -5, 4, -3, 1, -3, 4, -1]
    Output: 6
    Explanation: Subarray with the largest sum is [4, -1, 2, 1] with sum 6.

    Input : [8, -7, -3, 5, 6, -2, 3, -4, 2]
    Output: 18
    Explanation: Subarray with the largest sum is [5, 6, -2, 3, -4, 2, 8] with sum 18.

    */

    public class MaximumSumCircularSubarray
    {
        public static int[] FindLargestSubAarray(int[] nums)
        {
            
        }

        int SumOfArray(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            return sum;
        }
    }
}
