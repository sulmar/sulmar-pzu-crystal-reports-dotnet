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
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            Console.WriteLine($"Pobieranie plików rpt z folderu {path}...");

            string[] files = Directory.GetFiles(path, "*.rpt");

            AddHeader(filename);

            foreach (string file in files)
            {
                ProcessReport2(file, filename);
            }

            Console.WriteLine($"Generowanie pliku {filename}...");
        }

        private static void AddHeader(string filename)
        {
            File.AppendAllText(filename, $"Reportname;MainReportName;Name;Typ;SQL;{Environment.NewLine}");
        }

        private void Process(string filename, string reportname, string mainReportName, IEnumerable<CrystalDecisions.ReportAppServer.DataDefModel.Table> elements)
        {
            foreach (var element in elements)
            {
                if (element.ClassName == "CrystalReports.Table")
                {
                    Console.WriteLine($"{element.Name} {element.ClassName}");
                    File.AppendAllText(filename, $"{reportname};{mainReportName};{element.Name};{element.ClassName};{Environment.NewLine}");
                }

                else
                if (element.ClassName == "CrystalReports.CommandTable")   // SQL Command
                {
                    CrystalDecisions.ReportAppServer.DataDefModel.CommandTable command = (CrystalDecisions.ReportAppServer.DataDefModel.CommandTable)element;

                    string sql = command.CommandText.Replace(Environment.NewLine, string.Empty);

                    File.AppendAllText(filename, $"{reportname};{mainReportName};{command.Name};{command.ClassName};\"{sql}\";{Environment.NewLine}");

                }
                else
                if (element.ClassName == "CrystalReports.Procedure")
                {
                    File.AppendAllText(filename, $"{reportname};{mainReportName};\"{element.Name}\";{element.ClassName};{Environment.NewLine}");
                }
            }
        }

        private void ProcessReport2(string file, string filename)
        {
            Console.WriteLine($"Przetwarzanie raportu {file}...");

            ReportDocument report = new ReportDocument();
            report.Load(file);

            if (report.IsLoaded)
            {
                var elements = report.ReportClientDocument.DatabaseController.Database.Tables.OfType<CrystalDecisions.ReportAppServer.DataDefModel.Table>();

                string reportname = Path.GetFileNameWithoutExtension(file);

               


                Process(filename, reportname, string.Empty, elements);

                var subreportNames = report.ReportClientDocument.SubreportController.GetSubreportNames();

                foreach (string subreportName in subreportNames)
                {
                    var subreport = report.ReportClientDocument.SubreportController.GetSubreport(subreportName);

                    var subreportname = Path.GetFileNameWithoutExtension(subreport.Name);

                    Console.WriteLine(subreportname);

                    var subreportElements = subreport.DatabaseController.Database.Tables.OfType<CrystalDecisions.ReportAppServer.DataDefModel.Table>();

                    Process(filename, subreportname, reportname, subreportElements);


                }
            }
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
