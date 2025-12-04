using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;

namespace GraZadanie
{
    internal interface Lucznik
    {
        //Przegląd informacji o bohaterze
        private void przegladInf() { }

        //Funkcja pobierająca życie bohatera
        private int getZycie()
        {
            return 0;
        }
        //Pobieranie imienia bohatera
        private string getImie()
        {
            return "0";
        }
        //Różne ataki
        private void Atak1(Bohater cel)//Strzał
        {

        }
        private void Atak2(Bohater cel)//Cięcie sztyletem
        {

        }
        private void Atak3(Bohater cel)//Precyzyjny strzał
        {

        }
        //Interfejs do wyboru ataków
        private void WybierzAtakLucznik(Bohater cel)
        {

        }
    }
}
