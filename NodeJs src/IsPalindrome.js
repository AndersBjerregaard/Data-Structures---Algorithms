// Given an integer x, return true if x is a palindrome, and false otherwise.

// Constraints
// -231 <= x <= 231 - 1

// Follow up: Could you solve it without converting the integer to a string?

/**
 * @param {number} x
 * @return {boolean}
 */
var isPalindrome = function(x) {
    xArray = String(x)
        .split('')
        .map(Number);
    yArray = String(x)
        .split('')
        .map(Number);
    yArray.reverse();
    return xArray.toString() == yArray.toString();
};

// Tests
const { describe, it } = require('node:test');
var test = require('unit.js');
var assert = test.assert;
describe('IsPalindrome.js tests', function(){
    it('test_00', function(){
        assert.equal(isPalindrome(121), true);
    });
    it('test_01', function(){
        assert.equal(isPalindrome(-121), false);
    });
    it('test_02', function(){
        assert.equal(isPalindrome(10), false);
    });
});