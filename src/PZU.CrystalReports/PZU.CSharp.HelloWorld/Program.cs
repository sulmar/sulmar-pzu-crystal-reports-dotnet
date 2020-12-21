using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZU.CSharp.HelloWorld
{
    class Person     // typ referencyjny
    {
        public string firstName;
        public string lastName;
        public decimal amount;

        public decimal Calculate()
        {
            return amount * 1.23m;
        }
        
    }

    struct Address
    {
        public string city;
     
    }

   

    // Klasa
    class Program   
    {
        // Metoda
        static void Main(string[] args)    // nazwy klas, metod - notacja Pascalowa (Pascal-case)
        {
            // HelloWorldTest();

            int x = 5;
            int y = 20;

            int result = Add(x, y);

            x = 10;

            Console.WriteLine(result);

            Person employee1 = new Person();
            employee1.firstName = "Marcin";
            employee1.lastName = "Sulecki";
            employee1.amount = 100;

            Person employee2 = new Person();
            employee2.firstName = "Gosia";
            employee2.amount = 100;

            Add(employee1);

            Console.ReadKey();
        }

        // Metoda (funkcja)
        static int Add(int x, int y)    // przekazanie poprzez wartość
        {
            int result = x + y;

            x = x + 10;

            return result;
        }

        static int AddRef(ref int x, ref int y)    // przekazanie poprzez referencję
        {
            int result = x + y;

            x = x + 10;

            return result;
        }

        static void Add(Person person)   // przekazywanie poprzez referencję
        {
            person.amount = person.amount + 10;
        }

        static void Add(ref Address address) // struktura - przekazywanie poprzez referencję
        {
            address.city = "Warszawa";
        }

        private static void HelloWorldTest()
        {
            Console.WriteLine("Hello .NET");

            Console.Write("Podaj imię: ");

            // nazwy zmiennych - notacja wielbłądzia (camel-case)
            string firstName = Console.ReadLine();

            Console.Write("Podaj nazwisko: ");
            string lastName = Console.ReadLine();

            Console.Write("Podaj wartość ubezpieczenia");

            decimal amount = decimal.Parse(Console.ReadLine());

            byte z = 255; // Byte
            short a = 10; // Int16
            int age = 10; // Int32
            long distance = 1000; // Int64

            // Console.WriteLine("Witaj " + firstName + " " + lastName);  // konkatenacja ciągów tekstowych

            // string message = string.Format("Witaj {0} {1}", firstName, lastName);

            string message = $"Witaj {firstName} {lastName} {amount}";       // interpolacja

            Console.WriteLine(message);
        }
    }
}
