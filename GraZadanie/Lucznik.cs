using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;

namespace GraZadanie
{
    internal class Lucznik:Bohater
    {
        private string Imie;
        private string Klasa = "Łucznik";
        public Lucznik(string imie)
        {
            this.Imie = imie;  
        }
        //Zmienna Random do losowania wyników ataku
        Random rnd = new Random();
        //Zmienna przechowująca stan ataku "Precyzyjny atak"
        bool wait = false;
        //Różne ataki
        public void Atak1(Bohater cel)//Strzał
        {
            int obrazenia = rnd.Next(6, 11);
            if (rnd.Next(1, 11) == 10)
            {
                Console.WriteLine($"Gracz {Imie} uzyskał krytyczne trafienie (DMG *2)!");
                cel.setZycie(obrazenia * 2);
                Console.WriteLine($"Gracz {Imie} zadał {obrazenia * 2} obrażeń {cel}");
            }
            else
            {
                cel.setZycie(obrazenia);
                Console.WriteLine($"Gracz {Imie} zadał {obrazenia} obrażeń {cel}");
            }
        }
        public void Atak2(Bohater cel)//Cięcie sztyletem
        {
            int obrazenia = rnd.Next(2, 9);
            if (rnd.Next(1, 11) >= 7)
            {
                Console.WriteLine($"Gracz {Imie} uzyskał krytyczne trafienie (DMG *2)!");
                cel.setZycie(obrazenia * 2);
                Console.WriteLine($"Gracz {Imie} zadał {obrazenia * 2} obrażeń {cel}");
            }
            else
            {
                cel.setZycie(obrazenia);
                Console.WriteLine($"Gracz {Imie} zadał {obrazenia} obrażeń {cel}");
            }
        }
        public void Atak3(Bohater cel)//Precyzyjny strał
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
                cel.setZycie(obrazenia * 2);
                Console.WriteLine($"Gracz {Imie} zadał {obrazenia * 2} obrażeń {cel}");
                wait = false;
            }
        }
        //Interfejs do wyboru ataków
        public void WybierzAtak(Bohater cel)
        {
            Console.WriteLine("Proszę wybrać atak do użycia: (1 - Strzał; 2 - Cięcie sztyletam; 3 - Precyzyjny strał)");
            int wybor = Convert.ToInt32(Console.ReadLine());
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
            }

        }
    }
}
