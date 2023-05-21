// See https://aka.ms/new-console-template for more information
using HosCsata.Models;
using HosCsata.Services;

LogService.Separator();
LogService.Log("HősCsata");

// Hősök száma paraméter ellenőrzése
if (Environment.GetCommandLineArgs().Length < 2)
{
    LogService.Log("Hiányzó paraméter: hősök száma");
    LogService.Log("Vége.");
    return;
}

int hosokSzama  = 0;
if (!int.TryParse(Environment.GetCommandLineArgs()[1], out hosokSzama))
{
    LogService.Log("A hősök számának 2 és 100 közé kell esnie.");
    LogService.Log("Vége.");
    return;
}

if (hosokSzama < 2 || hosokSzama > 100)
{
    LogService.Log("A hősök számának 2 és 100 közé kell esnie.");
    LogService.Log("Vége.");
    return;
}

LogService.Log("Hősök száma: " + hosokSzama.ToString());

// A csata elindítása előtt le kell generálni N darab véletlenszerű hőst, amit paraméterként fog megkapni.

var hosok = new List<Hos>();

for (int i = 0; i < hosokSzama; i++)
{
    string nev = string.Empty;
    HosTipus tipus = new HosTipus();

    // Hőstípua kiválasztása véletlenszerűen
    Random random = new Random();
    int randomType = random.Next(3);
    
    switch (randomType)
    {
        case 0:
            // Íjász
            tipus = HosTipus.Ijasz;
            nev = "Íjász" + (hosok.Where(h => h.Tipus == HosTipus.Ijasz).Count() + 1).ToString("000");
            break;
        case 1:
            // Kardos
            tipus = HosTipus.Kardos;
            nev = "Kardos" + (hosok.Where(h => h.Tipus == HosTipus.Kardos).Count() + 1).ToString("000");
            break;
        case 2:
            // Lovas
            tipus = HosTipus.Lovas;
            nev = "Lovas" + (hosok.Where(h => h.Tipus == HosTipus.Lovas).Count() + 1).ToString("000");
            break;
    }

    hosok.Add(new Hos(tipus, nev));
    LogService.Log((i + 1).ToString() + ": " + nev);
}