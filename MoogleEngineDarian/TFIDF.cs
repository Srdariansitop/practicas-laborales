using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoogleEngineDarian
{
    class TFIDF
    {
        public static double TFIDF_meth(int tf, int documentos_max, int documentos_encontrados)
        {
            double idf = Math.Log((documentos_max / documentos_encontrados) + 1);
            double tfidf = idf * tf;
            return tfidf;
        }
}
}