using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezaaaaa
{
   public  class TrieNode
    {

        public char letter;
        public TrieNode[] links;
        public bool fullWord;

        public LinkedList_ syn;
        public LinkedList_ ant;
        public string translation;
        public string example;
        public string W;


        public TrieNode(char letter)
        {
            this.letter = letter;
            links = new TrieNode[26];
            this.fullWord = false;


            syn = new LinkedList_();
            ant = new LinkedList_();
        }
    }
}
