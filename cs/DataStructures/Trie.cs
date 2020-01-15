using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hello_dotnet_core.DataStructures
{
    /*
     * A tree data structure which stores words as input. Words can be retrieved
     * by prefix using Search(). Numbers, letters, and punctuation are stripped.
     */
    public class Trie
    {
        static char[] ValidChars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        Node[] root = new Node[26];

        public void Insert(String s)
        {
            char[] chars = normalizeString(s);

            // Keep a reference to the current set of nodes. Begin at the root.
            // Traverse down the tree.
            Node[] nodes = root;

            // Keep reference to this node because it needs to be marked as "complete"
            // In other words, it marks a complete word.
            Node n = null;
            foreach (char c in chars)
            {
                int i = getCharIndex(c);
                n = nodes[i];

                // If null, create the node.
                if (n == null)
                {
                    n = new Node(c);
                    nodes[i] = n;
                }

                nodes = n.Children;
            }

            n.Complete = true;
        }

        public string[] Search(string prefix)
        {
            // Blow up the and search from the first character
            char[] chars = normalizeString(prefix);

            // Traverse all the way down to the end node if it exists.
            // Otherwise return an empty array.
            Node[] nodes = root;
            Node n = null;
            foreach(char c in chars)
            {
                n = nodes[getCharIndex(c)];
                if (n == null) return new string[0];
                nodes = n.Children;
            }

            // Got to the end of the input. Now find all words which are children of this node.
            List<string> words = new List<string>();

            // The last character of the word will be added back to the string in the _findWords method.
            string s = string.Join("", chars).Substring(0,chars.Length - 1);
            _findWords(n, words, s);
            return words.ToArray();
        }

        private static void _findWords(Node node, List<string> words, string s)
        {
            if (node == null) return;
            s += node.Value;

            if (node.Complete)
            {
                words.Add(s);
            }

            // Recursively find words
            foreach(Node n in node.Children)
            {
                // Need a new StringBuilder for each node to avoid appending sibling characters
                _findWords(n, words, s);
            }
        }

        private static int getCharIndex(char c)
        {
            return Array.IndexOf(ValidChars, c);
        }

        // Lowercases string and removes all invalid characters
        private static char[] normalizeString(string s)
        {
            return s.ToLower()
                .ToCharArray()
                .Where(c => ValidChars.Contains(c))
                .ToArray();
        }
    }

    class Node
    {
        private char _c;
        private bool _complete = false;
        private Node[] _children = new Node[26];

        public Node(char c)
        {
            this._c = c;
            this._children = new Node[26];
        }

        public Node[] Children
        {
            get => this._children;
        }

        public bool Complete {
            get => this._complete;
            set => this._complete = value;
        }

        public char Value
        {
            get => this._c;
        }
    }
}
