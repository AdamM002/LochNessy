using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komiksy;

namespace Zadanie2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sklep sklep = new Sklep();
            Klient klient = new Klient(sklep);
            Console.WriteLine(sklep.ToString());
            Console.WriteLine("------------------------------------");
            Console.WriteLine(klient.ToString());
            Console.WriteLine("------------------------------------");
            sklep.DodajDoKoszyka(new Manga("Dragon Ball", "Akira Toriyama", 39.99m));
            sklep.DodajDoKoszyka(new Manga("JoJo's Bizarre Adventure", "Hirohiko Araki", 49.99m)); 
            sklep.DodajDoKoszyka(new Manga("Higurashi No Naku Koro Ni", "Ryukishi07", 49.99m)); 
            sklep.DodajDoKoszyka(new Manga("Demon Slayer", "Koyoharu Gotouge", 29.99m));
            sklep.DodajDoKoszyka(new Manga("Demon Slayer", "Koyoharu Gotouge", 29.99m));
            sklep.UsunZKoszyka(new Manga("Demon Slayer", "Koyoharu Gotouge", 29.99m));
            Console.WriteLine(sklep.ToString());
            Console.WriteLine("------------------------------------");
            Console.WriteLine(klient.ToString());
            Console.WriteLine("------------------------------------");
            klient.DodajDoKoszyka(sklep.mangi[4]);
            klient.DodajDoKoszyka(sklep.mangi[1]);
            klient.DodajDoKoszyka(sklep.mangi[2]);
            klient.DodajDoKoszyka(sklep.mangi[3]);
            Console.WriteLine(sklep.ToString());
            Console.WriteLine("------------------------------------");
            Console.WriteLine(klient.ToString());
            Console.WriteLine("------------------------------------");
            sklep.KupMangi(klient);
            Console.WriteLine("------------------------------------");
            Console.WriteLine(sklep.ToString());
            Console.WriteLine("------------------------------------");
            Console.WriteLine(klient.ToString());
            Console.WriteLine("------------------------------------");
            Console.ReadKey();
        }
    }
}
