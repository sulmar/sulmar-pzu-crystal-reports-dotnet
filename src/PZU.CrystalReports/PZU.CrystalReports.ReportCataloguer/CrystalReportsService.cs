using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZU.CrystalReports.ReportCataloguer
{
    class CrystalReportsService
    {
        public void CreateInventory(string path, string filename)
        {
          

            Console.WriteLine($"Pobieranie plików rpt z folderu {path}...");

            string[] files = Directory.GetFiles(path, "*.rpt");

           

            foreach (string file in files)
            {
                ProcessReport(file, filename);
            }

            Console.WriteLine($"Generowanie pliku {filename}...");
        }

        private void ProcessReport(string file, string filename)
        {
            Console.WriteLine($"Przetwarzanie raportu {file}...");

            ReportDocument report = new ReportDocument();
            report.Load(file);

            if (report.IsLoaded)
            {
                foreach(Table table in report.Database.Tables)
                {
                    Console.WriteLine($"{file},{table.Name},tabela");

                    

                    File.AppendAllText(filename, $"{file};{table.Name};tabela{Environment.NewLine}");

                    foreach(FieldDefinition field in table.Fields)
                    {
                        if (field.UseCount>0)
                        {
                            Console.WriteLine($"{field.Name} {field.Kind} {field.ValueType}");
                        }
                       
                    }
                }
            }
        }
    }
}
