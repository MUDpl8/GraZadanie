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
        private int Zycie;
        private int Mana;

        public void setZycie(Bohater cel, int ilosc)
        {
            if (cel.Zycie - ilosc <= 0)
            {
                cel.Zycie = 0;
                Console.WriteLine($"Punkty życia gracza: {cel} spadły poniżej zera");
            }
            else
            {
                cel.Zycie -= ilosc;
            }
        }
    }
}
