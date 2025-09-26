using System;
using System.Collections.Generic;

namespace SitoEratostenesaApp
{
    class Program
    {
        /**********************************************
        nazwa funkcji: main
        opis funkcji: pobiera od uzytkownika liczbe calkowita n, wywoluje funkcje SitoEratostenesa i wyswietla liczby pierwsze.
        parametry: string[] args
        zwracany typ i opis: void - funkcja nie zwraca wartosci
        ***********************************************/
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

        /**********************************************
        nazwa funkcji: SitoEratostenesa
        opis funkcji: znajdywanie wszystkich liczb pierwszych
        parametry: int n - to granica zakresu, w ktorej szukamy liczb pierwszych
        zwracany typ i opis: List<int> - lista liczb calkowitych zawierajaca wszystkie liczby pierwsze z danego zakresu
        ***********************************************/
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

//nie bylo sprawdzenia przy n<2
//true tylko od i=2
//j = i*2 zamiast i*i
//petla z n zamiast z pierwiastkiem
//0 i 1 nie sa liczbami pierwszymi wiec false dla liczby[1]