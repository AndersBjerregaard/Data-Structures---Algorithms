// Given an integer x, return true if x is a palindrome, and false otherwise.

// Constraints
// -231 <= x <= 231 - 1

// Follow up: Could you solve it without converting the integer to a string?

/**
 * @param {number} x
 * @return {boolean}
 */
var isPalindrome = function(x) {
    return false;
};

// Tests
const { describe, it } = require('node:test');
var test = require('unit.js');
var assert = test.assert;
describe('IsPalindrome.js tests', function(){
    it('test_00', function(){
        assert(isPalindrome(121));
    });
    it('test_01', function(){
        assert(!isPalindrome(-121));
    });
    it('test_02', function(){
        assert(!isPalindrome(10));
    });
});