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
        public new void przegladInf()
        {
            Console.WriteLine("=====================");
            Console.WriteLine($"Informacje o bohaterze: ");
            Console.WriteLine($"Nazwa: {Imie}");
            Console.WriteLine($"Klasa: {Klasa}");
            Console.WriteLine($"Zrowie: {Zycie} || Mana: {Mana}");
            Console.WriteLine("=====================");
        }

        public new string getImie()
        {
            return Imie;
        }
        public new int getZycie()
        {
            return Zycie;
        }
        public new int getMana()
        {
            return Mana;
        }
        //funckja do regenu many
        public new void RegenerujMane(int wartosc)
        {
            Mana += wartosc;
            Console.WriteLine($"Ilość many gracza {Imie} wynosi: {Mana}");
        }
        //funcka do uzycia many
        public new void UzyjMane(int uzycie)
        {
            Mana -= uzycie;
            Console.WriteLine($"Ilość many gracza {Imie} wynosi: {Mana}");
        }
        Random rnd = new Random();
        public void KradziezMany(Bohater cel)
        {
            Console.WriteLine("Słaby atak, który kradnie przeciwnikowi część many. Użyć? (T/N)");
            string wybor = Console.ReadLine();
            if (wybor == "T" || wybor == "t")
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
                    podwojenie = false;
                }
                else
                {
                    int obrazenia = rnd.Next(5, 16);
                    int kradziez = rnd.Next(15, 26);
                    Console.WriteLine($"{Imie} zadał {obrazenia} obrażeń, i ukradł {kradziez} many");
                    cel.setZycie(obrazenia);
                    cel.UzyjMane(kradziez);
                    this.RegenerujMane(kradziez);
                    Console.WriteLine($"Mag {Imie} ma {Mana} many");
                }
            }
            else
            {
                WybierzAtakMag(cel);
            }
        }
        public void Kamehameha(Bohater cel)
        {
            Console.WriteLine("Silny atak, który kosztuje 35 many. Użyć? (T/N)");
            string wybor = Console.ReadLine();
            if (wybor == "T" || wybor == "t")
            {
                if (Mana >= 35)
                {
                    if(podwojenie == true)
                    {
                        int obrazenia = rnd.Next(15, 31)*2;
                        Console.WriteLine($"Błogosławieńśtwo! {Imie} zadał {obrazenia} obrażeń");
                        cel.setZycie(obrazenia);
                        this.UzyjMane(35);
                        podwojenie = false;
                    }
                    else
                    {
                        int obrazenia = rnd.Next(15, 31);
                        Console.WriteLine($"{Imie} zadał {obrazenia} obrażeń");
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
                WybierzAtakMag(cel);
            }
        }
        public void Błogosławieńśtwo(Bohater cel)
        {
            Console.WriteLine($"Następny atak {Imie} zada podwójne obrażenia! Koszt: 15 many. Użyć? (T/N)");
            string wybor = Console.ReadLine();
            if (wybor == "T" || wybor == "t")
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
                WybierzAtakMag(cel);
            }
        }
        public void KuleOgnia(Bohater cel)
        {
            Console.WriteLine($"Trzy ataki pod rząd z małą ilością obrażeń, każdy z szansą na kryta. 25 many. Użyć?");
            string wybor = Console.ReadLine();
            if (wybor == "T" || wybor == "t")
            {
                if (Mana >= 25)
                {
                    //TUTAJ ZROBIC 3 RAZY NA NEXT LEKCJI ALBO KTOS ZA MNIE BO W PIATEK MNIE NIE BEDZIE, MACIE KOD PRAKTYCZNIE GOOTWY JUZ
                    if (podwojenie == true)
                    {   
                        podwojenie = false;
                        int obrazenia = rnd.Next(2, 10)*2;
                        if (rnd.Next(1, 5) == 1)
                        {
                             obrazenia *= 2;
                             this.UzyjMane(25);
                            cel.setZycie(obrazenia);
                            Console.WriteLine($"Błogosławieństwo oraz kryt! {Imie} zadał {obrazenia} obrażenia");
                        }
                        else
                        {
                            this.UzyjMane(25);
                            Console.WriteLine($"Błogosławieństwo oraz kryt! {Imie} zadał {obrazenia} obrażenia");
                        }
                    }
                }
            }
        }
        public void WybierzAtakMag(Bohater cel)
        {
            Console.WriteLine("Proszę wybrać atak do użycia: (1 - KradziezMany; 2 - Kamehameha; 3 - Błogosławieństwo)");
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
