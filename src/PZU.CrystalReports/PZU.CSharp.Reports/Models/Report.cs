using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZU.CSharp.Reports.Models
{
    class Report
    {
        public string title;
        public string filename;
        public DateTime createDate;
        public string author;

        // Konstruktor - metoda przeznaczona do konstruowania obiektu wywoływana poprzez new()
        // Nazwa metody musi być taka sama jak nazwa klasy i bez żadnego parametru wyjściowego
        // - ustawianie domyślnych wartości
        // - obowiązkowe pola
        public Report(string title, string filename, string author = "nieznany")
        {
            createDate = DateTime.Now;

            this.title = title;
            this.filename = filename;
            this.author = author;
        }

        //public void Generate()
        //{
        //    Console.WriteLine($"{title} {filename} {createDate} {author}");
        //}

        public void Generate(int copies = 1, int start = 1)    // przeciążanie metod
        {
            for (int copy = start; copy <= copies; copy++)
            {
                Console.WriteLine($"#{copy} {title} {filename} {createDate} {author}");
            }
        }

        public decimal Calculate(int copies, decimal unitPrice)
        {
            decimal cost = copies * unitPrice;

            return cost;
        }

    }
}
