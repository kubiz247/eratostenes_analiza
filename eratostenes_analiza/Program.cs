using System;
using System.Collections.Generic;

namespace SitoEratostenesaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj liczbę n:");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                var wynik = SitoEratostenesa(n);
                Console.WriteLine("Liczby pierwsze:");
                Console.WriteLine(string.Join(", ", wynik));
            }
            else
            {
                Console.WriteLine("Nieprawidłowa liczba!");
            }
        }

        static List<int> SitoEratostenesa(int n)
        {
            bool[] liczby = new bool[n + 1];
            for (int i = 2; i <= n; i++)
                liczby[i] = true;

            for (int i = 2; i * i <= n; i++)
            {
                if (liczby[i])
                {
                    for (int j = i * i; j <= n; j += i)
                        liczby[j] = false;
                }
            }

            List<int> pierwsze = new List<int>();
            for (int i = 2; i <= n; i++)
            {
                if (liczby[i])
                    pierwsze.Add(i);
            }

            return pierwsze;
        }
    }
}
