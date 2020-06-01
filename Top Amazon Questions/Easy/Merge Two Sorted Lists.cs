// https://leetcode.com/problems/merge-two-sorted-lists/

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
        ListNode result = new ListNode(0);
        ListNode resultHead = result;
        while (l1 != null & l2 != null) {
            if (l1.val <= l2.val) {
                resultHead.next = l1;
                resultHead = resultHead.next;
                l1 = l1.next;
            } else {
                resultHead.next = l2;
                resultHead = resultHead.next;
                l2 = l2.next;
            }
        }
        // Set result's next to remaining nodes of either l1 or l2
        if (l1 != null) resultHead.next = l1;
        if (l2 != null) resultHead.next = l2;

        return result.next;
    }
}