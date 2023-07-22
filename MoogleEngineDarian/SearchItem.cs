using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoogleEngineDarian
{
   public class SearchItem
    {
        //Constructor
        public SearchItem(string title, string suggestion, string snippet, float score)
        {
            this.Suggestion = suggestion;
            this.Title = title;
            this.Snippet = snippet;
            this.Score = score;
        }
        public void Match() { Title += 10000; }//Añadimos 10000pts si la palabra coincide con la busqueda
        public string Title { get; private set; }

        public string Snippet { get; private set; }

        public string Suggestion { get; private set; }

        public float Score { get; private set; }
    
}
}
