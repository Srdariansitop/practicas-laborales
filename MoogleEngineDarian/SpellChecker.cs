using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoogleEngineDarian
{
    class SpellChecker
    {
        public static Tuple<string, int> Spell_Checker(Dictionary<int, string> Words_index, string keyword)
        {
            int match = 0, max_match = 0, word_len = keyword.Length / 2;
            string search = "", actual_word = " ", query = keyword;

            if (!Words_index.ContainsValue(keyword))
            {
                for (int i = 0; i < Words_index.Count; i++)
                {
                    match = 0;
                    actual_word = (Words_index[i]);
                    if (actual_word.Length <= 1) continue; //Evita las letras sueltas de un solo caracter
                    if (keyword[0] == actual_word[0] || keyword[0] == actual_word[1])
                    {
                        int aux = keyword[0] == actual_word[1] ? 1 : 0;
                        int size = keyword.Length > actual_word.Length ? actual_word.Length : keyword.Length;
                        for (int j = 0; j < size && aux < size; j++)
                        {
                            if (keyword[j] == actual_word[aux])
                                match++;
                            aux++;
                        }
                        if (Math.Abs(actual_word.Length - keyword.Length) < 2) match++; //doy puntos por la similitud entre los tamaños de las palabras
                    }
                    if (match > max_match)
                    {
                        max_match = match;
                        search = actual_word;
                    }
                }
                query = search.Length > word_len ? search : null;
            }
            return Tuple.Create(query, max_match);
        }
    }
}
