using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Speech;
using System.Speech.Synthesis;

namespace Ezaaaaa
{
    
    public partial class Dictionary : Form
    {
        public static int k = 0, j = 0;
        public static LinkedList_ W = new LinkedList_();
        public static LinkedList_ ListOfTranslations = new LinkedList_();
        public static LinkedList_ ListOfExamples = new LinkedList_();
        public static LinkedList_ ListOfSynonyms = new LinkedList_();
        public static LinkedList_ ListOfAntonyms = new LinkedList_();
        public static LinkedList_ autoSuggest = new LinkedList_();

        TrieNode t = readFile.fileInsert();
        SpeechSynthesizer sp;

        public Dictionary()
        {
            InitializeComponent();
        }
      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
           
   
        }

        private void button1_Click(object sender, EventArgs e)    // SerachButton
        {
            SearchWord(t);
            Dictionary.autoSuggest.deleteAll();
            
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

   
        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void InsertButton_Click(object sender, EventArgs e)
        {
            MenuScreen.Visible = false;
            InsertScreen.Visible = true;
            SerachWordScreen.Visible = false;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            MenuScreen.Visible = false;
            SerachWordScreen.Visible = true;


         
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            textBox1.Text = listBox2.SelectedItem.ToString();
            SearchWord(t);
            Dictionary.autoSuggest.deleteAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertWord(t);
            MenuScreen.Visible = true;
            InsertScreen.Visible = false;
            SerachWordScreen.Visible = false;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            MenuScreen.Visible = true;
            InsertScreen.Visible = false;
            SerachWordScreen.Visible = false;
        }

        private void Dictionary_Load(object sender, EventArgs e)
        {
            sp = new SpeechSynthesizer();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
          
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }


        public void InsertWord(TrieNode tree)
        {

            TextWriter tsw = new StreamWriter(@"file.txt", true);
            string[] SynonymToBeInserted = new string[4];
            string[] AntonymToBeInserted = new string[4];

            if (textBox2.Text == "")
            {

                MessageBox.Show("Please enter the WORD properly ", "Warning", MessageBoxButtons.OK);
                return;

            }
            else
               if (textBox3.Text == "")
               {

                   MessageBox.Show("Please enter MEANING of the Word properly ", "Warning", MessageBoxButtons.OK);

                   return;

               }
               else
                   if
                       (textBox4.Text == "")
                   {

                       MessageBox.Show("Please enter SENTENCE of the Word as an example", "Warning", MessageBoxButtons.OK);

                       return;

                   }




            string w = textBox2.Text.ToString();
            Dictionary.W.Insert(w);

           
            string t = textBox3.Text.ToString();
            Dictionary.ListOfTranslations.Insert(t);
            
            
            string ex = textBox4.Text.ToString();
            Dictionary.ListOfExamples.Insert(ex);

           


            string synonym = textBox5.Text.ToString();
            SynonymToBeInserted = synonym.Split(',');

            if (SynonymToBeInserted.Length != 4)
            {
                MessageBox.Show("You can enter maximum FOUR Synonyms, Please follow the given pattern:\n\n <Synonym1>,<Synonym2>,<Synonym3>,<Synonym4>\n\nIf you want to insert less than four than write <space> in place of Synonyms ", "Warning", MessageBoxButtons.OK);
                return;
            }

            else
            {

                for (int i = 0; i < SynonymToBeInserted.Length; i++)
                {

                    Dictionary.ListOfSynonyms.Insert(SynonymToBeInserted[i]);

                }
            }


            string antonym = textBox6.Text.ToString();
            AntonymToBeInserted = antonym.Split(',');

            if (AntonymToBeInserted.Length != 4)
            {
                MessageBox.Show("You can enter maximum FOUR Antonyms, Please follow the given pattern:\n\n <Antonym1>,<Antonym2>,<Antonym3>,<Antonym4>\n\nIf you want to insert less than four than write <space> in place of Antonym ", "Warning", MessageBoxButtons.OK);
                return;
            }

            else
            {
                for (int i = 0; i < AntonymToBeInserted.Length; i++)
                {

                    Dictionary.ListOfAntonyms.Insert(AntonymToBeInserted[i]);
                }

            }

           

                PrefixTree.InsertWordInTrie(tree, w, Dictionary.j, Dictionary.k);
                Dictionary.j = Dictionary.j + 4;
                Dictionary.k++;

                tsw.WriteLine();
                tsw.WriteLine("{0}", w);
                tsw.WriteLine("{0}", t);
                tsw.WriteLine("{0}", ex);
                tsw.WriteLine("{0},{1},{2},{3}", SynonymToBeInserted[0], SynonymToBeInserted[1], SynonymToBeInserted[2], SynonymToBeInserted[3]);
                tsw.Write("{0},{1},{2},{3}", AntonymToBeInserted[0], AntonymToBeInserted[1], AntonymToBeInserted[2], AntonymToBeInserted[3]);
               
            
            tsw.Close();
        }
        public void SearchWord(TrieNode tree)
        {


            char[] branch = new char[50];


           
            string searchWord = textBox1.Text.ToString().ToLower();
            
            PrefixTree.AutoSuggest(tree, 0, branch, searchWord);
           
            TrieNode tr = PrefixTree.SearchInTrie(tree, searchWord);
            listBox3.Items.Clear();
            for (int i = 0; i < Dictionary.autoSuggest.Length(); i++)
            {
                listBox3.Items.Add(Dictionary.autoSuggest.Get(i));
            }
           
            if (tr != null)
            {
               
               
                label2.Text = tr.translation;
                label4.Text = tr.example;

                listBox1.Items.Clear();
                for(int i=0;i < tr.syn.Length();i++)
                {
                    listBox1.Items.Add(tr.syn.Get(i));
                }
                listBox2.Items.Clear();
                for (int i = 0; i < tr.ant.Length(); i++)
                {
                    
                    listBox2.Items.Add(tr.ant.Get(i));
                }
               
            }
            else
            {
               // label1.Text = "NOT FOUND";
                label2.Text = "NOT FOUND";
                label4.Text = "-";
                listBox1.Items.Clear();
                listBox1.Items.Add("-");
                listBox2.Items.Clear();
                listBox2.Items.Add("-");
            }


        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox3.SelectedItem.ToString();
            SearchWord(t);
            Dictionary.autoSuggest.deleteAll();
              
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.SelectedItem.ToString();
            SearchWord(t);
            Dictionary.autoSuggest.deleteAll();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        

        private void MenuTab_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            sp.Dispose();
            if (textBox1.Text != "")    //if text area is not empty 
            {

                sp = new SpeechSynthesizer();
                sp.SpeakAsync(textBox1.Text);
                
            }
            else
            {
                MessageBox.Show("Please enter some text in the Serach Bar", "Message", MessageBoxButtons.OK);
            } 
        }

    }
}
