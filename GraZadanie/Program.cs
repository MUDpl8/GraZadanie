using GraZadanie;

//Definiowanie bohaterów i ich imion
Lucznik Bohater1 = new Lucznik("Piotrek");

//Lista przechowująca drużynę bohaterów
List<Bohater> bohaterowie = new List<Bohater>()
{
     Bohater1//, Bohater2, Bohater2
};

//Funkcja pozwalająca na wybranie celu ataku
int wybierzCel()
{
    Console.WriteLine($"Wybierz cel ataku (1 - {bohaterowie[0].getImie}, 2 - {bohaterowie[1].getImie}, 3 - {bohaterowie[2].getImie}): ");
    int wybor = Convert.ToInt16(Console.ReadLine());
    if (wybor == 1 || wybor == 2 || wybor == 3)
    {
        Console.WriteLine($"Wybrano gracza {bohaterowie[wybor - 1].getImie}");
        return wybor - 1;
    }
    else
    {
        Console.WriteLine($"Wprowadzono niepoprawną informację: {wybor}");
        return -1;
    }
}

//Główna pętla
while (true) //Dodać warunek czy tylko jeden bohater nie jest martwy
{
    for(int i = 0; i < bohaterowie.Count(); i++)
    {
        Console.WriteLine($"Bohater {bohaterowie[i].getImie} rozpoczyna swoją turę");
        while (wybierzCel() == -1)
        {
            Console.WriteLine("Wybór ataku nie powiódł się, spróbuj ponownie");
        }
        Bohater1.WybierzAtak(bohaterowie[wybierzCel()]);
    }
}
