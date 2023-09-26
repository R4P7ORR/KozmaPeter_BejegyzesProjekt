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
                bList1[r.Next(0, bList1.Count)].Like();
            }
        }
        static void modifySecond()
        {
            Console.WriteLine("Adjon meg egy szöveget! (A második bejegyzés tartalma erre lesz módosítva.)");
            bList1[1].Tartalom = Console.ReadLine();
        }
        static void mostPopular()
        {
            int maxlikes = int.MinValue;
            foreach (Bejegyzes item in bList1)
            {
                if (item.Likeok > maxlikes)
                {
                    maxlikes = item.Likeok;
                }
            }
            Console.WriteLine($"A legnépszerűbb bejegyzés {maxlikes} like-ot kapott.");
        }
        static void moreThan35()
        {
            string likeok = "Nincs olyan bejegyzés, ami 35 like-nál többet kapott.";
            foreach (var item in bList1)
            {
                if (item.Likeok > 35)
                {
                    likeok = "Van olyan bejegyzés, ami 35 like-nál többet kapott.";
                }
            }
            Console.WriteLine(likeok);
        }
        static int lessThan15()
        {
            int Counter = 0;
            foreach (Bejegyzes item in bList1)
            {
                if (item.Likeok < 15)
                {
                    Counter++;
                }
            }
            return Counter;
        }
        static void listOrder()
        {
            bList1 = bList1.OrderByDescending(x => x.Likeok).ToList();
            StreamWriter sw = new StreamWriter("bejegyzesek_rendezett.txt");
            foreach (Bejegyzes item in bList1)
			{
				Console.WriteLine(item.ToString() + "\n-------------------------------------");
                sw.WriteLine($"{item.Szerzo};{item.Likeok};{item.Letrejott};{item.Szerkesztve};{item.Tartalom}");
			}
            sw.Close();
        }
        static void Main(string[] args)
        {
            listFilling();
            randomLikes();
            modifySecond();
			
            foreach (Bejegyzes item in bList1)
            {
                Console.WriteLine(item.ToString());
                //Console.WriteLine($"Szerző: {item.Szerzo}   Létrejött: {item.Letrejott} Szerkesztve: {item.Szerkesztve}\n{item.Tartalom}");
                Console.WriteLine("------------------------------------------------------------");
            }
            mostPopular();
            Console.WriteLine("------------------------------------------------------------\n");
            moreThan35();
            Console.WriteLine("------------------------------------------------------------\n");
            Console.WriteLine($"Összesen { lessThan15() } bejegyzés van, ami 15 like-nál kevesebbet kapott.");
            Console.WriteLine("------------------------------------------------------------\n");
            listOrder();
			



            Console.ReadKey();
        }
    }
}
