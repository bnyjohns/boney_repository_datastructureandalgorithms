using System.Collections.Generic;

namespace DataStructures
{
    class TrieNode
    {
        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
        }
        public Dictionary<char, TrieNode> Children { get; set; }
        public bool End { get; set; }
    }

    public class Trie
    {
        TrieNode root = null;
        public Trie()
        {
            root = new TrieNode();
        }

        public void Add(string word)
        {
            var current = root;
            for (int i = 0; i < word.Length; i++)
            {
                var c = word[i];
                if (current.Children.ContainsKey(c))
                {
                    current = current.Children[c];
                }
                else
                {
                    var node = new TrieNode();
                    current.Children.Add(c, node);
                    current = node;
                }
            }
            current.End = true;
        }

        public bool PrefixExists(string prefix)
        {
            var current = root;
            for(int i = 0; i < prefix.Length; i++)
            {
                var c = prefix[i];
                if(current.Children.ContainsKey(c))
                {
                    current = current.Children[c];
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public bool Search(string word)
        {
            var current = root;
            for(int i = 0; i < word.Length; i++)
            {
                var c = word[i];
                if (current.Children.ContainsKey(c))
                {
                    current = current.Children[c];
                }
                else
                {
                    return false;
                }
            }
            return current.End;
        }
    }
}
