using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraZadanie
{
    internal class Przedmiot
    {
        private string Nazwa;
        private string Efekt;

        public Przedmiot(string nazwa, string efekt)
        {
            Nazwa = nazwa;
            Efekt = efekt;
        }
        public string getEfekt()
        {
            return Efekt;
        }

        public string getNazwa()
        {
            return Nazwa;
        }

        private Random rnd = new Random();

        private void Zycie(Bohater cel)
        {
            int ilosc = -rnd.Next(20, 41);
            Console.WriteLine($"Gracz {cel} zregenerował {ilosc} życia");
            cel.setZycie(ilosc);
        }

        private void Mana(Bohater cel)
        {
            int ilosc = rnd.Next(30, 41);
            Console.WriteLine($"Gracz {cel} zregenerował {ilosc} many");
            cel.RegenerujMane(ilosc);
        }

        private void Obrazenia(Bohater cel)
        {
            int ilosc = rnd.Next(1, 101);
            Console.WriteLine($"Zadano {ilosc} obrarzeń graczowi {cel}");
            cel.setZycie(ilosc);
        }

        public void UzyjPrzedmiot(Przedmiot przedmiot, Bohater cel)
        {
            switch (przedmiot.getNazwa())
            {
                case "Mikstura Leczenia":
                    Zycie(cel);
                    break;
                case "Mikstura Many":
                    Mana(cel);
                    break;
                case "Mikstura Obrarzeń":
                    Obrazenia(cel);
                    break;
            }
        }
    }
}
