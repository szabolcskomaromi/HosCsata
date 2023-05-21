// See https://aka.ms/new-console-template for more information
using HosCsata.Services;

LogService.Log("========================");
LogService.Log("");
LogService.Log("Indul a csata");

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
HosService hosService = new HosService();
var hosok = hosService.Generalas(hosokSzama);

// Kiírom a létrehozott hősöket
int hosIndex = 0;
foreach (var hos in hosok)
{
    hosIndex++;
    LogService.Log(hosIndex.ToString() + ". " + hos.Nev + " (" + hos.Eletero.ToString() + ")");
}
LogService.Log("");

// A csata körökre van lebontva
int kor = 0;
// Csata addig tart még maximum 1 hős marad életben.
while (hosok.Count > 1)
{
    kor++;
    // Biztonsági kilépés
    if (kor > 1000)
        break;

    LogService.Log(kor.ToString() + ". kör (" + hosok.Count.ToString() + " hős)");

    var csata = new CsataService();
    int tamado = 0;
    int vedekezo = 0;
    // minden körbe véletlenszerűen kiválasztásra kerül egy támadó és egy védekező
    csata.Kivalasztas(hosok, ref tamado, ref vedekezo);
    
    // Logolni kell ki támadott meg kit
    LogService.Log("Támad: " + hosok[tamado].Nev + " (" + hosok[tamado].Eletero.ToString() + ")");
    LogService.Log("Védekezik: " + hosok[vedekezo].Nev + " (" + hosok[vedekezo].Eletero.ToString() + ")");

    // Csata 
    csata.Csata(ref hosok, tamado, vedekezo);

    for (int i = 0; i < hosok.Count; i++)
    {
        // A kimaradt hősök pihennek és növekszik az élet erejük 
        if (i != tamado && i != vedekezo)
        {
            hosok[i].Pihen();
        }

        // Minden kör végén logolni kell ki támadott meg kit és hogyan változott az életerejük. 
        LogService.Log( (i + 1).ToString() + ". " + hosok[i].Nev + " (" + (hosok[i].Eletero == 0 ? "Meghalt" : hosok[i].Eletero.ToString()) + ")"); 
    }

    // Törlöm a halottakat
    hosok.RemoveAll(h => h.Eletero == 0);

    // Vége a körnek
    LogService.Log("");
}

// Vége a csatának
if (hosok.Count == 1)
    LogService.Log("Vége a csatának. Győztes: " + hosok[0].Nev + " (" + hosok[0].Eletero.ToString() + ")");
else if (hosok.Count == 0)
    LogService.Log("Vége a csatának. Mindenki meghalt.");
else
    LogService.Log("Biztonsági kilépés történt, a csata nem fejeződött be.");

LogService.Log("");
