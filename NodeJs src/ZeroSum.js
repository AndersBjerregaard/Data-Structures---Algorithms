// Given an integer array, check if it contains a contiguous subarray having zero-sum.

// Input : [3, 4, -7, 3, 1, 3, 1, -4, -2, -2]
// Output : true
// Explanation: The subarrays with zero-sum are
// [3, 4, -7]
// [4, -7, 3]
// [-7, 3, 1, 3]
// [3, 1, -4]
// [3, 1, 3, 1, -4, -2, -2]
// [3, 4, -7, 3, 1, 3, 1, -4, -2, -2]

// Input : [4, -7, 1, 4, -1]
// Output: false
// Explanation: The subarray with zero-sum doesn't exist.

const zeroSum = (numbers, remainder = null) => {
    if (remainder !== null) {
        if (remainder === 0) return true;
    };
    
    for (let num of numbers) {
        if (remainder !== null) {
            if (remainder + num === 0) return true;
            remainder += num;
        } else {
            remainder = num;
        }
    }

    return false;
}

// Tests
console.log(zeroSum([3, 4, -7, 3, 1, 3, 1, -4, -2, -2])) // true
console.log(zeroSum([4, -7, 1, 4, -1])) // false