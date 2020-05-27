// https://leetcode.com/explore/interview/card/amazon/77/linked-list/2976/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        ListNode mergedList = new ListNode(0);
        ListNode head = mergedList;
        ListNode l1Head = l1;
        ListNode l2Head = l2;
        while (l1Head != null || l2Head != null) {
            if (l1Head == null) {
                head.next = l2Head;
                l2Head = l2Head.next != null ? l2Head.next : null;
                head = head.next;
            } else if (l2Head == null) {
                head.next = l1Head;
                l1Head = l1Head.next != null ? l1Head.next : null;
                head = head.next;
            } else {
                if (l1Head.val > l2Head.val) {
                    head.next = l2Head;
                    l2Head = l2Head.next != null ? l2Head.next : null;
                    head = head.next;
                } else if (l1Head.val < l2Head.val) {
                    head.next = l1Head;
                    l1Head = l1Head.next != null ? l1Head.next : null;
                    head = head.next;
                } else {
                    head.next = l1Head;
                    l1Head = l1Head.next != null ? l1Head.next : null;
                    head = head.next;
                    head.next = l2Head;
                    l2Head = l2Head.next != null ? l2Head.next : null;
                    head = head.next;
                }
            }
        }
        return mergedList.next;
    }

    // Simpler solution
    public ListNode MergeLists(ListNode l1, ListNode l2) {
        if (l1 == null) return l2;
        if (l2 == null) return l1;

        if (l1.val < l2.val) {
            l1.next = MergeLists(l1.next, l2);
            return l1;
        } else {
            l2.next = MergeLists(l2.next, l1);
            return l2;
        }
    }
}