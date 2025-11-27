using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraZadanie
{
    internal class Wojownik:Bohater
    {
        private string Imie;
        private string Klasa = "Wojownik";
        private int Zycie = 100;
        private int Mana = 80;
        public Wojownik(string imie)
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
        public string getImie()
        {
            return Imie;
        }
        public int getZycie()
        {
            return Zycie;
        }
        Random rand = new Random();
        //Atak 1 - Zwykły atak
        public void atak_wojownika(Bohater cel)
        {
            int obrazenia = rand.Next(7, 11);

            if (rand.Next(1, 5) == 2)
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
            int obrazenia = rand.Next(12,17);
            if (rand.Next(1, 6) == 2)
            {
                if (rand.Next(1, 5) == 2)
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
            int obrazenia = rand.Next(3, 7);
            if (rand.Next(1, 5) == 2)
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
            int obrazenia = rand.Next(14,20);
            if (rand.Next(1, 5) == 2)
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

            switch(wybor)
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
