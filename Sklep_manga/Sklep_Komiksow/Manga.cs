using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//to jest test
namespace Komiksy
{
    public interface IKoszyk
    {
        void DodajDoKoszyka(Manga manga);
        void UsunZKoszyka(Manga manga);
    }
    public class Manga
    {
        public string Tytul;
        public string Autor;
        public decimal Cena;
        public Manga(string tytul, string autor, decimal cena)
        {
            Tytul = tytul;
            Autor = autor;
            Cena = cena;
        }
        public override string ToString() { return $"{Tytul} {Autor} {Cena}"; }
    }
    public class Sklep : IKoszyk
    {
        public Manga[] mangi;
        public static int maksymalnyStanMagazynowy = 100;
        public Sklep()
        {
            mangi = new Manga[maksymalnyStanMagazynowy];
            mangi[0] = new Manga("Pokemon Adventures", "Hidenori Kusaka", 39.99m); 
            mangi[1] = new Manga("Czarodziejki z Księżyca", "Naoko Takeuchi", 49.99m); 
            mangi[2] = new Manga("Muminki", "Tove Marika Jansson", 29.99m); 
            mangi[3] = new Manga("Jak zaliczyć Programowanie Obiektowe", "Ada Lovelace", 999.99m); 
            mangi[4] = new Manga("Fullmetal Alchemist", "Hiromu Arakawa", 44.99m); 
            mangi[5] = new Manga("Death Note", "Tsugumi Ohba", 24.99m);
        }
        public void KupMangi(Klient klient)
        {
            Console.WriteLine("Zakup mang został wykonany");
            Console.WriteLine("Wydajemy paragon klientowi");
            decimal suma = 0;
            for (int i = 0; i < klient.LiczbaMangWKoszyku; i++)
            {
                Console.WriteLine(klient.koszyk[i].ToString());
                suma += klient.koszyk[i].Cena;
                UsunZKoszyka(klient.koszyk[i]);
                klient.koszyk[i] = null;
            }
            klient.LiczbaMangWKoszyku = 0;
        }
        public void DodajDoKoszyka(Manga manga)
        {
            for(int i=0;i<mangi.Length; i++)
            {
                if (mangi[i] == null)
                {
                    mangi[i] = manga;
                    break;
                }
            }
        }
        public void UsunZKoszyka(Manga manga)
        {
            for (int j = 0; j < mangi.Length; j++)
            {
                if (mangi[j] != null)
                {
                    if (mangi[j].Tytul == manga.Tytul)
                    {
                        mangi[j] = null;
                        break;
                    }
                }
            }
        }
        public override string ToString()
        {
           StringBuilder sb = new StringBuilder("Dostępne Mangi w sklepie:\n", 1000);
            for (int i = 0;i < mangi.Length;i++)
            {
                if(mangi[i] != null) 
                    sb.AppendFormat("Tytul: {0}, Autor: {1}, Cena: {2}\n", mangi[i].Tytul, mangi[i].Autor, mangi[i].Cena);
            }
            return sb.ToString();
        }
    }
    public class Klient : IKoszyk
    {
        public Manga[] koszyk;
        public int LiczbaMangWKoszyku;
        static int maksymalnyStanKoszyka = 5;
        Sklep sklep;
        public Klient(Sklep sklep)
        {
            koszyk = new Manga[maksymalnyStanKoszyka];
            LiczbaMangWKoszyku = 0;
        }
        public void DodajDoKoszyka(Manga manga)
        {
            koszyk[LiczbaMangWKoszyku] = manga;
            LiczbaMangWKoszyku += 1;
        }
        public void UsunZKoszyka(Manga manga)
        {
            for(int i = LiczbaMangWKoszyku - 1; i >= 0; i--)
            {
                if (koszyk[i] == manga)
                {
                    koszyk[i] = null;
                    break;
                }
            }
        }
        public override string ToString()
        {
            if (LiczbaMangWKoszyku == 0) return string.Format("Mangi w koszyku klienta: -");
            StringBuilder sb = new StringBuilder("Mangi w koszyku klienta:\n", 1000);
            int i = 0;
            while (i<LiczbaMangWKoszyku)
            {
                sb.AppendFormat("Tytul: {0}, Autor: {1}, Cena: {2}\n", koszyk[i].Tytul, koszyk[i].Autor, koszyk[i].Cena);
                i++;
            }
            return sb.ToString();
        }
    }
}