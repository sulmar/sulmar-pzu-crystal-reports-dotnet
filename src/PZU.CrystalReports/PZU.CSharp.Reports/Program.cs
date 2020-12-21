using PZU.CSharp.Reports.Models;
using System;
using System.Collections.Generic;

namespace PZU.CSharp.Reports
{
    class Program
    {
        static void Main(string[] args)
        {
            // ReportTest();

            // ArrayTest();

            // Lista
            List<int> numbers = new List<int>();

            numbers.Add(20);
            numbers.Add(30);
            numbers.Add(10);

            //for(int i= 0; i < numbers.Count; i++)
            //{
            //    Console.WriteLine(numbers[i]);
            //}

            foreach(int number in numbers)
            {
                Console.WriteLine(number);
            }


            List<Report> reports = new List<Report>();


            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }

        // Struktura tablicowa (stała ilość elementów)
        private static void ArrayTest()
        {
            int?[] numbers = new int?[10];
            numbers[0] = 20;
            numbers[1] = 30;
            numbers[2] = 10;

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }

        private static void ReportTest()
        {
            Report report1 = new Report("Raport sprzedaży", "raport1.rpt");      // utworzenie instacji obiektu klasy Report

            Console.Write("Podaj ilość kopii: ");
            int copies = int.Parse(Console.ReadLine());

            report1.Generate(copies, 2);

            report1.Generate();

            decimal cost = report1.Calculate(copies, 0.99m);

            Console.WriteLine($"Koszt wydruku {cost}");
        }
    }
}
