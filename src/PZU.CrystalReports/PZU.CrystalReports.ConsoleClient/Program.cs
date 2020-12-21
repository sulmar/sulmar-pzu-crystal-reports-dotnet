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
            string path = System.IO.Path.Combine( System.IO.Directory.GetCurrentDirectory(), "Reports");

            string[] files = System.IO.Directory.GetFiles(path, "*.rpt");

            foreach (string file in files)
            {
                Console.WriteLine(file);

                ReportDocument report = new ReportDocument();
                report.Load(file);

                foreach(Table table in report.Database.Tables)
                {
                    Console.WriteLine(table.Name);
                }
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
