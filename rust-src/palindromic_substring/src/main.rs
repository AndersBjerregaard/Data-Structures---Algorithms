/*
Given a string s, return the longest palindromic substring in s.

 

Example 1:

Input: s = "babad"
Output: "bab"
Explanation: "aba" is also a valid answer.
Example 2:

Input: s = "cbbd"
Output: "bb"
 

Constraints:

1 <= s.length <= 1000
s consist of only digits and English letters.
*/

fn main() {
    println!("Hello, world!");
}

pub fn longest_palindrome(s: String) -> String {
    todo!()
}

#[test]
fn test1() {
    let input: String = String::from("babad");
    let output: String = longest_palindrome(input);
    let expected: String = String::from("bab");
    assert_eq!(output, expected);
}

#[test]
fn test2() {
    let input: String = String::from("cbbd");
    let output: String = longest_palindrome(input);
    let expected: String = String::from("bb");
    assert_eq!(output, expected);
}