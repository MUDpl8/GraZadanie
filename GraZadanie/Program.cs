using GraZadanie;

//Drużyna boahterów
List<Bohater> gracze = new List<Bohater>();

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
//Ustawianie imion bohaterów i wybór klas przez graczy
for (int i = 0; i < iloscGraczy; i++)
{
    Console.WriteLine($"Podaj imię bohatera nr {i + 1} (proszę nie zostawiać pustego pola): ");
    string Imie = Console.ReadLine();
    Console.WriteLine($"Proszę wybrać klasę bohatera (dostępne klasy: 1 - Łucznik, 2 - Wojownik, 3 - Mag): ");
    int KlasaWybor = Convert.ToInt16(Console.ReadLine());
    string Klasa = "";
    switch (KlasaWybor)
    {
        case 1:
            Klasa = "Łucznik";
            break;
        case 2:
            Klasa = "Wojownik";
            break;
        case 3:
            Klasa = "Mag";
            break;
        default:
            Console.WriteLine("Podano niepoprawny format wyboru, ustawiono klasę na: Łucznik");
            Klasa = "Łucznik";
            break;
    }
    Bohater Bohater = new Bohater(Imie, Klasa);
    gracze.Add(Bohater);
}


//Zmienna losująca kolej którego gracza nastepuje i lista do sprawdzania, czy konkretny gracz, już wykonał swój ruch
Random rnd = new Random();
List<int> kolejnosc = new List<int>(iloscGraczy);
//Lista kontrolna upewniająca się, że bohater który umarł nie może zostać wybrany jako cel ataku
List<int> usun = new List<int>(iloscGraczy);

//Warunek: "Dopóki przynajmniej dwóch graczy jest żywych" gra toczy się dalej

while (true)
{
    int spr = 0;
    int i = 0;
    foreach (var gracz in gracze)
    {
        if (gracz.getZycie() == 0)
        {
            spr++;
            usun.Add(i);
        }
        i++;
    }
    if (spr == iloscGraczy - 1)
    {
        break;
    }
    for (int j = 0; j < usun.Count(); j++)
    {
        gracze.RemoveAt(usun[j]);
    }
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
    //Resetowanie tur graczy
    usun.Clear();
    kolejnosc.Clear();
}

//Ogłoszenie zwycięscy
foreach (var gracz in gracze)
{
    if (gracz.getZycie() != 0)
    {
        Console.WriteLine($"Wygrywa gracz {gracz.getImie()}");
    }
}
Console.ReadLine();