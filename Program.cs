using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BejegyzesProjekt
{
    internal class Program
    {
        static List<Bejegyzes> bList1 = new List<Bejegyzes>();
        static void listFilling()
        {
            bList1.Add(new Bejegyzes("Szun-ce", "Dying is gay."));
            bList1.Add(new Bejegyzes("Lady G", "If you're homeless, just buy a house."));


            Console.WriteLine("Kérem adjon meg egy számot! (Ennyi új bejegyzés fog készülni.)");
            int bejegyzesek = 0;
            while (!int.TryParse(Console.ReadLine(), out bejegyzesek))
            {
                Console.WriteLine("Nem megfelelő a megadott érték! (CSAK egész számot adhat meg!)");
            }
            for (int i = 0; i < bejegyzesek; i++)
            {
                Console.WriteLine("Kérem adja meg a szerző nevét, majd a bejegyzéshez kívánt tartalmat!");
                string szerzo = Console.ReadLine();
                string tartalom = Console.ReadLine();
                Bejegyzes b = new Bejegyzes(szerzo, tartalom);
                bList1.Add(b);
            }

            StreamReader sr = new StreamReader("bejegyzesek.csv");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] splitLine = line.Split(';');
                Bejegyzes b = new Bejegyzes(splitLine[0], splitLine[1]);
                bList1.Add(b);
            }
            sr.Close();
        }
        static void randomLikes()
        {
            Random r = new Random();
            for (int i = 0; i < bList1.Count * 20; i++)
            {
                bList1[r.Next(0, bList1.Count + 1)].Like();
            }
        }
        static void modifySecond()
        {
            Console.WriteLine("Adjon meg egy szöveget! (A második bejegyzés tartalma erre lesz módosítva.)");
            bList1[1].Tartalom = Console.ReadLine();
        }
        static void Main(string[] args)
        {
            listFilling();
            randomLikes();
            modifySecond();

            Console.ReadKey();
        }
    }
}
