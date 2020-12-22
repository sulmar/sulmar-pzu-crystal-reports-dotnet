using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZU.CrystalReports.ReportCataloguer
{

    // reportcataloger.exe {katalog-raportow} {plik-wyjsciowy.csv}

    // reportcataloger.exe c:\temp\reports c:\temp\catalog.csv

    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length>=2)
            {
                string path = args[0];
                string filename = args[1];

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                CrystalReportsService crystalReportsService = new CrystalReportsService();
                crystalReportsService.CreateInventory(path, filename);

            }
            else
            {
                DisplayHelp();
            }
        }

        static void DisplayHelp()
        {
            Console.WriteLine("użycie: reportcataloger.exe katalograportow plikwyjsciowy.csv");
        }
    }
}
