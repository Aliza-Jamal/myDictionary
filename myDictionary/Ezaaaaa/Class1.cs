using System;

 public class TrieNode
    {
        public char letter;
        public TrieNode[] links;
        public bool fullWord;

        public LinkedList_ syn;
        public LinkedList_ ant;
        public string translation;
        public string example;
        public string W;

        // word_ w = new word_("df","DFDf","dfdsf");
        public TrieNode(char letter)
        {
            this.letter = letter;
            links = new TrieNode[26];
            this.fullWord = false;


            syn = new LinkedList_();
            ant = new LinkedList_();
        }
    }
    public class PrefixTree
    {

        public static TrieNode createTree()
        {
            return (new TrieNode('\0'));
        }

     

        public static void insertWord(TrieNode root, string word, int j)
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



            j = j + 2;


        }

        public static bool insertWord1(TrieNode root, string word, int j, int k)
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
                curNode.syn.Insert(Program.syn1.Get(i));
                curNode.ant.Insert(Program.ant1.Get(i));

            }


            curNode.example = Program.exp.Get(k);
            curNode.translation = Program.tra.Get(k);
            curNode.W = word;






            return true;

        }

        public static bool find(TrieNode root, String word)
        {
            char[] letters = word.ToCharArray();
            int l = letters.Length;
            int offset = 97;
            TrieNode curNode = root;

            int i;
            for (i = 0; i < l; i++)
            {
                if (curNode == null)
                    return false;
                curNode = curNode.links[letters[i] - offset];
            }

            if (i == l && curNode == null)
            {
                return false;
            }

            if (curNode != null && !curNode.fullWord)
            {
                return false;
            }

            Console.WriteLine("Synonyms");

            curNode.syn.PrintWholeList();

            Console.WriteLine("antonym");

            curNode.ant.PrintWholeList();

            return true;
        }
        public static TrieNode find1(TrieNode root, string word)
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


            /*
            Console.WriteLine("meaning");
            Console.WriteLine(curNode.translation);
            Console.WriteLine("example");
            Console.WriteLine(curNode.example);
            Console.WriteLine("Synonyms");

            curNode.syn.PrintWholeList();

            Console.WriteLine("antonym");
            curNode.ant.PrintWholeList();
            */

            return curNode;
        }

        public static void printTree(TrieNode root, int level, char[] branch)
        {
            if (root == null)
                return;

            for (int i = 0; i < root.links.Length; i++)
            {
                branch[level] = root.letter;
                printTree(root.links[i], level + 1, branch);
            }

            if (root.fullWord)
            {
                for (int j = 1; j <= level; j++)
                    Console.Write(branch[j]);
                Console.WriteLine();
            }


        }
        public static void printTree1(TrieNode root, int level, char[] branch)
        {
            if (root == null)
                return;

            for (int i = 0; i < root.links.Length; i++)
            {
                branch[level] = root.letter;
                printTree1(root.links[i], level + 1, branch);
            }


            if (root.fullWord)
            {
                for (int j = 1; j <= level; j++)
                {
                    Console.Write(branch[j]);

                }
                string[] s = new string[100];

                for (int k = 0; k < level; k++)
                {
                    s[k] += ((branch[k + 1]).ToString());
                }


                Console.WriteLine();
                for (int k = 0; k < level; k++)
                {

                    Console.Write(s[k]);


                }
                Console.WriteLine();

            }


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


                if (s.StartsWith(a))
                {
                    Console.WriteLine(s);
                }



            }


        }


    }
    public class LinkedList_
    {   // Now this is our Main LinkedList
        public NODE Head;       // Just a Node same as a pointer in c 
        // When ever LinkedList object is created means it will create a head automatically


        public LinkedList_()    //Constructor
        {
            Head = null;         // By default head is null !!
        }


        public bool IsEmpty()  //Optional Function You can remove this , not necessary just indicating wether list is empty or not
        {
            if (Head == null)
                return true;
            else
                return false;
        }
        // Now the Game begins !! :P


        public void Insert(string value)  //  INSERT FUNTION
        {
            NODE newNode = new NODE(value);   // Creating Node with value that u want to insert

            if (Head == null)             // simple if head is null we make our new node = head !!
            {
                Head = newNode;
            }
            else
            {
                NODE current = Head;   // else we put our head into a Node naming "temp" just to traverse through 
                while (current.next != null)//the list in order to find a node whos next is null means last node
                {
                    current = current.next;
                }
                current.next = newNode;  // we exit from loop as soon as we found the last node then put our new
                // node in the next of it !!
            }

        }
        public int Length()
        {
            int i = 0;
            NODE current = Head;
            while (current != null)
            {

                current = current.next;
                i++;

            }
            return i;

        }
        public int size()
        {
            int count = 0;
            NODE current = Head;
            while (current != null)
            {
                current = current.next;
                count++;
            }
            return count;
        }


        public string Search(string value)  //Search
        {
            NODE temp = Head;               //Temporary node to traverse
            bool state = false;         // just to help us in the end of this funtion wehter value is there or not

            while (temp != null)
            {
                if (temp.data == value)
                {
                    Console.WriteLine("Value Found");
                    state = true;
                    return temp.data;  // if value found we print then return the value and functions end here
                }                     // will not go down further for execution
                else
                    temp = temp.next;
            }

            if (state == false)
            {
                Console.WriteLine("Value Not Found");

            }
            return "-999";  // if value not found return -999
        }


        public void Delete(string value) //DELETE
        {
            NODE current = Head;
            NODE tempPrevious = null;

            if (IsEmpty() == true)    // same as Head==null using the function !! OPtional one above
            {
                Console.WriteLine("LINKEDLIST IS EMPTY");
            }

            else
            {

                if (Head.data == value)  // if Head is the value to be deleted then we simply do this !!
                {
                    Head = Head.next;
                }

                else
                {
                    while (current != null)
                    {
                        if (current.data == value)
                        {
                            tempPrevious.next = current.next;
                            current = null;
                        }
                        else
                        {
                            tempPrevious = current;
                            current = current.next;
                        }
                    }
                }
            }


        }

        public class NODE
        {                  // JUST A SINGLE NODE


            public string data;
            public NODE next;

            public NODE(string item)   // CONSTRUCTOR OF YOUR NODE 
            {
                this.data = item;
                this.next = null;       // By Default the "Next" of Every node is NULL and value = what u want to insert
                // will change the next later !! when Creating Linkedlist
            }

            public void Display()
            {
                Console.WriteLine("Your Value :" + this.data);
            }

        }


        public void PrintWholeList() // To Print whole List OPTIONAL !!
        {
            NODE temp = Head;               //Temporary node to traverse

            int i = 0;
            while (temp != null)
            {
                Console.WriteLine("\t No: " + i + "\t VALUE : " + temp.data);
                temp = temp.next;
                i++;
            }
        }


        public void get(int i) // this is a main function !! will do this later !! this will give u the value at the given
        {                       // index but for that have to add a new feild in node then in every above function quite tired right now 
            // So sorry will do that later !!

        }

        public string Get(int index)
        {
            NODE current = Head;
            int count = 0; /* index of Node we are
                          currently looking at */
            while (current != null)
            {
                if (count == index)
                    return current.data;
                count++;
                current = current.next;
            }

            /* if we get to this line, the caller was asking
            for a non-existent element so we assert fail */
            //assert(false);



            return null;
        }

    }




