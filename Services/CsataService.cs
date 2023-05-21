using HosCsata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosCsata.Services
{
    public class CsataService
    {
        public void Kivalasztas(List<Hos> hosok, ref int tamado, ref int vedekezo)
        {
            // minden körbe véletlenszerűen kiválasztásra kerül egy támadó 
            Random random = new Random();
            tamado = random.Next(hosok.Count);
            // és egy védekező.
            vedekezo = random.Next(hosok.Count - 1);
            if (vedekezo == tamado )
            {
                vedekezo++;
            }
        }

        public void Csata(ref List<Hos> hosok, int tamado, int vedekezo)
        {
            switch (hosok[tamado].Tipus)
            {
                // Íjász támad 
                case HosTipus.Ijasz:
                    switch (hosok[vedekezo].Tipus)
                    {
                        case HosTipus.Lovas:
                            //lovast: 40% eséllyel a lovas meghal, 60%-ban kivédi
                            Random random = new Random();
                            int esely = random.Next(1, 100);
                            if (esely <= 40)
                            {
                                hosok[vedekezo].Eletero = 0;
                            }
                            break;
                        case HosTipus.Kardos:
                            // kardost: kardos meghal 
                            hosok[vedekezo].Eletero = 0;
                            break;
                        case HosTipus.Ijasz:
                            // íjászt: védekező meghal
                            hosok[vedekezo].Eletero = 0;
                            break;
                    }
                break;

                // Kardos támad 
                case HosTipus.Kardos:
                    switch (hosok[vedekezo].Tipus)
                    {
                        case HosTipus.Lovas:
                            //lovast: nem történik semmi
                            break;
                        case HosTipus.Kardos:
                            // kardost: védekező meghal  
                            hosok[vedekezo].Eletero = 0;
                            break;
                        case HosTipus.Ijasz:
                            // íjászt: íjász meghal
                            hosok[vedekezo].Eletero = 0;
                            break;
                    }
                    break;

                // Lovas támad 
                case HosTipus.Lovas:
                    switch (hosok[vedekezo].Tipus)
                    {
                        case HosTipus.Lovas:
                            //lovast: védekező meghal
                            hosok[vedekezo].Eletero= 0;
                            break;
                        case HosTipus.Kardos:
                            // kardost: lovas meghal  
                            hosok[tamado].Eletero = 0;
                            break;
                        case HosTipus.Ijasz:
                            // íjászt: íjász meghal
                            hosok[vedekezo].Eletero = 0;
                            break;
                    }
                    break;
            }

            //A harcban résztvevő hősök életereje a felére csökken
            if (hosok[tamado].Eletero != 0)
            {
                hosok[tamado].Csatazik();
            }

            if (hosok[vedekezo].Eletero != 0)
            {
                hosok[vedekezo].Csatazik();
            }

        }
    }
}
