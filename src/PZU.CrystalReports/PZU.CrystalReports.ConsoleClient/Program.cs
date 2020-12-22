using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
                ReportDocument report = new ReportDocument();
                report.Load(file);

                SetLocation(report);
                GetTables(report);
                GetParameters(report);
                GetFormulas(report);
                ChangeFormula(report);
                report.SaveAs(file);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        private static void SetLocation(ReportDocument report)
        {
            ConnectionInfo targetConnection = new ConnectionInfo();
            targetConnection.DatabaseName = "Sakila2";

            foreach (Table table in report.Database.Tables)
            {
                ConnectionInfo connectionInfo = table.LogOnInfo.ConnectionInfo;

                table.LogOnInfo.ConnectionInfo = targetConnection;

                table.ApplyLogOnInfo(table.LogOnInfo);

                if (table.TestConnectivity())
                {
                   
                }
            }

            foreach(ReportObject reportObject in report.ReportDefinition.ReportObjects)
            {
                if (reportObject.Kind == ReportObjectKind.SubreportObject)
                {
                    SubreportObject subreportObject = (SubreportObject)reportObject;

                    ReportDocument subreport = subreportObject.OpenSubreport(subreportObject.SubreportName);

                    SetLocation(subreport);

                }
            }
        }


        private static void GetTables(ReportDocument report)
        {
            foreach (Table table in report.Database.Tables)
            {
                Console.WriteLine(table.Name);
            }
        }

        private static void ChangeFormula(ReportDocument report)
        {
            string formulaName = "Version";

            try
            {
                var formula = report.DataDefinition.FormulaFields[formulaName];
                formula.Text = "\"SABA 6.0\"";
          
            }
            catch (System.Runtime.InteropServices.COMException e)
            {

            }
        }

        private static void GetFormulas(ReportDocument report)
        {
            var formulaFields = report.DataDefinition.FormulaFields;

            foreach (FormulaFieldDefinition formulaField in formulaFields)
            {
                Console.WriteLine($"{formulaField.Name} {formulaField.Text}");
            }
        }

        private static void GetParameters(ReportDocument report)
        {
            var parameters = report.ParameterFields;

            foreach (CrystalDecisions.Shared.ParameterField parameter in parameters)
            {
                Console.WriteLine($"{parameter.Name} {parameter.ParameterValueType}");
            }
        }
    }
}
