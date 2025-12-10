using GraZadanie;

//Drużyna boahterów
List<Bohater> gracze = new List<Bohater>();

//Przedmioty dostępne do użycia
Przedmiot MLeczenia = new Przedmiot("Mikstura Leczenia", "Leczenia zdrowia");
Przedmiot MMany = new Przedmiot("Mikstura Many", "Odnowienie many");
Przedmiot MWzmocnienia = new Przedmiot("Mikstura Obrarzeń", "Zadanie losowych obrażeń 1 - 100");

List<Przedmiot> DostepnePrzedmioty = new List<Przedmiot>()
{
    MLeczenia, MMany, MWzmocnienia
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
            Console.WriteLine($"{i} - Zwłoki gracza {gracz.getImie()}");
            i++;
        }
        else
        {
            Console.WriteLine($"{i} - {gracz.getImie()}");
            i++;
        }
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

//Dodanie przedmiotów do plecaków bohaterów
foreach (var gracz in gracze)
{
    switch (gracz.getKlasa())
    {
        case "Łucznik":
            foreach (var przedmiot in DostepnePrzedmioty)
            {
                gracz.plecakLucznik.Add(przedmiot);
            }
            break;
        case "Wojownik":
            foreach (var przedmiot in DostepnePrzedmioty)
            {
                gracz.plecakWojownik.Add(przedmiot);
            }
            break;
        case "Mag":
            foreach (var przedmiot in DostepnePrzedmioty)
            {
                gracz.plecakMag.Add(przedmiot);
            }
            break;
    }

}

//Wyświetlanie zawartości każdego z plecaków bohaterów
Console.WriteLine("Każdemu graczowi zostały przyznane następujące przedmioty: ");
foreach (var przedmiot in DostepnePrzedmioty)
{
    Console.WriteLine($"- {przedmiot.getNazwa()} ({przedmiot.getEfekt()})");
}

//Zmienna losująca kolej którego gracza nastepuje i lista do sprawdzania, czy konkretny gracz, już wykonał swój ruch
Random rnd = new Random();
List<int> kolejnosc = new List<int>(iloscGraczy);
//Lista kontrolna upewniająca się, że bohater który umarł nie może zostać wybrany jako cel ataku
List<int> usun = new List<int>(iloscGraczy);

while (true)
{
    //Sprawdzanie czy jest tylko jeden żywy gracz
    int spr = 0;
    foreach (var gracz in gracze)
    {
        if (gracz.getZycie() == 0)
        {
            spr++;
        }
    }
    if (spr == iloscGraczy - 1)
    {
        break;
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
                    switch (gracze[kolej].WybierzAkcje())
                    {
                        case 1:
                            gracze[kolej].WybierzAtakLucznik(wybierzCel());
                            break;
                        case 2:
                            int index = gracze[kolej].WybierzPrzedmiot(gracze[kolej]);
                            gracze[kolej].plecakLucznik[index].UzyjPrzedmiot(gracze[kolej].plecakLucznik[index], wybierzCel());
                            gracze[kolej].plecakLucznik.RemoveAt(index);
                            break;
                    }
                    break;
                case "Wojownik":
                    if (gracze[kolej].getZycie() == 0)
                    {
                        break;
                    }
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine($"Turę rozpoczyna gracz: {gracze[kolej].getImie()}");
                    Console.WriteLine("--------------------------------------------");
                    switch (gracze[kolej].WybierzAkcje())
                    {
                        case 1:
                            gracze[kolej].wybor_ataku_wojownika(wybierzCel());
                            break;
                        case 2:
                            int index = gracze[kolej].WybierzPrzedmiot(gracze[kolej]);
                            gracze[kolej].plecakWojownik[index].UzyjPrzedmiot(gracze[kolej].plecakWojownik[index], wybierzCel());
                            gracze[kolej].plecakWojownik.RemoveAt(index);
                            break;
                    }
                    break;
                case "Mag":
                    if (gracze[kolej].getZycie() == 0)
                    {
                        break;
                    }
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine($"Turę rozpoczyna gracz: {gracze[kolej].getImie()}");
                    Console.WriteLine("--------------------------------------------");
                    switch (gracze[kolej].WybierzAkcje())
                    {
                        case 1:
                            gracze[kolej].WybierzAtakMag(wybierzCel());
                            break;
                        case 2:
                            int index = gracze[kolej].WybierzPrzedmiot(gracze[kolej]);
                            gracze[kolej].plecakMag[index].UzyjPrzedmiot(gracze[kolej].plecakMag[index], wybierzCel());
                            gracze[kolej].plecakMag.RemoveAt(index);
                            break;
                    }
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