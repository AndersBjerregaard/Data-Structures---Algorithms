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

// First solution. This could only calculate a subarray starting from index 0.
// const zeroSum = (numbers, remainder = null) => {
//     if (remainder !== null) {
//         if (remainder === 0) return true;
//     };
    
//     for (let num of numbers) {
//         if (remainder !== null) {
//             if (remainder + num === 0) return true;
//             remainder += num;
//         } else {
//             remainder = num;
//         }
//     }

//     return false;
// }

// Second solution
const zeroSum = (numbers) => {
    for (let i = 0; i < numbers.length; i++) {
        let remainder = 0;
        for (let k = 0; (i + k) < numbers.length; k++) {
            const element = numbers[i + k];
            if (remainder + element === 0) return true;
            remainder += element;
        }
    }

    return false;
}

// Tests
console.log(zeroSum([3, 4, -7, 3, 1, 3, 1, -4, -2, -2])) // true
console.log(zeroSum([4, -7, 1, 4, -1])) // false
console.log(zeroSum([6, -7, 3, 4])) // true