using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoogleEngineDarian
{
    public class SearchResult
    {
        private SearchItem[] items;
        private int total_results;

        public SearchResult()
        {
            this.items = new SearchItem[500];
            this.total_results = 0;
        }
        public IEnumerable<SearchItem> Items()
        {
            return this.items;
        }

        public int Count { get { return this.items.Length; } }

        public void Add_Search(SearchItem search) { items[total_results++] = search; }

        public void Order_Results()
        {
            for (int i = 0; i < total_results; i++)
            {
                SearchItem[] temp = new SearchItem[1];

                for (int j = 0; j < total_results - 1; j++)
                {
                    if (items[j].Score < items[j + 1].Score)
                    {
                        temp[0] = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp[0];
                    }
                }
            }
        }

        public void Show_Results()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Tal vez querias decir: " + items[i].Suggestion + "\n");
                Console.WriteLine("Se encuentra en el documento: " + items[i].Title + "\n");
                Console.WriteLine("SNIPPET:");
                Console.WriteLine(items[i].Snippet);
                Console.WriteLine("SCORE:");
                Console.WriteLine(items[i].Score);
                Console.WriteLine("-----------------------");
            }
        }
    }
}
