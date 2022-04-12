using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaZaVaje
{
    class Program
    {
        static void Main(string[] args)
        {
            BazaZaVajeEntities context = new BazaZaVajeEntities();
            //vsi dobavitelji
            var x1 = from a in context.DOBAVITELJ
                     select a;
            //var x1 = context.DOBAVITELJ.Select(e => e);
            foreach(var y in x1)
            {
                Console.WriteLine(y.D_IME + " " + y.D_KONTAKT);
            }

            Console.WriteLine("____________________________________________________");

            DateTime datum = DateTime.Parse("20.1.2004");
            var x2 = from a in context.PRODUKT
                     where a.P_DATUM < datum
                     select new { Opis = a.P_OPIS, Zaloga = a.P_ZALOGA, MinZaloga = a.P_ZALOGA, Cena = a.P_CENA };
            foreach(var y in x2)
            {
                Console.WriteLine(y.Opis + " " + y.Cena);
            }

            Console.WriteLine("____________________________________________________");

            DateTime danes = DateTime.Now;
            //TimeSpan ts = new TimeSpan(365, 0, 0, 0);
            danes = danes.AddDays(365);
            var x3 = from a in context.PRODUKT
                     select new { Opis = a.P_OPIS, Zaloga = a.P_ZALOGA, MinZaloga = a.P_ZALOGA, Cena = a.P_CENA, Zapadlost = danes };
            foreach (var y in x3)
            {
                Console.WriteLine(y.Opis + " " + y.Zapadlost);
            }

            Console.WriteLine("____________________________________________________");

            DateTime datum1 = DateTime.Parse("15.1.2004");
            var x4 = from a in context.PRODUKT
                     where a.P_CENA < 50 && a.P_DATUM > datum1
                     select new { Opis = a.P_OPIS, Zaloga = a.P_ZALOGA, MinZaloga = a.P_ZALOGA, Cena = a.P_CENA, Datum = a.P_DATUM };
            foreach (var y in x4)
            {
                Console.WriteLine(y.Cena + " " + y.Datum);
            }

            Console.WriteLine("____________________________________________________");

            var x5 = from a in context.DOBAVITELJ
                     where a.D_KONTAKT.StartsWith("Smith")
                     select a;
            foreach (var y in x5)
            {
                Console.WriteLine(y.D_KONTAKT);
            }

            Console.WriteLine("____________________________________________________");

            var x6 = from a in context.PRODUKT
                     where a.P_ZALOGA < 2 * a.P_MIN
                     select new { Zaloga = a.P_ZALOGA, MinZaloga = a.P_MIN };


            Console.WriteLine("____________________________________________________");

            var x7 = (from a in context.PRODUKT
                     select a.D_KODA).Distinct();
            foreach (var y in x7)
            {
                Console.WriteLine(y);
            }

            Console.WriteLine("____________________________________________________");

            var x8 = context.DOBAVITELJ.Where(e => !x7.Any(p => p == e.D_KODA));
            foreach(var y in x8)
            {
                Console.WriteLine(y.D_KODA);
            }

            Console.WriteLine("____________________________________________________");

            //var x9 = context.KUPEC.Sum(e => e.KUP_STANJE);
            var x9 = (from a in context.KUPEC
                      select a.KUP_STANJE).Sum();
            Console.WriteLine(x9);
            Console.ReadLine();
        }
    }
}
