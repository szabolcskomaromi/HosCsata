using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosCsata.Services
{
    public static class LogService
    {
        private static string _logUtvonal = Directory.GetCurrentDirectory();

        // Egyedi útvonal beállítás a log fájlnak
        public static void LogUtvonal(string utvonal)
        {
            if (Directory.Exists(utvonal))
            {
                _logUtvonal = utvonal;
            }
        }
       
        public static void Log(string uzenet)
        {
            // Üzenet a consol-ra
            Console.WriteLine(uzenet);

            // Üzenet  Log fájlba
            string logFajlNev = Path.Combine(_logUtvonal, "HosCsata.log");

            using (FileStream fileStream = new FileStream(logFajlNev, FileMode.Append))
            {
                using (StreamWriter logStream = new StreamWriter(fileStream))
                {
                    logStream.WriteLine(uzenet);
                }
            }
        }

        public static void Separator()
        {
            Log("============");
        }
    }
}
