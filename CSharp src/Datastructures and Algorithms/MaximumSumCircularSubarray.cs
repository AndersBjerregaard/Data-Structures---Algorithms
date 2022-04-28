using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Datastructures_and_Algorithms
{
    /*

    Problem from: https://www.techiedelight.com/maximum-sum-circular-subarray/

    Given a circular integer array, find a contiguous subarray with the largest sum in it.

    Input : [2, 1, -5, 4, -3, 1, -3, 4, -1]
    Output: 6
    Explanation: Subarray with the largest sum is [4, -1, 2, 1] with sum 6.

    Input : [8, -7, -3, 5, 6, -2, 3, -4, 2]
    Output: 18
    Explanation: Subarray with the largest sum is [5, 6, -2, 3, -4, 2, 8] with sum 18.

    */

    public class MaximumSumCircularSubarray
    {
        // My first-hand solution to the problem
        public static int FindLargestSubAarray(int[] nums)
        {
            int largestSum = 0;

            // Iterate through every possibility
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    // Instantiate a temporary array
                    int[] currentArray = new int[j];

                    // Iterate through every possibility for the current index
                    for (int k = 0; k < currentArray.Length; k++)
                    {
                        // Make the array circular
                        int index = i % nums.Length;

                        // Set the temp array's values to the argument parameter array by a certain offset
                        currentArray[k] = nums[(index + k) % nums.Length];
                    }

                    int sum = SumOfArray(currentArray);

                    if (sum > largestSum)
                        largestSum = sum;
                }
            }

            return largestSum;
        }

        static int SumOfArray(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            return sum;
        }

        // The internet (and the best) solution to the problem, using Kadane's algorithm and lessening the time complexity

        // Simple implementation of Kadane's algorithm
        /// <summary>
        /// Algorithm to find the maximum sum of a contiguous subarray in a given integer array
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int Kadane(int[] nums)
        {
            // Stores the maximum sum subarray found so far
            int maxSoFar = 0;

            // Stores the maximum sum of subarray ending at the current position
            int maxEndingHere = 0;

            // Traverse the given array
            for (int i = 0; i < nums.Length; i++)
            {
                // Update the maximum sum of subarray ending at index 'i', by adding the current element to maximum sum ending at previous index 'i - 1'
                maxEndingHere += nums[i];

                // If the maximum sum is negative, set it to 0 (which represents an empty subarray)
                maxEndingHere = maxEndingHere > 0 ? maxEndingHere : 0;

                // Update the result if the current subarray sum is found to be greater
                maxSoFar = maxSoFar > maxEndingHere ? maxSoFar : maxEndingHere;
            }

            return maxSoFar;
        }

        /*
            The problem differs from the problem of finding the maximum sum circular subsequence. Unlike subsequences, subarrays are required to occupy consecutive positions within the original array.

            The idea is to find the sequence which will have a maximum negative value. If we remove that minimum sum sequence from the input sequence, we will be left with the maximum sum circular sequence. Finally, return the maximum of the maximum-sum circular sequence (includes corner elements) and maximum-sum non-circular sequence.

            For example, consider array {2, 1, -5, 4, -3, 1, -3, 4, -1}. The sequence having maximum negative value is {-5, 4, -3, 1, -3}, i.e., -6. If we remove this minimum sum sequence from the array, we will get the maximum sum circular sequence, i.e., {2, 1, 4, -1} having sum 6. Since the maximum sum circular sequence is greater than the maximum sum non-circular sequence, i.e., {4} for the given array, it is the answer.

 
            We can find the maximum-sum non-circular sequence in linear time by using Kadane’s algorithm. We can find a maximum-sum circular sequence by inverting the sign of all array elements and then applying Kadane’s algorithm.

            For example, if we invert signs of array {2, 1, -5, 4, -3, 1, -3, 4, -1}, we get {-2, -1, 5, -4, 3, -1, 3, -4, 1} which has maximum sum sequence {5, -4, 3, -1, 3} having sum 6. Now inverting the signs back, we get a minimum sum sequence {-5, 4, -3, 1, -3} having sum -6.
        */

        public static int CircularKadane(int[] nums)
        {
            // Empty array has a sum of 0
            if (nums.Length == 0)
                return 0;

            // Find the maximum element present in a given array
            int maxNum = nums.Max();

            // If the array contains all negative values, return the maximum element
            if (maxNum < 0)
                return maxNum;

            // Negate all the array elements
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = -nums[i];
            }

            // Run kadane's algorithm on the modified array
            int negMaxSum = Kadane(nums);

            // Restore the array
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = -nums[i];
            }

            // Return the maximum of the following:
            // 1. Sum return by Kadane's algorithm on the original array.
            // 2. Sum return by Kadane's algorithm on the modified array + the sum of all the array elements.

            int kadaneSum = Kadane(nums);

            int otherSum = SumOfArray(nums) + negMaxSum;

            return kadaneSum > otherSum ? kadaneSum : otherSum;
        }
    }
}
