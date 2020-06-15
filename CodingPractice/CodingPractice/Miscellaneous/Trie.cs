// using System;
// using System.Collections.Generic;
// using System.Text;

// namespace CodingPractice
// {
//     class Trie : TrieNode
//     {
//         TrieNode root;
//         public Trie() {
//             root = new TrieNode();
//         }

//         public void Insert(string word) {
//             word = word.ToLower();
//             TrieNode next = root.children[word[0] - 'a'];
//             // if next char doesn't exist, add/create it
//             if (next == null) {
//                 next = new TrieNode();
//                 root.children[word[0] - 'a'] = next;
//             }
//             for (int i = 1; i < word.Length; i++) {
//                 // move to next trie node
//                 if (next.children[word[i] - 'a'] == null) {
//                     var tr = new TrieNode();
//                     next.children[word[i] - 'a'] = tr;
//                 }
//                 next = next.children[word[i] - 'a'];
//             }
//             next.Count = next.Count + 1;
//         }

//         public bool Search(string word) {
//             if (word.Length == 0) return true;
//             word = word.ToLower();
//             TrieNode next = root.children[word[0] - 'a'];
//             for (int i = 1; i < word.Length; i++) {
//                 if (next == null) return false;
//                 next = next.children[word[i] - 'a'];
//             }
//             return next.Count == 0 ? false : true;
//         }

//         public bool Delete(string word) {
//             word = word.ToLower();
//             if (word.Length == 0) return false;
//             var count = DecrementCount(word);
//             if (count == -1) return false;
//             if (count == 0) return RemoveNodes(root, word, 0);
//             return true;
//         }

//         private int DecrementCount(string word) {
//             TrieNode next = root.children[word[0] - 'a'];
//             for (int i = 1; i < word.Length; i++) {
//                 if (next == null) return -1;
//                 next = next.children[word[i] - 'a'];
//             }
//             if (next == null) return -1;
//             else {
//                 next.Count = next.Count - 1;
//                 return next.Count;
//             }
//         }
//         private bool RemoveNodes(TrieNode node, string word, int len) {
//             if (word.Length-1 == len && node.Count == 0 && CheckChildren(node, word[len-1])) {
//                 node.children[word[len] - 'a'] = null;
//                 return true;
//             }
//             if (word.Length > len) {
//                 bool removed = RemoveNodes(node.children[word[len] - 'a'], word, len+1);
//                 if (removed && CheckChildren(node, word[len])) {
//                     node.children[word[len] - 'a'] = null;
//                     return true;
//                 }
//             }
//             return false;
//         }

//         private bool CheckChildren(TrieNode node, char c) {
//             if (node.children[c - 'a'] == null) return true;
//             TrieNode next = node.children[c - 'a'];
//             for (int i = 0; i < next.children.Length; i++) {
//                 if (next.children[i] != null) return false;
//             }
//             return true;
//         }
//     }

//     class TrieNode
//     {
//         public TrieNode[] children;
//         public TrieNode() {
//             Count = 0;
//             children = new TrieNode[26];
//         }

//         public int Count { get; set; }

//         public TrieNode Next(char c) {
//             return children[c - 'a'];
//         }
//     }

//     public class TrieTest {
//         public static void Test() {
//             Trie trie = new Trie();
//             trie.Insert("abba");
//             trie.Insert("abbaa");
//             trie.Insert("trut");
//             trie.Insert("truth");
//             trie.Insert("EUNSUNG");
//             Console.WriteLine(trie.Search("abba"));
//             Console.WriteLine(trie.Search("abbaa"));
//             Console.WriteLine(trie.Search("trut"));
//             Console.WriteLine(trie.Search("truth"));
//             Console.WriteLine(trie.Search("EUNSUNG"));
//             Console.WriteLine(trie.Delete("truth"));
//             Console.WriteLine(trie.Search("truth"));
//             Console.WriteLine(trie.Search("trut"));
//         }

//     }
// }
