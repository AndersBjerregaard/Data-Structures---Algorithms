// Given an integer numbers, find the maximum length contiguous subarray having a given sum.

// Note: Since an input can contain several maximum length subarrays with given sum, 
// the solution should return any one of the maximum length subarray.

const maxLenSubarray = (numbers, target, index = 0) => {
    
    let largestSubArray = [];

    let currentValue = 0;
    let subArray = [];
    for (let i = 0; i + index < numbers.length; i++) {
        const element = numbers[i + index];
        subArray = [ ...subArray, element ]
        currentValue += element;
        if (currentValue == target) {
            // Check to see if this subarray is larger than the current memoized one
            if (largestSubArray.length < subArray.length) {
                largestSubArray = subArray;
            }
        }
    }

    if (index < numbers.length) {
        if (largestSubArray.length < subArray.length)
            largestSubArray = maxLenSubarray(numbers, target, index + 1)
    }

    return largestSubArray;
}

// Tests
// console.log(maxLenSubarray([5, 6, -5, 5, 3, 5, 3, -2, 0], 8)) // [-5, 5, 3, 5]
// Explanation: The subarrays with sum 8 are [[-5, 5, 3, 5], [3, 5], [5, 3]]. The longest subarray is [-5, 5, 3, 5] having length 4.
console.log(maxLenSubarray([5, 3, -3, 3, -3, 3], 8))