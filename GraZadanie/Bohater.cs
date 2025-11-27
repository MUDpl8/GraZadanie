using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GraZadanie
{
    internal class Bohater
    {
        private string Imie;
        private string Klasa;
        private int Zycie = 100;
        private int Mana = 80;

        public void setZycie(int ilosc)
        {
            if (Zycie - ilosc <= 0)
            {
                Zycie = 0;
                Console.WriteLine($"Punkty życia gracza: {Imie} spadły poniżej zera");
            }
            else
            {
                Zycie -= ilosc;
                Console.WriteLine($"Ilość życia gracza {Imie} wynosi: {Zycie}");
            }
        }
        public void przegladInf()
        {
            Console.WriteLine("=====================");
            Console.WriteLine($"Informacje o bohaterze: ");
            Console.WriteLine($"Nazwa: {Imie}");
            Console.WriteLine($"Klasa: {Klasa}");
            Console.WriteLine($"Zrowie: {Zycie} || Mana: {Mana}");
            Console.WriteLine("=====================");
        }
        public string getImie()
        {
            return Imie;
        }
        public int getZycie()
        {
            return Zycie;
        }
        public int getMana()
        {
            return Mana; 
        }
        //funckja do regenu many
        public void RegenerujMane(int wartosc)
        {
            Mana += wartosc;
            Console.WriteLine($"Ilość many gracza {Imie} wynosi: {Mana}");
        }
        //funcka do uzycia many
        public void UzyjMane(int uzycie)
        {
            Mana -= uzycie;
            Console.WriteLine($"Ilość many gracza {Imie} wynosi: {Mana}");
        }
    }
}
