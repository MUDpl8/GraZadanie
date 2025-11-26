using GraZadanie;

Lucznik Bohater1 = new Lucznik("Piotrek");
Lucznik Bohater2 = new Lucznik("Dummy");

Bohater1.przegladInf();
Bohater2.przegladInf();

Bohater1.WybierzAtak(Bohater2);
Bohater2.getZycie();