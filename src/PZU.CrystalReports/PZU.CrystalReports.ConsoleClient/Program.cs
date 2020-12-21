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

            }
        }
    }
}
