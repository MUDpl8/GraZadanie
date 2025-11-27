using GraZadanie;

//Definiowanie bohaterów i ich imion
Lucznik Bohater1 = new Lucznik("Piotrek");
Wojownik Bohater2 = new Wojownik("Stachu");
Mag Bohater3 = new Mag("Franus");

//Drużyna boahterów
List<Bohater> gracze = new List<Lucznik, Wojownik, Mag>() //Problem z typami w liście
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
            return Bohater1;
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
        }
    }
    Console.WriteLine(kolejnosc.Count());
    Console.ReadLine();
    break;
}
