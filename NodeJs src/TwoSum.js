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
        for (let j = i + 1; j < nums.length; j++) {
            const y = nums[j];
            if (x + y === target) {
                return [i, j];
            }
        }
    }
    return [];
};

/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number[]}
 */
var twoSumMap = function(nums, target) {
    const map = {}
    for (let i = 0; i < nums.length; i++) {
        const x = nums[i];
        const complement = target - x;
        if (map[complement] !== undefined) {
            return [map[complement], i]
        } else {
            map[x] = i;
        }
    }
    return [];
};

// Tests
const { describe, it } = require('node:test');
var test = require('unit.js');
describe('TwoSum.js brute-force tests', function(){
    it('test_00', function(){
        test.array(twoSum([2,7,11,15], 9)).is([0,1]);
    });
    it('test_01', function(){
        test.array(twoSum([3,2,4], 6)).is([1,2]);
    });
    it('test_02', function(){
        test.array(twoSum([3,3], 6)).is([0,1]);
    });
    it('test_03', function(){
        test.array(twoSum([2,5,5,11], 10)).is([1,2]);
    });
});
describe('TwoSum.js optimized function tests', function(){
    it('test_00', function(){
        test.array(twoSumMap([2,7,11,15], 9)).is([0,1]);
    });
    it('test_01', function(){
        test.array(twoSumMap([3,2,4], 6)).is([1,2]);
    });
    it('test_02', function(){
        test.array(twoSumMap([3,3], 6)).is([0,1]);
    });
    it('test_03', function(){
        test.array(twoSumMap([2,5,5,11], 10)).is([1,2]);
    });
});