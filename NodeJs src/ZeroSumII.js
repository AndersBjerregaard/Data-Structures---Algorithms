// Given an integer array, find all contiguous subarrays with zero-sum.

// Note: Since an input can have multiple subarrays with zero-sum, the solution should return a set containing all the distinct subarrays.

const zeroSumII = (numbers) => {
    const setResult = new Set();
    for (let i = 0; i < numbers.length; i++) {
        let remainder = 0;
        let subArray = [];
        for (let k = 0; (i + k) < numbers.length; k++) {
            const element = numbers[i + k];
            subArray = [ ...subArray, element ]
            if (remainder + element === 0) {
                setResult.add(subArray);
            }
            remainder += element;
        }
    }

    return setResult;
}

// Tests
console.log(zeroSumII([4, 2, -3, -1, 0, 4])) // {[-3, -1, 0, 4], [0]}
console.log(zeroSumII([3, 4, -7, 3, 1, 3, 1, -4, -2, -2])) // {[3, 4, -7], [4, -7, 3], [-7, 3, 1, 3], [3, 1, -4], [3, 1, 3, 1, -4, -2, -2], [3, 4, -7, 3, 1, 3, 1, -4, -2, -2]}
console.log(zeroSumII([0, 0])) // {[0], [0, 0]}
console.log(zeroSumII([1, 2, 3])) // {}