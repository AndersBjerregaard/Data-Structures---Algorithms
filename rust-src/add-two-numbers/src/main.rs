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

      let mut dummy_head: Option<Box<ListNode>> = Some(Box::new(ListNode { val: 0, next: None }));
      let mut current: &mut Option<Box<ListNode>> = &mut dummy_head;

      let mut carry: i32 = 0;

      let mut n1: Option<Box<ListNode>> = l1.clone();
      let mut n2: Option<Box<ListNode>> = l2.clone();

      while n1.is_some() || n2.is_some() || carry != 0 {

        let mut sum: i32 = carry.clone();

        if n1.is_some() {

          let n1_value: Box<ListNode> = n1.unwrap();

          sum += n1_value.val;

          let temp: &Option<Box<ListNode>> = &n1_value.next;

          n1 = temp.clone();

        }

        if n2.is_some() {

          let n2_value: Box<ListNode> = n2.unwrap();

          sum += n2_value.val;

          let temp: &Option<Box<ListNode>> = &n2_value.next;

          n2 = temp.clone();

        }

        carry = sum / 10;

        current.as_mut().unwrap().next = Some(Box::new(ListNode { val: sum % 10, next: None }));

        let temp: &mut Option<Box<ListNode>> = &mut current.as_mut().unwrap().next;

        current = temp;

      }

      dummy_head.unwrap().next

    }

    #[test]
    fn test1() {
      let node1: Option<Box<ListNode>> = Some(Box::new(ListNode { val: 2, next: Some(Box::new(ListNode { val: 4, next: Some(Box::new(ListNode { val: 3, next: None })) })) }));

      let node2: Option<Box<ListNode>> = Some(Box::new(ListNode { val: 5, next: Some(Box::new(ListNode { val: 6, next: Some(Box::new(ListNode { val: 4, next: None })) })) }));

      let mut result: Option<Box<ListNode>> = add_two_numbers(node1, node2);

      let mut result_string: String = String::from("");

      while result.is_some() {
        let value: Box<ListNode> = result.clone().unwrap();
        
        let inner_value: i32 = value.val;

        let inner_value_converted: String = inner_value.to_string();

        result_string.insert_str(result_string.len(), &inner_value_converted);

        let next: Option<Box<ListNode>> = value.next;

        result = next;
      }

      assert_eq!("708", result_string);
    }
}