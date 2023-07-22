using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MoogleEngineDarian
{
    class Program
    {
        static void Main(string[] args)
        {
            //MEDIR EL TIEMPO Debbug
            // Stopwatch stopwatch = new Stopwatch();
            // stopwatch.Start(); debbug
            #region Variables<<<<<

            ///VARIABLES DICCIONARIO
            Dictionary<string, int> Words_pts = new Dictionary<string, int>();
            Dictionary<int, string> Words_index = new Dictionary<int, string>();

            ///VARIABLES DE CALSES
            SearchResult Posible_result = new SearchResult(); //Creamos la clase que va a contener nuestros resultados de busqueda a medida que los encontremos

            ///VARIABLES DE LOS TXT
            string path = @"C:\Users\Toshiba1\Desktop\DARY 10\Moogle Final\Moogle\+Textos+"; //Ruta
            string[] files = Directory.GetFiles(path, "*.txt");
            string[] lines = { };
            string[] words = { };
            int numdocs = files.Length, found_docs = 0, dic_index = 0; //numero de documentos, documentos en donde se encontro la palabra, indice del diccionario para iterar

            ///VARIABLES CORRECTOR
            string keyword = "";
            keyword = ValidateSearch.Validate(keyword);

            keyword = keyword.ToLower();
            string query = "";
            int max_match = 0; //Alamacenamos la similitud del query con la busqueda introducida por el usuario
            string documento_actual = "";
            string Snippet = "";
            #endregion

            #region Diccionarios<<<<<
            //Itera documento por documento y saca todas las lineas del documento actual
            foreach (string file in files)
            {
                dic_index = 0;
                documento_actual = Path.GetFileName(file); //Nombre del documento actual
                lines = File.ReadAllLines(file);
                lines = lines.Where(x => !string.IsNullOrEmpty(x)).ToArray(); //Elimina todas las lineas vacias


                //Itera linea por linea, saca los caracteres especiales y mete las palabras divididas de cada linea en un arreglo[se pueden agregar mas palabras]
                foreach (string line in lines)
                {
                    line.ToLower(); //Convierte todas las palabras a minusculas
                    words = line.Split(new string[] { " ", ",", ".", ":", ";", "!", "?", "@", "©", "del", "de", "el", "la", "is", "this" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in words)
                    {
                        //Si la palabra existe le sumo uno
                        if (Words_pts.ContainsKey(word))
                            Words_pts[word]++;
                        //Si no existe la agrego 
                        else
                        {
                            Words_pts.Add(word, 1);
                            Words_index.Add(dic_index, word); dic_index++;
                        }
                    }
                }
                #endregion

                #region Corrector<<<<<

                ///Logica del Corrector de Textos
                var result = SpellChecker.Spell_Checker(Words_index, keyword);
                query = result.Item1; //Primer elemento de la tupla 
                max_match = result.Item2; //Segundo elemento de la tupla

                //Contar Documentos donde aparece la busqueda
                if (query != null) found_docs++;
                else
                {
                    if (!Words_pts.ContainsKey("@"))  //En caso de no coincidir agregamos el caracter @ para evitar confusiones
                        Words_pts.Add("@", -1);
                    query = "@";
                }

                #endregion

                #region Snnipet<<<<<
                //Devuelve una linea en la que aparece la busqueda
                foreach (string line in lines)
                {
                    if (line.Contains(query))
                    {
                        int indexx = line.IndexOf(query); //Indice q ocupa la palabra en la oracion
                        Snippet = line.Length - indexx < 150 ? Snippet = line.Substring(indexx, line.Length - indexx) + "..." : Snippet = line.Substring(indexx, 150) + "...";
                        break;
                    }
                }
                #endregion

                #region TF-IDF<<<<<

                //Logica del TF-IDF   
                double tfidf = TFIDF.TFIDF_meth(Words_pts[query], numdocs, found_docs) + (max_match * 1000);
                //Con max_match recompenso a las palabras por su similitud con la busqueda original

                if (query.Equals("@")) tfidf = tfidf * -1;
                if (query.Equals(keyword)) tfidf += 10000;
                float tfidf_f = Convert.ToSingle(tfidf); //Casteo para convertir de double a float

                #endregion

                #region Result<<<<<

                //Mete en un arreglo las busquedas para posteriormente comparar sus resultados y devolver 3
                SearchItem temp = new SearchItem(documento_actual, query, Snippet, tfidf_f);
                Posible_result.Add_Search(temp); //guardamos la variable anterior en un arreglo del tipo SearchItem para luego mostrar los resultados finales
                Words_index.Clear(); Words_pts.Clear(); //Vaciamos los diccionarios para evitar desbordamiento de memoria

                #endregion
            }
            Posible_result.Order_Results(); //Un metodo para ordenar las busquedas segun su score 
            Posible_result.Show_Results(); //Un metodo para mostrar todos los atributos de las 3 primeras busquedas
            Console.WriteLine("Finish");
            Console.ReadLine();

            //stopwatch.Stop();///TIEMPO 
            //Console.WriteLine($"TIEMPO: {stopwatch.ElapsedMilliseconds/1000}"); debugg
        
    }
    }
}
