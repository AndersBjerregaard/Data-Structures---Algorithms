// Source: https://leetcode.com/problems/add-two-numbers/

/*
You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Example 1:

Input: l1 = [2,4,3], l2 = [5,6,4]
Output: [7,0,8]
Explanation: 342 + 465 = 807.

Example 2:

Input: l1 = [0], l2 = [0]
Output: [0]

Example 3:

Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
Output: [8,9,9,9,0,0,0,1]

Constraints:

The number of nodes in each linked list is in the range [1, 100].
0 <= Node.val <= 9
It is guaranteed that the list represents a number that does not have leading zeros.

*/

fn main() {
    println!("Hello, world!");
}

pub mod add_two_numbers {
    // Definition for singly-linked list.
    #[derive(PartialEq, Eq, Clone, Debug)]
    pub struct ListNode {
      pub val: i32,
      pub next: Option<Box<ListNode>>
    }

    impl ListNode {
      #[inline]
      fn new(val: i32) -> Self {
        ListNode {
          next: None,
          val
        }
      }
    }

    pub fn add_two_numbers(l1: Option<Box<ListNode>>, l2: Option<Box<ListNode>>) -> Option<Box<ListNode>> {
      Some(Box::new(ListNode::new(0)))
    }

    #[test]
    fn test1() {
      let node1: Option<Box<ListNode>> = Some(Box::new(ListNode { val: 2, next: Some(Box::new(ListNode { val: 4, next: Some(Box::new(ListNode { val: 3, next: None })) })) }));

      let node2: Option<Box<ListNode>> = Some(Box::new(ListNode { val: 5, next: Some(Box::new(ListNode { val: 6, next: Some(Box::new(ListNode { val: 4, next: None })) })) }));

      let mut result: Option<Box<ListNode>> = add_two_numbers(node1, node2);

      let mut resultString = String::from("");

      while result.is_some() {
        let value = result.clone().unwrap();
        
        let innerValue = value.val;

        /*
          let mut s = String::from("bar");
          s.insert_str(0, "foo");
          assert_eq!("foobar", s);
        */

        let innerValueConverted = innerValue.to_string();

        resultString.insert_str(resultString.len(), &innerValueConverted);

      }
    }
}