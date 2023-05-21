using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosCsata.Models
{
    public enum HosTipus
    {
        Ijasz,
        Kardos, 
        Lovas
    }
    public class Hos
    {
        public string Nev { get; set; }
        public HosTipus Tipus { get; set; }
        public int Eletero { get; set; } 

        public Hos( HosTipus tipus, string nev) 
        { 
            Tipus = tipus;
            Nev = nev;
            // Kezdeti életerők íjász: 100 lovas: 150 kardos: 120.
            switch (Tipus)
            {
                case HosTipus.Ijasz:
                    Eletero = 100;
                    break;
                case HosTipus.Kardos:
                    Eletero = 120;
                    break;
                case HosTipus.Lovas:
                    Eletero = 150;
                    break;
            }
        }
        
        public void Pihen()
        {
            //A kimaradt hősök pihennek és növekszik az élet erejük 10-el
            Eletero = Eletero + 10;

            //, viszont nem mehet a maximum fölé.
            switch (Tipus)
            {
                case HosTipus.Ijasz:
                    if (Eletero > 100)
                        Eletero = 100;
                    break;
                case HosTipus.Kardos:
                    if (Eletero > 120)
                        Eletero = 120;
                    break;
                case HosTipus.Lovas:
                    if (Eletero > 150)
                        Eletero = 150;
                    break;
            }
        }

        public void Csatazik()
        {
            // A harcban résztvevő hősök életereje a felére csökken
            Eletero = Eletero / 2;

            // ha ez kisebb mint a kezdeti életerő negyede akkor meghalnak.
            switch (Tipus)
            {
                case HosTipus.Ijasz:
                    if (Eletero < (100/4))
                        Eletero = 0;
                    break;
                case HosTipus.Kardos:
                    if (Eletero < (120/4))
                        Eletero = 0;
                    break;
                case HosTipus.Lovas:
                    if (Eletero < (150/4))
                        Eletero = 0;
                    break;
            }
        }
    }


}
