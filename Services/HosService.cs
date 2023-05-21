using HosCsata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosCsata.Services
{
    public class HosService
    {

        public List<Hos> Generalas(int hosokSzama)
        {
            List<Hos> hosok = new List<Hos>();

            for (int i = 0; i < hosokSzama; i++)
            {
                string nev = string.Empty;
                HosTipus tipus = new HosTipus();

                // Hőstípus kiválasztása véletlenszerűen
                Random random = new Random();
                int randomType = random.Next(3);

                switch (randomType)
                {
                    case 0:
                        // Íjász
                        tipus = HosTipus.Ijasz;
                        nev = "Íjász-" + (hosok.Where(h => h.Tipus == HosTipus.Ijasz).Count() + 1).ToString();
                        break;
                    case 1:
                        // Kardos
                        tipus = HosTipus.Kardos;
                        nev = "Kardos-" + (hosok.Where(h => h.Tipus == HosTipus.Kardos).Count() + 1).ToString();
                        break;
                    case 2:
                        // Lovas
                        tipus = HosTipus.Lovas;
                        nev = "Lovas-" + (hosok.Where(h => h.Tipus == HosTipus.Lovas).Count() + 1).ToString();
                        break;
                }

                hosok.Add(new Hos(tipus, nev));
            }

            return hosok;
        }
    }
}
