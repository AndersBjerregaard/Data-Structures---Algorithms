// Given an integer array, find all contiguous subarrays with zero-sum.

// Note: Since an input can have multiple subarrays with zero-sum, the solution should return a set containing all the distinct subarrays.

const getAllZeroSumSubArrays = (numbers, remainder = 0) => {
    
}

// Tests
console.log(getAllZeroSumSubArrays([4, 2, -3, -1, 0, 4])) // {[-3, -1, 0, 4], [0]}
console.log(getAllZeroSumSubArrays([3, 4, -7, 3, 1, 3, 1, -4, -2, -2])) // {[3, 4, -7], [4, -7, 3], [-7, 3, 1, 3], [3, 1, -4], [3, 1, 3, 1, -4, -2, -2], [3, 4, -7, 3, 1, 3, 1, -4, -2, -2]}
console.log(getAllZeroSumSubArrays([0, 0])) // {[0], [0, 0]}
console.log(getAllZeroSumSubArrays([1, 2, 3])) // {}