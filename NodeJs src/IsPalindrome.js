// Given an integer x, return true if x is a palindrome, and false otherwise.

// Constraints
// -231 <= x <= 231 - 1

// Follow up: Could you solve it without converting the integer to a string?

/**
 * @param {number} x
 * @return {boolean}
 */
var isPalindrome = function(x) {
    
};

// Tests
const { describe, it } = require('node:test');

var test = require('unit.js');
var assert = test.assert;

describe('IsPalindrome.js tests', function(){
    it('test_00', function(){
        const input = 121;
        const expected = true;
        const actual = isPalindrome(input);
        assert(actual, expected, `Expected: ${expected}, Actual: ${actual}`);
    });
    it('test_01', function(){
        const input = -121;
        const expected = false;
        const actual = isPalindrome(input);
        assert(actual, expected, `Expected: ${expected}, Actual: ${actual}`);
    });
    it('test_02', function(){
        const input = 10;
        const expected = false;
        const actual = isPalindrome(input);
        assert(actual, expected, `Expected: ${expected}, Actual: ${actual}`);
    });
});