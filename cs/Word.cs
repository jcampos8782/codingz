using System;

namespace hello_dotnet_core 
{
    // Contrived class for checking word properties
    class Word 
    {

        private readonly string word;

        internal Word(string word) 
        {
            this.word = word?.ToLower() ?? "";
        }

        internal bool IsPalindrome
        {
            get 
            {
                for(int i = 0; i < word.Length / 2; i++) {
                    if(!word[i].Equals(word[word.Length - 1 - i])) 
                    {
                        return false;
                    }       
                }
                return true;
            }
        }

        override public string ToString() => this.word;
    }
}