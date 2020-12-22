using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZU.CrystalReports.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // wejście
            // reportcataloger.exe {katalog_z_raportami} {katalog_wyjściowy} 
            // Przykład:
            // reportcataloger.exe c:\temp\reports c:\temp\catalog.csv

            // string path = System.IO.Path.Combine( System.IO.Directory.GetCurrentDirectory(), "Reports");

            string path = @"C:\temp\PZU\Reports";

            string[] files = System.IO.Directory.GetFiles(path, "*.rpt");

            foreach (string file in files)
            {
                Console.WriteLine(file);

                ReportDocument report = new ReportDocument();
                report.Load(file);

                foreach (Table table in report.Database.Tables)
                {
                    Console.WriteLine(table.Name);
                }

                var parameters = report.ParameterFields;

                foreach (CrystalDecisions.Shared.ParameterField parameter in parameters)
                {
                    Console.WriteLine($"{parameter.Name} {parameter.ParameterValueType}");
                }

                var formulaFields = report.DataDefinition.FormulaFields;

                foreach (FormulaFieldDefinition formulaField in formulaFields)
                {
                    Console.WriteLine($"{formulaField.Name} {formulaField.Text}");
                }

                string formulaName = "Version";

                try
                {
                    var formula = report.DataDefinition.FormulaFields[formulaName];
                    formula.Text = "\"SABA 6.0\"";
                    report.SaveAs(file);
                }
                catch(System.Runtime.InteropServices.COMException e)
                {

                }

                // wyjście - plik CSV

                // | nazwa raportu | nazwa tabeli |  typ

                // | nazwa raportu | nazwa widoku |

                // | nazwa raportu | nazwa procedury | 

                // | nazwa raportu | nazwa sql |


            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
