using System;
using System.Collections.Generic;

namespace Sprawdzian
{
    class Oszczepnik
    {
        //FIELD I PROPERTY
        public string _Imie;
        public string Imie
        {
            get { return _Imie; }
            set
            {
                if (value == null) throw new ArgumentException("Nazwa nie moze byc null!");
                value = value.Trim().ToLower();
                value = String.Join("", value.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                value = StartWithUpper(value);

                if (value.Length < 3) throw new ArgumentException("Niepoprawna nazwa!");

                for (int i = 0; i < value.Length; i++)
                {
                    if (!Char.IsLetter(value[i])) throw new ArgumentException("Niepoprawna nazwa!");
                }
                _Imie = value;
            }
        }
        public string _Nazwisko;
        public string Nazwisko
        {
            get { return _Nazwisko; }
            set
            {
                if (value == null) throw new ArgumentException("Nazwa nie moze byc null!");
                value = value.Trim().ToLower();
                value = String.Join("", value.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                value = StartWithUpper(value);

                if (value.Length < 3) throw new ArgumentException("Niepoprawna nazwa!");

                for (int i = 0; i < value.Length; i++)
                {
                    if (!Char.IsLetter(value[i])) throw new ArgumentException("Niepoprawna nazwa!");
                }
                _Nazwisko = value;
            }
        }
        public string _Kraj;
        public string Kraj
        {
            get { return _Kraj; }
            set
            {
                //if (value == null) throw new ArgumentException("Nazwa nie moze byc null!");
                value = value.Trim().ToUpper();
                value = String.Join("", value.Split(' ', StringSplitOptions.RemoveEmptyEntries));

                if (value.Length != 3) throw new ArgumentException("niepoprawny kod kraju!");

                for (int i = 0; i < value.Length; i++)
                {
                    if (!Char.IsLetter(value[i])) throw new ArgumentException("niepoprawny kod kraju!");
                }
                _Kraj = value;
            }
        }
        public double _WynikNajlepszy = 0;
        public double WynikNajlepszy
        {
            get { return _WynikNajlepszy; }
            private set { _WynikNajlepszy = value; }
        }
        public string _WynikOstatni;
        public string WynikOstatni
        {
            get { return _WynikOstatni; }
            private set { _WynikOstatni = value; }
        }
        public double _WynikSredni = 0;
        public double WynikSredni
        {
            get { return _WynikSredni; }
            private set { _WynikSredni = value; }
        }
        public int _LiczbaWaznychProb = 0;
        public int _LiczbaProb = 0;
        public int LiczbaProb
        {
            get { return _LiczbaProb; }
            private set
            {
                if (value < 0 || value > 6) throw new ArgumentException("limit wykorzystany");
                _LiczbaProb = value;
            }
        }
        public List<string> ListaWynikow = new List<string>();

        //FUNKCJE
        public void ZarejestrujWynik(string wynik)
        {

            if (wynik.ToUpper() == "X")
            {
                LiczbaProb++;
                WynikOstatni = "X";
                ListaWynikow.Add(String.Format("X"));

            }
            else if (Double.TryParse(wynik, out double results))
            {
                if (results < 0) throw new ArgumentException("niepoprawny format");
                if (results > WynikNajlepszy) WynikNajlepszy = results;
                LiczbaProb++;
                _LiczbaWaznychProb++;
                WynikOstatni = String.Format("{0:F2}", results);
                WynikSredni = (WynikSredni * (_LiczbaWaznychProb - 1) + results) / _LiczbaWaznychProb;
                ListaWynikow.Add(String.Format("{0:F2}", WynikOstatni));
            }
            else
            {
                throw new ArgumentException("niepoprawny format");
            }
        }
        public bool ProbujZarejestrowacWynik(string wynik)
        {
            LiczbaProb++;
            if (wynik.ToUpper() == "X")
            {
                WynikOstatni = "X";
                ListaWynikow.Add(String.Format("X"));

            }
            else if (Double.TryParse(wynik, out double results))
            {
                if (results < 0) return false;
                if (results > WynikNajlepszy) WynikNajlepszy = results;
                WynikOstatni = String.Format("{0:F2}", results);
                WynikSredni = (WynikSredni * (_LiczbaWaznychProb - 1) + results) / _LiczbaWaznychProb;
                ListaWynikow.Add(String.Format("{0:F2}", WynikOstatni));
            }
            else
            {
                return false;
            }
            return true;
        }
        public string StartWithUpper(string item)
        {
            char[] items = item.ToCharArray();
            items[0] = Char.ToUpper(items[0]);
            return new string(items);
        }

        //KONSTRUKTOR
        public Oszczepnik(string imie, string nazwisko, string kraj)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Kraj = kraj;
        }

        //OVERRIDE
        public override string ToString()
        {
            string results = String.Format("{0} {1} ({2})\n", Imie, Nazwisko, Kraj);
            if (LiczbaProb == 0)
                results = String.Format("{0}wyniki: {1}\n", results, "-");
            else
            {
                string wyniki = "";
                foreach (var wynik in ListaWynikow)
                {
                    wyniki = String.Format("{0}{1}, ", wyniki, wynik);
                }
                wyniki = wyniki.Substring(0, wyniki.Length - 2);
                results = String.Format("{0}wyniki: {1}\n", results, wyniki);
            }
            results = String.Format("{0}liczba prob: {1}, wynik najlepszy: {2:F2}, wynik sredni: {3:F2}", results, LiczbaProb, WynikNajlepszy, WynikSredni);
            return results;
        }
    }
}