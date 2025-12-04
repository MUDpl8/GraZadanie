using GraZadanie;

//Definiowanie bohaterów i ich imion
Bohater dummy = new Bohater("Dummy", "Bohater");
Bohater Bohater1 = new Bohater("Piotrek", "Lucznik");
Bohater Bohater2 = new Bohater("Stachu", "Wojownik");
Bohater Bohater3 = new Bohater("Franus", "Mag");

//Drużyna boahterów
List<Bohater> gracze = new List<Bohater>()
{
    Bohater1, Bohater2, Bohater3
};

//Funkcja pozwalająca na wybranie celu ataku
Bohater wybierzCel()
{
    Console.WriteLine($"Wybierz cel ataku (1 - {Bohater1.getImie()}, 2 - {Bohater2.getImie()}, 3 - {Bohater3.getImie()}, proszę nie atakuj siebie): ");
    int wybor = Convert.ToInt16(Console.ReadLine());
    switch (wybor)
    {
        case 1:
            Console.WriteLine($"Wybrano gracza {Bohater1.getImie()}");
            return Bohater1;
        case 2:
            Console.WriteLine($"Wybrano gracza {Bohater2.getImie()}");
            return Bohater2;
        case 3:
            Console.WriteLine($"Wybrano gracza {Bohater3.getImie()}");
            return Bohater3;
        default:
            Console.WriteLine($"Wprowadzono niepoprawną informację, spróbuj ponownie");
            wybierzCel();
            return dummy;
    }
}

//Główna pętla

//Pobieranie ilości graczy
Console.WriteLine("Proszę podać ilość graczy: ");
int iloscGraczy = Convert.ToInt16(Console.ReadLine());

//Zmienna losująca kolej którego gracza nastepuje i lista do sprawdzania, czy konkretny gracz, już wykonał swój ruch
Random rnd = new Random();
List<int> kolejnosc = new List<int>(iloscGraczy);

//Warunek: "Dopóki przynajmniej dwóch graczy jest żywych" gra toczy się dalej
while ( 
    (Bohater1.getZycie() > 0 && Bohater2.getZycie() > 0 && Bohater3.getZycie() > 0)
    || 
    (Bohater1.getZycie() > 0 && Bohater2.getZycie() > 0) 
    || 
    (Bohater1.getZycie() > 0 && Bohater3.getZycie() > 0)
    ||
    (Bohater2.getZycie() > 0 && Bohater3.getZycie() > 0)
    )
{
    //Sprawdzanie, czy dany gracz wykonał swój ruch
    while (kolejnosc.Count() != iloscGraczy)
    {
        int kolej = rnd.Next(1, iloscGraczy + 1);
        if (!kolejnosc.Contains(kolej))
        {
            kolejnosc.Add(kolej);
            switch (kolej)
            {
                case 1:
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine($"Turę rozpoczyna gracz: {Bohater1.getImie()}");
                    Console.WriteLine("--------------------------------------------");
                    Bohater1.WybierzAtakLucznik(wybierzCel());
                    break;
                case 2:
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine($"Turę rozpoczyna gracz: {Bohater2.getImie()}");
                    Console.WriteLine("--------------------------------------------");
                    Bohater2.wybor_ataku_wojownika(wybierzCel());
                    break;
                case 3:
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine($"Turę rozpoczyna gracz: {Bohater3.getImie()}");
                    Console.WriteLine("--------------------------------------------");
                    Bohater3.WybierzAtakMag(wybierzCel());
                    break;
            }
        }
    }
    Console.WriteLine($"Informacje graczy bo bierzącej rundzie: ");
    Bohater1.przegladInf();
    Bohater2.przegladInf();
    Bohater3.przegladInf();
    kolejnosc.Clear();
    Console.WriteLine(kolejnosc.Count());
    Console.ReadLine();
    break;
}
