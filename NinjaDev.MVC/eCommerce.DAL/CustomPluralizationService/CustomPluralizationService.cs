using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Infrastructure.Pluralization;

namespace eCommerce.DAL.CustomPluralizationService
{
    public class CustomPluralizationService : IPluralizationService
    {
        public static List<string> PluralWords = new List<string>(); 
        

        public string Pluralize(string word)
        {
#if false
            if (System.Diagnostics.Debugger.IsAttached == false)
            {
                System.Diagnostics.Debugger.Launch();
            }
#endif


            if (!PluralWords.Contains(word))
            {
                if (word == "mamá")
                {
                    string newWord = "mamás";
                    PluralWords.Add(newWord);
                    return newWord;
                }

                if (word == "papá")
                {
                    string newWord = "papás";
                    PluralWords.Add(newWord);
                    return newWord;
                }
                var lettersThatGetEs = new[]{
                                 "b", "d", "f", "h", "j", "k", "l", "m", "n",
                                 "p", "q", "r", "s", "t", "v", "w", "x", "y", "á", "í", "ó", "ú)"
                               };

                if (lettersThatGetEs.Contains(word.Substring(word.Length - 1)))
                {
                    string newWord = $"{word}es";
                    PluralWords.Add(newWord);
                    return newWord;
                }
                if (word.EndsWith("c"))
                {
                    string newWord = $"{word.Remove(word.Length - 1)}ques";

                    PluralWords.Add(newWord);
                    return newWord;
                }
                if (word.EndsWith("g"))
                {
                    string newWord = $"{word.Remove(word.Length - 1)}gues";
                    PluralWords.Add(newWord);
                    return newWord;
                }

                string newBaseWord = word + "s";
                PluralWords.Add(newBaseWord);
                return newBaseWord;
            }

            return word;
        }

        public string Singularize(string word)
        {
            return word;
        }
    }
}
