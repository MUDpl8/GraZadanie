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
        //RZmienna Random do losowania wyników ataku
        Random rnd = new Random();
        //Różne ataki
        public void Atak1(Bohater cel)//Strzał
        {
            if (rnd.Next(1, 11) == 10)
            {
                Console.WriteLine($"Gracz {Imie}");
            }
        }
    }
}
