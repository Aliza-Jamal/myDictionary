using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ezaaaaa
{
   public  class readFile
    {
       

        public static void ReadFileData()
        {
            string[] s = new string[50];
            string[] s1 = new string[50];
            int p = 0;
            StreamReader sr = new StreamReader(@"file.txt");
            StreamReader sr1 = new StreamReader(@"file.txt");
            string file = sr1.ReadToEnd();
            string[] fileContent = file.Split('\n');


            for (int i = 0; i < fileContent.Length; i = i + 5)
            {
                Dictionary.W.Insert(sr.ReadLine());
                Dictionary.ListOfTranslations.Insert(sr.ReadLine());
                Dictionary.ListOfExamples.Insert(sr.ReadLine());
                s[p] = sr.ReadLine();

                string[] syn = s[p].Split(',');
                for (int z = 0; z < syn.Length; z++)
                {
                    Dictionary.ListOfSynonyms.Insert(syn[z]);
                }
                s1[p] = sr.ReadLine();

                string[] ant = s1[p].Split(',');
                for (int z = 0; z < ant.Length; z++)
                {
                    Dictionary.ListOfAntonyms.Insert(ant[z]);
                }
                p++;

            }



            sr.Close();
            sr1.Close();

        }

        public static TrieNode fileInsert()
        {
            ReadFileData();


            TrieNode tree = new TrieNode('\0');


            for (int i = 0; i < Dictionary.W.Length(); i++)
            {
                PrefixTree.InsertWordInTrie(tree, Dictionary.W.Get(i), Dictionary.j, Dictionary.k);
                Dictionary.j = Dictionary.j + 4;
                Dictionary.k++;
            }
            return tree;
        }
       
    }
}
