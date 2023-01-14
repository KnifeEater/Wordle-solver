using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Letter
    {
        private char name;
        private long popularity;
        public Letter()
        {
            name = '\0';
            popularity = 0;
        }
        public Letter(char NAME,long POPULARITY)
        {
            this.name = NAME;
            this.popularity = POPULARITY;
        }
        public char NAME
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
        public static int operator +(Letter left, Letter right)
        {
            return (int)left.name + (int)right.name;
        }
        public static int operator +(Letter left, int right)
        {
            return (int)left.name + right;
        }
        public static int letterComparator(Letter A, Letter B)
        {
            if (A.popularity > B.popularity) { return -1; }
            else if (A.popularity < B.popularity) { return 1; }
            else { return 0; }
        }
    }
}
