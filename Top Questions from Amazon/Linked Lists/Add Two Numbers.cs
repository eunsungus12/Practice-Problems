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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode result = new ListNode(0);
        ListNode tracker = result;
        ListNode lOne = l1;
        ListNode lTwo = l2;
        int remainder = 0;
        while (lOne != null || lTwo != null) {
            int o = (lOne != null) ? lOne.val : 0;
            int t = (lTwo != null) ? lTwo.val : 0;
            int total = remainder + o + t;
            remainder = total / 10;
            tracker.next = new ListNode(total % 10);
            tracker = tracker.next;
            if (lOne != null) lOne = lOne.next;
            if (lTwo != null) lTwo = lTwo.next;
        }
        if (remainder > 0) {
            tracker.next = new ListNode(remainder);
        }
        return result.next;
    }
}
