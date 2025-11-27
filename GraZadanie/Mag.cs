using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraZadanie
{
    internal class Mag:Bohater
    {
        private string Imie;
        private string Klasa = "Mag";
        private int Zycie = 70;
        private int Mana = 150;
        public Mag(string imie)
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
        public int getZycie()
        {
            return Zycie;
        }
        public int getMana()
        {
            return Mana;
        }
        Random rnd = new Random();
        public void KulaMany(Bohater cel)
        {
            Console.WriteLine("Słaby atak, który kradnie przeciwnikowi część many. Użyć? (T/N)");
            string wybor = Console.ReadLine();
            if (wybor == "T")
            {
                int obrazenia = rnd.Next(10,16);  //obrażenia 
                int kradziez = rnd.Next(10, 21);   //kradzież many

                Console.WriteLine($"{Imie} zadał {obrazenia} obrażeń, i ukradł {kradziez} many");

                //zadanie obrażeń przeciwnikowi
                cel.setZycie(obrazenia);

                //kradzież many od przeciwnika
                cel.UzyjMane(kradziez);

                //regeneracja many maga
                this.RegenerujMane(kradziez);
            }
        }

    }
}
