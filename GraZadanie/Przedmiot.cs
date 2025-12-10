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
            cel.setZycie(- rnd.Next(20, 41));
        }

        private void Mana(Bohater cel)
        {
            cel.RegenerujMane(rnd.Next(30, 41));
        }

        private void Obrazenia(Bohater cel)
        {
            cel.setZycie(rnd.Next(1, 101));
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
                case "Mikstura Wzmocnienia":
                    Obrazenia(cel);
                    break;
            }
        }
    }
}
