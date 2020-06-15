using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Design
{
    class LRU_Cache
    {
        Node head = new Node();
        Node tail = new Node();
        int _capacity;
        Dictionary<int, Node> dict;

        public LRU_Cache(int capacity)
        {
            this._capacity = capacity;
            this.dict = new Dictionary<int, Node>();

            this.head.next = this.tail;
            this.tail.previous = this.head;
        }

        public int Get(int key)
        {
            if (!this.dict.ContainsKey(key)) return -1;
            var existingNode = this.dict[key];
            Remove(existingNode);
            Add(existingNode);
            return existingNode.value;
        }

        public void Put(int key, int value)
        {
            if (this.dict.ContainsKey(key)) {
                var existingNode = this.dict[key];
                Remove(existingNode);
                existingNode.value = value;
                Add(existingNode);
            } else {
                if (this.dict.Count == this._capacity) {
                    Node currTail = this.tail.previous;
                    this.tail.previous = currTail.previous;
                    this.dict.Remove(currTail.key);
                    Remove(currTail);
                }
                Node newHead = new Node();
                newHead.key = key;
                newHead.value = value;
                this.dict.Add(key, newHead);
                Add(newHead);
            }
        }

        private void Add(Node node) {
            var prevHead = this.head.next;
            node.next = prevHead;
            node.previous = this.head;
            prevHead.previous = node;
            this.head.next = node;
        }

        private void Remove(Node node) {
            var prevNode = node.previous;
            var nextNode = node.next;

            prevNode.next = nextNode;
            nextNode.previous = prevNode;
        }
    }

    public class Node {
        public int key;
        public int value;
        public Node previous;
        public Node next;
    }

    class Test_LRU_Cache {
        public static void Test() {
            Console.WriteLine("Testing LRU Cache");
            LRU_Cache obj = new LRU_Cache(4);

        }
    }
}
