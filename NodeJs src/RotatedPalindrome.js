// Given a string, check if it is a rotated palindrome or not.

// Input: "CBAABCD"
// Output: true
// Explanation: "CBAABCD" is a rotation of the palindrome "ABCDCBA"

// Input: "BAABCC"
// Output: true
// Explanation: "BAABCC" is a rotation of the palindrome "ABCCBA"

// Input: "DCABC"
// Output: false

const isRotatedPalindrome = (input) => {
    
    // Create a dictionary to store the characters of the input string
    // Along with their corresponding amount of occourences within said string
    var dict = {};
    
    // Iterate through every character in the input string and save it to the dictionary
    // Along with how many times said character has occoured
    for (let i = 0; i < input.length; i++) {
        const element = input[i];
        if (element in dict) {
            dict[element]++;
        } else {
            dict[element] = 1;
        }
    }

    let returnValue = true;

    // There's a case for an even amount of characters versus an uneven amount of characters
    if (input.length % 2 === 0) {
        // Combining two functions to iterate through 
        // the values of their corresponding key in the dictionary
        Object.keys(dict).forEach(key => {
            if (dict[key] % 2 !== 0) {
                returnValue = false;
            }
        });
    } else {
        // Variable to store how many times an uneven amount of characters has occoured
        let unevenOccourence = 0;

        Object.keys(dict).forEach(key => {
            if (dict[key] % 2 !== 0) {
                if (unevenOccourence !== 0) {
                    returnValue = false;
                } else {
                    unevenOccourence++;
                }
            }
        });
    }

    return returnValue;
}

// Complexity
// Time: O(n^2)
// Space: O(n)
// An optimization of the time complexity would be to: Have some variables to do some checks while 
// iterating through the input string. To then draw a conclusion after having finished iterating
// through it. That way we would bring the time complexity from a polynomial- / quadratic-
// to a linear time complexity.

// Tests
console.log(isRotatedPalindrome("CBAABCD")) // true
console.log(isRotatedPalindrome("BAABCC")) // true
console.log(isRotatedPalindrome("DCABC")) // false
console.log(isRotatedPalindrome("CBAABCC")) // true
console.log(isRotatedPalindrome("BAABCD")) // false
console.log(isRotatedPalindrome("QQWWEERRTTYYUUIIOOPPAASSDDFFGGHHJJKKLLXXCCVVBBNNMMZ")) // true