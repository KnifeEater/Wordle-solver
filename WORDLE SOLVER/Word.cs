using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Word
    {
        private string name;
        private long popularity;
        public Word()
        {
            name = "";
            popularity = 0;
        }
        public Word(string NAME)
        {
            this.name = NAME;
            popularity = 0;
        }
        public string NAME
        {
            get { return name; }
            set { name = value; }
        }
        public long POPULARITY
        {
            get { return popularity; }
            set { popularity = value; }
        }
        public override string ToString()
        {
            return name.ToString().ToUpper() + ": " + popularity;
        }
        public static long operator +(Word left, Word right)
        {
            return left.popularity + right.popularity;
        }
        public static long operator +(Word left, long right)
        {
            return left.popularity + right;
        }
        public static int wordComparator(Word A, Word B)//što je manji, to je bolji, odnosno dobija manji broj
        {
            if (A.popularity > B.popularity) { return 1; }
            else if (A.popularity < B.popularity) { return -1; }
            else { return 0; }
        }
        public long rank(Letter[] Letters)
        {
            if (popularity != 0) { return popularity; }
            int counter = 0;
            for (int A = 0; A < name.Length; A++)
            {
                for (int L = 0; L < 26; L++)
                {
                    if (Letters[L].NAME == name[A]) { counter += (L + 1); break; }
                }
            }
            popularity = counter;
            return counter;
        }
    }
}
