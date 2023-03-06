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

// Inspiration:
// https://stackoverflow.com/questions/14879691/get-number-of-digits-with-javascript/28203456#28203456
// https://stackoverflow.com/questions/13955738/javascript-get-the-second-digit-from-a-number
/**
 * @param {number} x
 * @return {boolean}
 */
var isPalindromeOpt = function(x) {
    if (x < 0) return false;
    var numDigits = Math.max(Math.floor(Math.log10(Math.abs(x))), 0) + 1;
    if (numDigits === 1) return true;
    const map = {};
    var isOdd = numDigits % 2 > 0;
    var halfLength = Math.round(numDigits / 2);
    if (isOdd) {
        for (let i = 1; i < numDigits + 1; i++) {
            var digit = Math.floor((x / Math.pow(10, i - 1)) % 10);
            if (i < halfLength) {
                map[digit] = true;
            } else if (i === halfLength) {
                continue;
            }
            else {
                if (map[digit] === undefined) return false;
            }
        }
    } else {
        for (let i = 1; i < numDigits + 1; i++) {
            var digit = Math.floor((x / Math.pow(10, i - 1)) % 10);
            if (i <= halfLength) {
                map[digit] = true;
            }
            else {
                if (map[digit] === undefined) return false;
            }
        }
    }
    return true;
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
    it('test_03', function(){
        assert.equal(isPalindrome(11), true);
    });
    it('test_04', function(){
        assert.equal(isPalindrome(1001), true);
    });
    it('test_05', function(){
        assert.equal(isPalindrome(123123), false);
    });
    it('test_06', function(){
        assert.equal(isPalindrome(2121), false);
    });
});
describe('IsPalindrome.js opt tests', function(){
    it('test_00', function(){
        assert.equal(isPalindromeOpt(121), true);
    });
    it('test_01', function(){
        assert.equal(isPalindromeOpt(-121), false);
    });
    it('test_02', function(){
        assert.equal(isPalindromeOpt(10), false);
    });
    it('test_03', function(){
        assert.equal(isPalindromeOpt(11), true);
    });
    it('test_04', function(){
        assert.equal(isPalindromeOpt(1001), true);
    });
    it('test_05', function(){
        assert.equal(isPalindromeOpt(123123), false);
    });
    it('test_06', function(){
        assert.equal(isPalindromeOpt(2121), false);
    });
});