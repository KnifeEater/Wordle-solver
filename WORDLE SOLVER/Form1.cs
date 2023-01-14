using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Checker(string[] Words, char[] charsY, char[] charsR)//before output, important
        {//checks if code can safely proceed :-)
            int len = maskedTextBox1.Text.Length + maskedTextBox2.Text.Length + maskedTextBox3.Text.Length + maskedTextBox4.Text.Length + maskedTextBox5.Text.Length + maskedTextBox6.Text.Length;
            if (len > 5) { label6.Text = "INVALID INPUT"; label6.Visible = true; return; }
            if (radioButton2.Checked) { Advanced_search(Words, charsR, charsY, int.Parse(label7.Text)); }
            else if (radioButton1.Checked) { Search(Words, charsR, charsY, int.Parse(label7.Text)); }
        }
        private void Add()//Counter add
        {
            label7.Text = (int.Parse(label7.Text) + 1).ToString();
        }
        private void Reset()//Counter reset
        {
            label7.Text = "0"; 
        }
        static bool duplicate(string Word, char[] charsY, char[] charsR)//Better algoritm (opcional, advanced)
        {
            int[] probna = { 1, 1, 1, 1, 1 };
            char[] charsYkopija = charsY;
            for (int l = 0; l < 5; l++)
            {
                if (charsR[l] != '\0') { probna[l] = 0; }
            }
            for (int l = 0; l < 5 && charsYkopija.Length != 0; l++)
            {
                if (probna[l] == 1 && charsYkopija.Contains(Word[l]))
                {
                    int numIndex = Array.IndexOf(charsYkopija, Word[l]);
                    char[] pr = new char[charsYkopija.Length - 1];
                    Array.Copy(charsYkopija, 0, pr, 0, numIndex);
                    Array.Copy(charsYkopija, numIndex + 1, pr, numIndex, charsYkopija.Length - 1 - numIndex);
                    charsYkopija = pr;
                    probna[l] = 0;
                }
            }
            for (int A = 0; A < 5; A++)
            {
                for (int B = A + 1; B < 5; B++)
                {
                    if ((probna[A] != probna[B] || probna[A] == 1 && probna[B] == 1) && Word[A] == Word[B])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool Checkerv2(string Word)
        {
            char[] nonochars = textBox1.Text.ToCharArray();
            for (int i = 0; i < 5; i++)
            {
                if (nonochars.Contains(Word[i])) { return false; }
            }
            return true;
        }
        private void Search(string[] Words, char[] charsR, char[] charsY, long FF)//Output
        {
            char[] charsYprobna = charsY;
            foreach (string Word in Words)
            {
                charsY = charsYprobna;
                if (Word.Length != 5) { continue; }
                bool pass = true;
                for (int i = 0; i < 5; i++)
                {
                    if (charsR[i] != '\0' && Word[i] != charsR[i]) { pass = false; break; }
                    else if (charsR[i] == '\0' && charsY.Contains(Word[i]))
                    {
                        int numIndex = Array.IndexOf(charsY, Word[i]);
                        char[] probna = new char[charsY.Length - 1];
                        Array.Copy(charsY, 0, probna, 0, numIndex);
                        Array.Copy(charsY, numIndex + 1, probna, numIndex, charsY.Length - 1 - numIndex);
                        charsY = probna;
                    }
                }
                if (charsY.Length != 0) { continue; }
                if (pass == true)//Word passed as valid
                {
                    if (checkBox1.Checked && !duplicate(Word, charsYprobna, charsR)) { continue; }
                    if (checkBox2.Checked && !Checkerv2(Word)) { continue; }
                    if (FF != 0) { FF--; continue; }
                    label6.Text = "WORD FOUND: " + Word;
                    label6.Visible = true;
                    button2.Visible = true;
                    break;
                }
            }
        }
        private void Popunjavanje()
        {
            string[] Words = File.ReadAllLines(@"dictionary.txt");
            char[] charsR = new char[5];
            try { charsR[0] = maskedTextBox1.Text[0]; }
            catch (Exception) { charsR[0] = '\0'; }
            try { charsR[1] = maskedTextBox2.Text[0]; }
            catch (Exception) { charsR[1] = '\0'; }
            try { charsR[2] = maskedTextBox3.Text[0]; }
            catch (Exception) { charsR[2] = '\0'; }
            try { charsR[3] = maskedTextBox4.Text[0]; }
            catch (Exception) { charsR[3] = '\0'; }
            try { charsR[4] = maskedTextBox5.Text[0]; }
            catch (Exception) { charsR[4] = '\0'; }
            char[] charsY = maskedTextBox6.Text.ToCharArray();
            Checker(Words, charsY, charsR);
        }
        private void button1_Click(object sender, EventArgs e)//Output
        {
            Popunjavanje();
        }
        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            Reset();
            label6.Visible = false;
            button2.Visible = false;
            if (button5.Visible || button4.Visible) { button3_Click(sender, e); }
            maskedTextBox2.Select();
        }
        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            Reset();
            label6.Visible = false;
            button2.Visible = false;
            if (button5.Visible || button4.Visible) { button3_Click(sender, e); }
            maskedTextBox3.Select();
        }
        private void maskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            Reset();
            label6.Visible = false;
            button2.Visible = false;
            if (button5.Visible || button4.Visible) { button3_Click(sender, e); }
            maskedTextBox4.Select();
        }
        private void maskedTextBox4_TextChanged(object sender, EventArgs e)
        {
            Reset();
            label6.Visible = false;
            button2.Visible = false;
            if (button5.Visible || button4.Visible) { button3_Click(sender, e); }
            maskedTextBox5.Select();
        }
        private void maskedTextBox5_TextChanged(object sender, EventArgs e)
        {
            Reset();
            label6.Visible = false;
            button2.Visible = false;
            if (button5.Visible || button4.Visible) { button3_Click(sender, e); }
            maskedTextBox6.Select();
        }
        private void maskedTextBox6_TextChanged(object sender, EventArgs e)
        {
            Reset();
            label6.Visible = false;
            button2.Visible = false;
            if (button5.Visible || button4.Visible) { button3_Click(sender, e); }
        }
        private void checkBox1_CheckedStateChanged(object sender, EventArgs e)
        {
            Reset();
            label6.Visible = false;
            button2.Visible = false;
            if (button5.Visible || button4.Visible) { button3_Click(sender, e); }
        }
        private void checkBox2_CheckedStateChanged(object sender, EventArgs e)
        {
            Reset();
            label6.Visible = false;
            button2.Visible = false;
            if (checkBox2.Checked) { textBox1.Visible = true; }
            else { textBox1.Visible = false; textBox1.Text = ""; }
            if (button5.Visible || button4.Visible) { button3_Click(sender, e); }
        }
        private void RadioBox1_CheckedChanged(object sender, EventArgs e)
        {
            Reset();
            label6.Visible = false;
            button2.Visible = false;
            if (button5.Visible || button4.Visible) { button3_Click(sender, e); }
        }
        private void RadioBox2_CheckedChanged(object sender, EventArgs e)
        {
            Reset();
            //if (radioButton2.Checked) { checkBox1.Checked = true; }
            label6.Visible = false;
            button2.Visible = false;
            if (button5.Visible || button4.Visible) { button3_Click(sender, e); }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Add();
            Popunjavanje();
        }
        private void Advanced_search(string[] Words, char[] charsR, char[] charsY, long FF)//Searches the words based on the rank, not by order :) (MOST ADVANCED ALGORITHM)
        {
            char[] charsYprobna = charsY;
            Letter[] Letters = rankedLetterArray();
            Word[] Canditates = new Word[Words.Length]; long p = 0;
            foreach (string A in Words)
            {
                charsY = charsYprobna;
                if (A.Length != 5) { continue; }
                bool pass = true;
                for (int i = 0; i < 5; i++)
                {
                    if (charsR[i] != '\0' && A[i] != charsR[i]) { pass = false; break; }
                    else if (charsR[i] == '\0' && charsY.Contains(A[i]))
                    {
                        int numIndex = Array.IndexOf(charsY, A[i]);
                        char[] probna = new char[charsY.Length - 1];
                        Array.Copy(charsY, 0, probna, 0, numIndex);
                        Array.Copy(charsY, numIndex + 1, probna, numIndex, charsY.Length - 1 - numIndex);
                        charsY = probna;
                    }
                }
                if (charsY.Length != 0) { continue; }
                if (pass == true)//Word passed as valid
                {
                    if (checkBox1.Checked && !duplicate(A, charsYprobna, charsR)) { continue; }
                    if (checkBox2.Checked && !Checkerv2(A)) { continue; }
                    Canditates[p] = new Word(A);
                    Canditates[p].rank(Letters);
                    p++;
                }
            }
            long o = Array.IndexOf(Canditates, null);
            Word[] U = new Word[o];
            Array.Copy(Canditates, 0, U, 0, o);
            Array.Sort(U, Word.wordComparator);
            try { label6.Text = "WORD FOUND: " + U[FF].NAME; }
            catch (Exception) { return; }
            label6.Visible = true;
            button2.Visible = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "a" && maskedTextBox2.Text == "d" && maskedTextBox3.Text == "m" && maskedTextBox4.Text == "i" && maskedTextBox5.Text == "n" && textBox1.Text == "admin")
            {//DEVELOPER MODE :-)
                label6.Visible = true;
                button2.Visible = true;
                label7.Visible = true;
                textBox1.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                return;
            }
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            maskedTextBox4.Text = "";
            maskedTextBox5.Text = "";
            maskedTextBox6.Text = "";
            label7.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            textBox1.Text = "";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Reset();
            label6.Visible = false;
            button2.Visible = false;
        }
        private Letter[] rankedLetterArray()//returns most common ltters sorted in an array
        {
            string[] Words = File.ReadAllLines(@"dictionary.txt");
            long[] letters = new long[26]; Letter[] Lettersv2 = new Letter[26];
            foreach (string Word in Words)
            {
                foreach (char letter in Word)
                {
                    int charID = (int)letter - 97;
                    letters[charID]++;
                }
            }
            for (int abc = 0; abc < 26; abc++)
            {
                Lettersv2[abc] = new Letter((char)(abc + 97), letters[abc]);
            }
            Array.Sort(Lettersv2, Letter.letterComparator);
            return Lettersv2;
        }
        private void button4_Click(object sender, EventArgs e)//ONLY ACTIVE IN DEVELOPER MODE
        {
            string[] Words = File.ReadAllLines(@"dictionary.txt");
            long[] letters = new long[26]; Letter[] Lettersv2 = new Letter[26];
            StreamWriter A = new StreamWriter(@"letters_rank.txt");//Removes all text before written on a file
            A.Flush();//
            A.Close();//
            using (StreamWriter izlaz = new StreamWriter(@"letters_rank.txt"))
            {
                foreach (string Word in Words)
                {
                    foreach (char letter in Word)
                    {
                        int charID = (int)letter - 97;
                        letters[charID]++;
                    }
                }
                for (int abc=0;abc<26;abc++)
                {
                    Lettersv2[abc] = new Letter((char)(abc + 97), letters[abc]);
                }
                Array.Sort(Lettersv2, Letter.letterComparator);
                for (int G = 0; G < 26; G++)
                {
                    izlaz.WriteLine(Lettersv2[G].ToString() + " (" + (G + 1) + ")");
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)//ONLY ACTIVE IN DEVELOPER MODE
        {
            string[] Words = File.ReadAllLines(@"dictionary.txt");
            Letter[] Letters = rankedLetterArray();
            using (StreamWriter izlaz = new StreamWriter(@"words_rank.txt"))
            {
                foreach (string Word in Words)
                {
                    int counter = 0;
                    for (int A = 0; A < Word.Length; A++)
                    {
                        for (int L=0;L<26;L++)
                        {
                            if (Letters[L].NAME == Word[A]) { counter += (L + 1); break; }
                        }
                    }
                    izlaz.WriteLine(Word + " (" + counter + ")");
                }
            }
        }
        private int[] word_ranks(object sender, EventArgs e)//returns back an array of numbers (ranks). The lesser, the more common it is!
        {
            string[] Words = File.ReadAllLines(@"dictionary.txt");
            int[] pomocna = new int[Words.Length];
            Letter[] Letters = rankedLetterArray();
            long i = 0;
            foreach (string Word in Words)
            {
                int counter = 0;
                for (int A = 0; A < Word.Length; A++)
                {
                    for (int L = 0; L < 26; L++)
                    {
                        if (Letters[L].NAME == Word[A]) { counter += (L + 1); break; }
                    }
                }
                pomocna[i] = counter;
                i++;
            }
            return pomocna;
        }
    }
}
