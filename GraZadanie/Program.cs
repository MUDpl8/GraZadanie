using GraZadanie;

//Definiowanie bohaterów i ich imion
Bohater dummy = new Bohater("Dummy", "Bohater");
Bohater Bohater1 = new Bohater("Piotrek", "Łucznik");
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
    Console.WriteLine("Wybierz cel twojego ataku, dotępni gracze: ");
    int i = 1;
    foreach (var gracz in gracze)
    {
        if (gracz.getZycie() == 0)
        {
            continue;
        }
        Console.WriteLine($"{i} - {gracz.getImie()}");
        i++;
    }
    int wybor = Convert.ToInt16(Console.ReadLine()) - 1;
    Console.WriteLine($"Wybrano gracza {gracze[wybor].getImie()}");
    return gracze[wybor];
}

//Główna pętla

//Pobieranie ilości graczy
Console.WriteLine("Proszę podać ilość graczy: ");
int iloscGraczy = Convert.ToInt16(Console.ReadLine());

//Zmienna losująca kolej którego gracza nastepuje i lista do sprawdzania, czy konkretny gracz, już wykonał swój ruch
Random rnd = new Random();
List<int> kolejnosc = new List<int>(iloscGraczy);

//Warunek: "Dopóki przynajmniej dwóch graczy jest żywych" gra toczy się dalej

while (//gracze.All(gracz => gracz.getZycie() != 0)
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
        int kolej = rnd.Next(0, iloscGraczy);
        if (!kolejnosc.Contains(kolej))
        {
            kolejnosc.Add(kolej);
            switch (gracze[kolej].getKlasa())
            {
                case "Łucznik":
                    if (gracze[kolej].getZycie() == 0)
                    {
                        break;
                    }
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine($"Turę rozpoczyna gracz: {gracze[kolej].getImie()}");
                    Console.WriteLine("--------------------------------------------");
                    gracze[kolej].WybierzAtakLucznik(wybierzCel());
                    break;
                case "Wojownik":
                    if (gracze[kolej].getZycie() == 0)
                    {
                        break;
                    }
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine($"Turę rozpoczyna gracz: {gracze[kolej].getImie()}");
                    Console.WriteLine("--------------------------------------------");
                    gracze[kolej].wybor_ataku_wojownika(wybierzCel());
                    break;
                case "Mag":
                    if (gracze[kolej].getZycie() == 0)
                    {
                        break;
                    }
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine($"Turę rozpoczyna gracz: {gracze[kolej].getImie()}");
                    Console.WriteLine("--------------------------------------------");
                    gracze[kolej].WybierzAtakMag(wybierzCel());
                    break;
            }
        }
    }
    Console.WriteLine($"Informacje graczy bo bierzącej rundzie: ");
    foreach (var gracz in gracze)
    {
        gracz.przegladInf();
    }
    kolejnosc.Clear();
}
