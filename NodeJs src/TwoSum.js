// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
// You may assume that each input would have exactly one solution, and you may not use the same element twice.
// You can return the answer in any order.

// Constraints
// 2 <= nums.length <= 104
// -109 <= nums[i] <= 109
// -109 <= target <= 109
// Only one valid answer exists.

// Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?

/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number[]}
 */
var twoSum = function(nums, target) {
    // Outer loop
    for (let i = 0; i < nums.length - 1; i++) {
        const x = nums[i];
        // Inner loop
        for (let j = 1; j < nums.length; j++) {
            const y = nums[j];
            if (x + y === target) {
                return [i, j];
            }
        }
    }
};

// Tests

var test = require('unit.js');

describe('TwoSum.js tests', function(){
    it('test_00', function(){
        const input = [2,7,11,15];
        const target = 9;
        const expected = [0,1];
        const actual = twoSum(input, target);
        test.assert(actual, expected, `Expected: ${expected}, Actual: ${actual}`);
    });

    it('test_01', function(){
        const input = [3,2,4];
        const target = 6;
        const expected = [1,2];
        const actual = twoSum(input, target);
        test.assert(actual, expected, `Expected: ${expected}, Actual: ${actual}`);
    });

    it('test_02', function(){
        const input = [3,3];
        const target = 6;
        const expected = [0,1];
        const actual = twoSum(input, target);
        test.assert(actual, expected, `Expected: ${expected}, Actual: ${actual}`);
    });
});