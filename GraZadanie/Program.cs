using GraZadanie;

//Drużyna boahterów
List<Bohater> gracze = new List<Bohater>();

//Przedmioty dostępne do użycia
Przedmiot MLeczenia = new Przedmiot("Mikstura Leczenia", "Leczenia zdrowia");
Przedmiot MMany = new Przedmiot("Mikstura Many", "Odnowienie many");
Przedmiot MWzmocnienia = new Przedmiot("Mikstura wzmocnienia", "Wzmocnienie następnego ataku");

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
            
            break;
        case "Mag":
            
            break;
    }

}

//Zmienna losująca kolej którego gracza nastepuje i lista do sprawdzania, czy konkretny gracz, już wykonał swój ruch
Random rnd = new Random();
List<int> kolejnosc = new List<int>(iloscGraczy);
//Lista kontrolna upewniająca się, że bohater który umarł nie może zostać wybrany jako cel ataku
List<int> usun = new List<int>(iloscGraczy);

//Warunek: "Dopóki przynajmniej dwóch graczy jest żywych" gra toczy się dalej

while (true)
{
    Console.WriteLine(gracze);
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
    Console.WriteLine(gracze);
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
                            gracze[kolej].WybierzPrzedmiot();
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