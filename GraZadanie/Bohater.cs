using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraZadanie
{
    internal class Bohater
    {
        private string Imie;
        private int Zycie = 100;
        private int Mana;

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
    }
}
