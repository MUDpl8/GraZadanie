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
            if (klasa == "Mag")
            {
                this.Zycie = 70;
                this.Mana = 100;
            }
            else if (klasa == "Łucznik")
            {
                this.Zycie = 75;
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
        public string getKlasa()
        {
            return Klasa;
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
        //Zmienna Random do losowania wyników ataku
        private Random rnd = new Random();

        //=================================================================================================================================================

        //Interfejs Łucznika


        //Zmienna przechowująca stan ataku "Precyzyjny atak"
        private bool wait = false;
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
                Console.WriteLine($"Gracz {Imie} przygotowuje się do precyzyjnego ataku w następnej turze(uzyska grwarantowane krytyczne trafienie)");
                wait = true;
            }
            else if (wait == true)
            {
                int obrazenia = rnd.Next(20, 26);
                Console.WriteLine($"Gracz {Imie} uzyskał krytyczne trafienie (DMG *2)!");
                Console.WriteLine($"Gracz {Imie} zadał {obrazenia * 2} obrażeń");
                cel.setZycie(obrazenia * 2);
                wait = false;
            }
        }
        //Interfejs do wyboru ataków
        public void WybierzAtakLucznik(Bohater cel)
        {
            if(wait != true) 
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
            else
            {
                Console.WriteLine($"Gracz {Imie} wykonuje precyzyjny atak");
                Atak3(cel);
            }

        }

        //=================================================================================================================================================

            //Interfejs Maga
        private bool podwojenie = false;
        
        public void KradziezMany(Bohater cel)
        {
            Console.WriteLine("Słaby atak, który kradnie przeciwnikowi część many. Użyć? (T/N)");
            string wybor = Console.ReadLine();
            if (wybor == "T" || wybor == "t")
            {
                if (podwojenie == true)
                {
                    int obrazenia = rnd.Next(5, 16) * 2;
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
                    if (podwojenie == true)
                    {
                        int obrazenia = rnd.Next(15, 31) * 2;
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

        //=================================================================================================================================================

        //Interfejs Wojownika
        //Atak 1 - Zwykły atak
        public void atak_wojownika(Bohater cel)
        {
            int obrazenia = rnd.Next(7, 11);

            if (rnd.Next(1, 5) == 2)
            {
                obrazenia = obrazenia * 2;
                Console.WriteLine($"{Imie} zadał krytyka za {obrazenia} obrażeń");
            }
            else
            {
                Console.WriteLine($"{Imie} zadał {obrazenia} obrażeń");
            }
            cel.setZycie(obrazenia);
        }
        //Atak 2 - Silny atak
        public void silny_atak_wojownika(Bohater cel)
        {
            int obrazenia = rnd.Next(12, 17);
            if (rnd.Next(1, 6) == 2)
            {
                if (rnd.Next(1, 5) == 2)
                {
                    obrazenia = obrazenia * 2;
                    Console.WriteLine($"{Imie} zadał krytyka za {obrazenia} obrażeń");
                }
                else
                {
                    Console.WriteLine($"{Imie} zadał {obrazenia} obrażeń");
                }
                cel.setZycie(obrazenia);
            }
            else
            {
                Console.WriteLine($"{Imie} nie trafił");
            }
        }
        //Atak 3 - Kradzież życia
        public void kradziez_atak_wojownika(Bohater cel)
        {
            int obrazenia = rnd.Next(3, 7);
            if (rnd.Next(1, 5) == 2)
            {
                obrazenia = obrazenia * 2;
                cel.setZycie(obrazenia);
                Console.WriteLine($"{Imie} zadał krytyka za {obrazenia} obrażeń i wyleczył {obrazenia} punktów życia");
            }
            else
            {
                cel.setZycie(obrazenia);
                Console.WriteLine($"{Imie} zadał {obrazenia} obrażeń i wyleczył {obrazenia} punktów życia");
            }
            setZycie(-obrazenia);
        }
        //Atak 4 - Furia
        public void furia_atak_wojownika(Bohater cel)
        {
            int obrazenia = rnd.Next(14, 20);
            if (rnd.Next(1, 5) == 2)
            {
                obrazenia = obrazenia * 2;
                cel.setZycie(obrazenia);
                Console.WriteLine($"{Imie} zadał krytyka za {obrazenia} obrażeń i sam stracił {obrazenia} punktów życia");
            }
            else
            {
                cel.setZycie(obrazenia);
                Console.WriteLine($"{Imie} zadał {obrazenia} obrażeń i sam stracił {obrazenia} punktów życia");
            }
            setZycie(obrazenia);
        }
        //Interfejs wyboru ataku
        public void wybor_ataku_wojownika(Bohater cel)
        {
            Console.WriteLine("Wybierz atak\n 1 - Zwykły atak\n 2 - Silny atak\n 3 - Kradzież życia\n 4 - Furia");
            int wybor = Convert.ToInt16(Console.ReadLine());

            switch (wybor)
            {
                case 1:
                    atak_wojownika(cel);
                    break;
                case 2:
                    silny_atak_wojownika(cel);
                    break;
                case 3:
                    kradziez_atak_wojownika(cel);
                    break;
                case 4:
                    furia_atak_wojownika(cel);
                    break;
            }
        }
    }
}
