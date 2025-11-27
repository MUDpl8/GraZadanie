using GraZadanie;

//Definiowanie bohaterów i ich imion
Lucznik Bohater1 = new Lucznik("Piotrek");
Wojownik Bohater2 = new Wojownik("Stachu");
Mag Bohater3 = new Mag("Franus");

//Lista przechowująca drużynę bohaterów


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
while (true) //Dodać warunek czy tylko jeden bohater nie jest martwy
{
    Bohater1.WybierzAtak(wybierzCel());
}
