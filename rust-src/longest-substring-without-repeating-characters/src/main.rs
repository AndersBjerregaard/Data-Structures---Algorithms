/*
Given a string s, find the length of the longest substring without duplicate characters.

Example 1:

Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.

Example 2:

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.

Example 3:

Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

Constraints:

0 <= s.length <= 5 * 104
s consists of English letters, digits, symbols and spaces.
*/

use std::{collections::HashSet, iter::Skip, str::Chars};

fn main() {
    println!("Hello, world!");
}

pub fn length_of_longest_substring(s: String) -> i32 {
    let mut max: i32 = 0;
    let mut i: usize = 0;
    while i < s.chars().count() {
        let mut k: usize = 0;
        let mut chars: Skip<Chars<'_>> = s.chars().skip(i);
        let mut characters: HashSet<char> = HashSet::new();
        let mut current: i32 = 0;
        while k < s.chars().skip(i).count() {
            let c: char = chars.next().unwrap();
            if characters.contains(&c) {
                break;
            } else {
                current += 1;
            }
            characters.insert(c);
            if current > max {
                max = current;
            }
            k += 1;
        }
        i += 1;
    }
    max
}

#[test]
fn test1() {
    let input: String = String::from("abcabcbb");

    let result: i32 = length_of_longest_substring(input);

    assert_eq!(result, 3);
}

#[test]
fn test2() {
    let input: String = String::from("bbbbb");

    let result: i32 = length_of_longest_substring(input);

    assert_eq!(result, 1);
}

#[test]
fn test3() {
    let input: String = String::from("pwwkew");

    let result: i32 = length_of_longest_substring(input);

    assert_eq!(result, 3);
}

#[test]
fn test4() {
    let input: String = String::from("aab");

    let result: i32 = length_of_longest_substring(input);

    assert_eq!(result, 2);
}

#[test]
fn test5() {
    let input: String = String::from("dvdf");

    let result: i32 = length_of_longest_substring(input);

    assert_eq!(result, 3);
}

#[test]
fn test6() {
    let input: String = String::from("abcdeafg");

    let result: i32 = length_of_longest_substring(input);

    assert_eq!(result, 7);
}
