using System;

namespace Hangman
{
    // Class to get or set id and word from MySQL
    class DbWord
    {
        private int id;
        private String word;
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public String Word
        {
            get { return this.word; }
            set { this.word = value; }
        }
    }
}
