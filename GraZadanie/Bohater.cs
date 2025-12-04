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
        public Bohater(string imie, string klasa)
        {
            this.Imie = imie;
            this.Klasa = klasa;
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

        //Interfejs Łucznika

        //Zmienna Random do losowania wyników ataku
        Random rnd = new Random();
        //Zmienna przechowująca stan ataku "Precyzyjny atak"
        bool wait = false;
        //Różne ataki
        private void Atak1(Bohater cel)//Strzał
        {
            int obrazenia = rnd.Next(6, 11);
            if (rnd.Next(1, 11) == 10)
            {
                Console.WriteLine($"Gracz {Imie} uzyskał krytyczne trafienie (DMG *2)!");
                Console.WriteLine($"Gracz {Imie} zadał {obrazenia * 2} obrażeń");
                cel.setZycie(obrazenia * 2);
            }
            else
            {
                Console.WriteLine($"Gracz {Imie} zadał {obrazenia} obrażeń");
                cel.setZycie(obrazenia);
            }
        }
        private void Atak2(Bohater cel)//Cięcie sztyletem
        {
            int obrazenia = rnd.Next(2, 9);
            if (rnd.Next(1, 11) >= 7)
            {
                Console.WriteLine($"Gracz {Imie} uzyskał krytyczne trafienie (DMG *2)!");
                Console.WriteLine($"Gracz {Imie} zadał {obrazenia * 2} obrażeń");
                cel.setZycie(obrazenia * 2);
            }
            else
            {
                Console.WriteLine($"Gracz {Imie} zadał {obrazenia} obrażeń");
                cel.setZycie(obrazenia);
            }
        }
        private void Atak3(Bohater cel)//Precyzyjny strzał
        {
            if (wait == false)
            {
                Console.WriteLine($"Gracz {Imie} przygotowuje się do precyzyjnego ataku (uzyska grwarantowane krytyczne trafienie)");
                wait = true;
            }
            else if (wait == true)
            {
                int obrazenia = rnd.Next(20, 31);
                Console.WriteLine($"Gracz {Imie} uzyskał krytyczne trafienie (DMG *2)!");
                Console.WriteLine($"Gracz {Imie} zadał {obrazenia * 2} obrażeń");
                cel.setZycie(obrazenia * 2);
                wait = false;
            }
        }
        //Interfejs do wyboru ataków
        private void WybierzAtakLucznik(Bohater cel)
        {
            Console.WriteLine("Proszę wybrać atak do użycia: (1 - Strzał; 2 - Cięcie sztyletam; 3 - Precyzyjny strzał)");
            int wybor = Convert.ToInt16(Console.ReadLine());
            switch (wybor)
            {
                case 1:
                    Atak1(cel);
                    break;
                case 2:
                    Atak2(cel);
                    break;
                case 3:
                    Atak3(cel);
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór ataku, spróbuj ponownie");
                    WybierzAtakLucznik(cel);
                    break;
            }

        }

    }
}
