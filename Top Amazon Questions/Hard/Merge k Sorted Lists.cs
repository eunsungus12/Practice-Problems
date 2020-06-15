// https://leetcode.com/problems/merge-k-sorted-lists/

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
    public ListNode MergeKLists(ListNode[] lists) {
        if (lists.Length == 0) return null;
        if (lists.Length == 1) return lists[0];

        return MergeSort(lists);
    }
    
    private ListNode MergeSort(ListNode[] lists) {
        if (lists.Length == 1) return lists[0];
        
        ListNode[] leftList = new ListNode[lists.Length/2];
        ListNode[] rightList = new ListNode[lists.Length - lists.Length/2];
        for (int i = 0; i < lists.Length; i++) {
            if (i < lists.Length / 2) {
                leftList[i] = lists[i];
            } else {
                rightList[i-lists.Length/2] = lists[i];
            }
        }
        ListNode left = MergeSort(leftList);
        ListNode right = MergeSort(rightList);
        
        return Merge(left, right);
    }
    
    private ListNode Merge(ListNode left, ListNode right) {
        ListNode result = new ListNode(0);
        ListNode resultHead = result;

        while (left != null && right != null) {
            if (left.val <= right.val) {
                resultHead.next = left;
                resultHead = resultHead.next;
                left = left.next;
            } else {
                resultHead.next = right;
                resultHead = resultHead.next;
                right = right.next;
            }
        }
        
        while (left != null) {
            resultHead.next = left;
            resultHead = resultHead.next;
            left = left.next;
        }
        while (right != null) {
            resultHead.next = right;
            resultHead = resultHead.next;
            right = right.next;
        }

        return result.next;
    }
}

// Time Complexity: O(nlog(n))
// Space Complexity: O(1)