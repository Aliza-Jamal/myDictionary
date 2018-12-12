using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezaaaaa
{
   public  class PrefixTree
    {
        public static TrieNode createTree()
        {
            return (new TrieNode('\0'));
        }
       
        public static bool InsertWordInTrie(TrieNode root, string word, int j, int k)
        {


            int offset = 97;
            int l = word.Length;
            char[] letters = word.ToCharArray();
            TrieNode curNode = root;

            for (int i = 0; i < l; i++)
            {
                if (curNode.links[letters[i] - offset] == null)
                    curNode.links[letters[i] - offset] = new TrieNode(letters[i]);
                curNode = curNode.links[letters[i] - offset];
            }
            curNode.fullWord = true;


            for (int i = j; i < j + 4; i++)
            {
                curNode.syn.Insert(Dictionary.ListOfSynonyms.Get(i));
                curNode.ant.Insert(Dictionary.ListOfAntonyms.Get(i));

            }


            curNode.example = Dictionary.ListOfExamples.Get(k);
            curNode.translation = Dictionary.ListOfTranslations.Get(k);
            curNode.W = word;






            return true;

        }


        public static TrieNode SearchInTrie(TrieNode root, string word)
        {
            char[] letters = word.ToCharArray();
            int l = letters.Length;
            int offset = 97;
            TrieNode curNode = root;

            int i;
            for (i = 0; i < l; i++)
            {
                if (curNode == null)
                {
                    Console.WriteLine("not found");
                    return null;
                } curNode = curNode.links[letters[i] - offset];
            }

            if (i == l && curNode == null)
            {

                Console.WriteLine("not found");
                return null;
            }

            if (curNode != null && !curNode.fullWord)
            {
                Console.WriteLine("not found");
                return null;
            }



            return curNode;
        }


        public static void AutoSuggest(TrieNode root, int level, char[] branch, string a)
        {
            if (root == null)
                return;

            for (int i = 0; i < root.links.Length; i++)
            {
                branch[level] = root.letter;
                AutoSuggest(root.links[i], level + 1, branch, a);
            }

            if (root.fullWord)
            {
                string s = "";

                {
                    for (int l = 0; l < level; l++)
                    {
                        s += ((branch[l + 1]));
                    }
                }


                if (s.StartsWith(a) && s != a) 
                {
                    Dictionary.autoSuggest.Insert(s);
                }

            }


        }
    }
}
