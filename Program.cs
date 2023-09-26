using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejegyzesProjekt
{
    internal class Program
    {
        static List<Bejegyzes> bList1 = new List<Bejegyzes>();
        static List<Bejegyzes> bList2 = new List<Bejegyzes>();

        static void Main(string[] args)
        {
            Console.WriteLine("Kérem adjon meg egy számot! (Ennyi új bejegyzés fog készülni.)");
            int bejegyzesek = 0;
            while (!int.TryParse(Console.ReadLine().ToLower(), out bejegyzesek))
			{
				Console.WriteLine("Nem megfelelő a megadott érték! (CSAK egész számot adhat meg!)");
			}
            for (int i = 0; i < bejegyzesek; i++)
			{
                Console.WriteLine("Kérem adja meg a szerző nevét, majd a bejegyzéshez kívánt tartalmat!");
                string szerzo = Console.ReadLine();
                string tartalom = Console.ReadLine();
                Bejegyzes b = new Bejegyzes(szerzo,tartalom);
                bList1.Add(b);
			}

            Console.ReadKey();
        }
    }
}
