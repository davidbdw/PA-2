using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Trie
    {

        public TrieNode overallRoot;
        public int count = 0;

        public Trie()
        {
            this.overallRoot = new TrieNode();
        }

        public void insert(string s)
        {
            char letter = Convert.ToChar(s.Substring(0, 1));

            if (isEntry(s))
            {
                insertHelper(this.overallRoot, s);
            }
        }


        private TrieNode insertHelper(TrieNode node, string s)
        {
            char letter = Convert.ToChar(s.Substring(0, 1));

            if (node.children.ContainsKey(letter))
            {
                this.overallRoot = insertHelper(node.children[letter], s);
            }

            if (s.Length == 1)
            {
                this.overallRoot = new TrieNode(Convert.ToChar(s), true); 
                return this.overallRoot;
            }
            else
            {
                char firstLetter = Convert.ToChar(s.Substring(0, 1));
                char secondLetter = Convert.ToChar(s.Substring(1, 1));
                string remaining = s.Substring(1, s.Length - 1);
                if (node.letter == char.MinValue)
                {
                    this.overallRoot.letter = letter;
                }
                if (node.children.ContainsKey(letter))
                {
                    this.overallRoot = insertHelper(node.children[letter], remaining);
                }
                else
                {
                    this.overallRoot.children.Add(secondLetter, insertHelper(this.overallRoot, remaining));
                }
                return node;
            }
        }

        public List<string> search(string s)
        {
            List<string> tenResults = new List<string>();
            tenResults = searchHelper(this.overallRoot, s, tenResults);

            return tenResults;
        }

        private List<string> searchHelper(TrieNode root, string s, List<string> tenResults)
        {
            TrieNode current = root;
            char firstLetter = Convert.ToChar(s.Substring(0, 1));
            if (current.word) 
            {
      
                char secondLetter = Convert.ToChar(s.Substring(1, 1));
                string leftOver = s.Substring(1, s.Length - 1);
                char remaining = Convert.ToChar(leftOver);

                foreach (char c in s)
                {
                    Dictionary<char, TrieNode> child = current.childDict;
                    if (child.ContainsKey(c) && current.isWord)
                    {
                        tenResults.Add(s);
                        count++;
                        current = root.getChildNode(c);
                    }
                    if (count == 10)
                    {
                        break;
                    }
                }
            }
            else
            {
                searchHelper(current.getChildNode(firstLetter), s, tenResults);
            }
            return tenResults;
        }

        private bool isEntry(string s)
        {
            if (s.Split('_').Length > 2)
            {
                return false;
            }

            foreach (char character in s)
            {
                if ((character != ' ') && (character != '_') && ((character < 'a') || (character > 'z')) && ((character < 'A') || (character > 'Z')))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
     
