using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraZadanie
{
    internal class Mag : Bohater
    {
        private string Imie;
        private string Klasa = "Mag";
        private int Zycie = 70;
        private int Mana = 100;
        private bool podwojenie = false;
        public Mag(string imie)
        {
            this.Imie = imie;
        }
        //Przegląd informacji o bohaterze
        public void przegladInf()
        {
            Console.WriteLine("=====================");
            Console.WriteLine($"Informacje o bohaterze: ");
            Console.WriteLine($"Nazwa: {Imie}");
            Console.WriteLine($"Klasa: {Klasa}");
            Console.WriteLine($"Zrowie: {Zycie} || Mana: {Mana}");
            Console.WriteLine("=====================");
        }
        public int getZycie()
        {
            return Zycie;
        }
        public int getMana()
        {
            return Mana;
        }
        Random rnd = new Random();
        public void KradziezMany(Bohater cel)
        {
            Console.WriteLine("Słaby atak, który kradnie przeciwnikowi część many. Użyć? (T/N)");
            string wybor = Console.ReadLine();
            if (wybor == "T")
            {
                if(podwojenie == true)
                {
                    int obrazenia = rnd.Next(5, 16)*2;
                    int kradziez = rnd.Next(10, 21); 
                    Console.WriteLine($"Błogosławieństwo! {Imie} zadał {obrazenia} obrażeń, i ukradł {kradziez} many");
                    cel.setZycie(obrazenia);
                    cel.UzyjMane(kradziez);
                    this.RegenerujMane(kradziez);
                    Console.WriteLine($"Mag {Imie} ma {Mana} many");
                }
                else
                {
                    int obrazenia = rnd.Next(5, 16);
                    int kradziez = rnd.Next(10, 21);
                    Console.WriteLine($"Błogosławieństwo! {Imie} zadał {obrazenia} obrażeń, i ukradł {kradziez} many");
                    cel.setZycie(obrazenia);
                    cel.UzyjMane(kradziez);
                    this.RegenerujMane(kradziez);
                    Console.WriteLine($"Mag {Imie} ma {Mana} many");
                }
            }
            else
            {
                WybierzAtak(cel);
            }
        }
        public void Kamehameha(Bohater cel)
        {
            Console.WriteLine("Silny atak, który kosztuje 35 many. Użyć? (T/N)");
            string wybor = Console.ReadLine();
            if (wybor == "T")
            {
                if (Mana >= 35)
                {
                    if(podwojenie == true)
                    {
                        int obrazenia = rnd.Next(15, 31)*2;
                        Console.WriteLine($"Błogosławieńśtwo! {Imie} zadał {obrazenia} obrażeń");
                        cel.setZycie(obrazenia);
                        this.UzyjMane(35);
                    }
                    else
                    {
                        int obrazenia = rnd.Next(15, 31);
                        Console.WriteLine($"Błogosławieńśtwo! {Imie} zadał {obrazenia} obrażeń");
                        cel.setZycie(obrazenia);
                        this.UzyjMane(35);
                    }
                    
                }
                else
                {
                    Console.WriteLine("Za mało many! Tracisz turę.");
                }

            }
            else
            {
                WybierzAtak(cel);
            }
        }
        public void Błogosławieńśtwo(Bohater cel)
        {
            Console.WriteLine($"Następny atak {Imie} zada podwójne obrażenia! Koszt: 15 many. Użyć? (T/N)");
            string wybor = Console.ReadLine();
            if (wybor == "T")
            {
                if (Mana >= 15)
                {
                    podwojenie = true;
                    this.UzyjMane(15);
                    Console.WriteLine($"Błogosławieństwo przyznane bohaterowi {Imie}");
                }
                else
                {
                    Console.WriteLine("Za mało many! Tracisz turę.");
                }
            }
            else
            {
                WybierzAtak(cel);
            }
        }
        public void WybierzAtak(Bohater cel)
        {
            Console.WriteLine("Proszę wybrać atak do użycia: (1 - Strzał; 2 - Cięcie sztyletam; 3 - Precyzyjny strzał)");
            int wybor = Convert.ToInt32(Console.ReadLine());
            switch (wybor)
            {
                case 1:
                    KradziezMany(cel);
                    break;
                case 2:
                    Kamehameha(cel);
                    break;
                case 3:
                    Błogosławieńśtwo(cel);
                    break;
            }

        }
    }
}
