using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace szeptemberiDolgozat
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] sorsoltszamok = new int[5];

            int futasido = 0;
            int szamlalo = 0;
            bool duplikalt = false;

            Console.Write("Add meg az 0. szánot: ");
            int szam = Convert.ToInt32(Console.ReadLine());

            while (futasido < 4)
            {
                duplikalt = false;
                for (int i = 0; i < sorsoltszamok.Length; i++)
                {
                    if (sorsoltszamok[i] == szam || szam > 90)

                    {
                        duplikalt = true;
                    }
                }
                if (!duplikalt)
                {
                    Console.Write("Add meg az {0}. számot: ", szamlalo + 1);
                    sorsoltszamok[szamlalo++] = szam;
                    szam = Convert.ToInt32(Console.ReadLine());
                    futasido++;
                }
                else
                {
                    Console.Write("Duplikált elemet észlelve! Adja meg újra: ");
                    szam = Convert.ToInt32(Console.ReadLine());
                }
            }
            sorsoltszamok[szamlalo] = szam;

            Console.WriteLine("\nMegadott számok:");
            for (int i = 0; i < sorsoltszamok.Length; i++)
            {
                Console.Write(sorsoltszamok[i]);
                if (i + 1 < sorsoltszamok.Length)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine(); // Üres sor

            int nulla = 0;
            int egytalalat = 0;
            int kettotalalat = 0;
            int haromtalalat = 0;
            int negytalalat = 0;
            int ottalalat = 0;

            int[] lottoszamok = new int[5];

            string fajlnev = @"C:\Users\2019375\source\repos\szeptemberiDolgozat\szeptemberiDolgozat\otos.csv";
            using (StreamReader sr = new StreamReader(fajlnev))
            {
                while (!sr.EndOfStream)
                {
                    int talatokszama = 0;
                    string jelenlegisor = sr.ReadLine();
                    string[] jelenlegierteke = jelenlegisor.Split(';');
                    int index = 11;

                    for (int i = 0; i < lottoszamok.Length; i++)
                    {
                        lottoszamok[i] = Convert.ToInt32(jelenlegierteke[index++]);
                    }

                    for (int i = 0; i < sorsoltszamok.Length; i++)
                    {
                        for (int j = 0; j < lottoszamok.Length; j++)
                        {
                            if (sorsoltszamok[i] == lottoszamok[j])
                            {
                                talatokszama++;
                            }
                        }
                    }

                    switch (talatokszama)
                    {
                        case 1:
                            egytalalat++;
                            break;
                        case 2:
                            kettotalalat++;
                            break;
                        case 3:
                            haromtalalat++;
                            break;
                        case 4:
                            negytalalat++;
                            break;
                        case 5:
                            ottalalat++;
                            break;
                        default:
                            nulla++;
                            break;
                    }
                }
                sr.Close();
            }
            
            Console.WriteLine("\n0 találatok száma: " + nulla);
            Console.WriteLine("1 találatok száma: " + egytalalat);
            Console.WriteLine("2 találatok száma: " + kettotalalat);
            Console.WriteLine("3 találatok száma: " + haromtalalat);
            Console.WriteLine("4 találatok száma: " + negytalalat);
            Console.WriteLine("5 találatok száma: " + ottalalat);

            Console.WriteLine("\nA program vége!");
            Console.ReadKey();
        }
    }
}

