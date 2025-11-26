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
        Random rand = new Random();
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
        public void silny_atak_wojownika(Bohater cel)
        {
            int obrazenia = rand.Next(12,17);
            if (rand.Next(1, 6) == 2)
            {
                Console.WriteLine($"{Imie} zadał {obrazenia} obrażeń");
                cel.setZycie(obrazenia);
            }
            else
            {
                Console.WriteLine($"{Imie} nie trafił");
            }
        }
    }
}
