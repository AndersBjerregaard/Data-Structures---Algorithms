// Write a function 'howSum(targetSum, numbers)' that takes in a targetSum and an array of numbers as arguments.

// The function should return an array containing any combination of elements that add up to exactly the targetSum.
// If there is no combination that adds up to the targetSum, then return null.

// If there ar emultiple combinations possible, you may return any single one.

// Example: howSum(7, [5, 3, 4, 7]) --> [3, 4] or [7]
// Other example: howSum(8, [2, 3, 5]) --> [2, 2, 2, 2] or [3, 5]
// Other example: howSum(7, [2, 4]) --> null
// Other example: howSum(0, [1, 2, 3]) --> []

const howSum = (targetSum, numbers, memo={}) => {
    if (targetSum in memo) return memo[targetSum];
    if (targetSum === 0) return [];
    if (targetSum < 0) return null;

    for (let num of numbers) {
        const remainder = targetSum - num;
        const remainderResult = howSum(remainder, numbers, memo);
        if (remainderResult !== null) {
            memo[targetSum] = [ ...remainderResult, num ];
            return memo[targetSum];
        }
    }

    memo[targetSum] = null;
    return null;
};

// Tests
console.log(howSum(7, [2, 3])); // [3, 2, 2]
console.log(howSum(7, [5, 3, 4, 7])); // [4, 3]
console.log(howSum(7, [2, 4])); // null
console.log(howSum(8, [2, 3, 5])); // [2, 2, 2, 2]
console.log(howSum(300, [7, 14])); // null