using System;

namespace Sprawdzian
{
    class Program
    {
        static void Main()
        {
            // Test: rejestracja wyników, błędne argumenty
            Oszczepnik p = new Oszczepnik("Ewa", "Abacka", "POL");
            Console.WriteLine($"n: {p.LiczbaProb}, max: {p.WynikNajlepszy:F2}, avg: {p.WynikSredni:F2}");
            try
            {
                p.ZarejestrujWynik("-80");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine($"n: {p.LiczbaProb}, max: {p.WynikNajlepszy:F2}, avg: {p.WynikSredni:F2}");

            try
            {
                p.ZarejestrujWynik("-");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine($"n: {p.LiczbaProb}, max: {p.WynikNajlepszy:F2}, avg: {p.WynikSredni:F2}");

            try
            {
                p.ZarejestrujWynik("x");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine($"n: {p.LiczbaProb}, max: {p.WynikNajlepszy:F2}, avg: {p.WynikSredni:F2}");

            try
            {
                p.ZarejestrujWynik("90");
                p.ZarejestrujWynik("90");
                p.ZarejestrujWynik("90");
                p.ZarejestrujWynik("90");
                p.ZarejestrujWynik("90");
                p.ZarejestrujWynik("90"); // 7 rzut
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine($"n: {p.LiczbaProb}, max: {p.WynikNajlepszy:F2}, avg: {p.WynikSredni:F2}");
        }
    }
}