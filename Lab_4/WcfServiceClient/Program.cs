using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WcfServiceClient.ServiceReference1;
using WcfServiceClient.ServiceReference2;

namespace WcfServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            KalkulatorLZClient klient1 = new KalkulatorLZClient("WSHttpBinding_IKalkulatorLZ");
            
            LiczbaZ lz1 = new LiczbaZ();
            lz1.czescR = 1.2;
            lz1.czescU = 3.4;

            LiczbaZ lz2 = new LiczbaZ();
            lz2.czescR = 5.6;
            lz2.czescU = -7.8;

            Console.WriteLine("\nKlient1");
            Console.WriteLine("...wywołuje DodajLZ(...)");
            LiczbaZ result1 = klient1.DodajLZ(lz1, lz2);
            Console.WriteLine("DodajLZ(...) = ({0}, {1})", result1.czescR, result1.czescU);

            klient1.Close();
            Console.WriteLine("Koniec Klient1");

            //Klient 2

            OWSerwisClient klient2 = new OWSerwisClient("WSHttpBinding_IOWSerwis");

            Console.WriteLine("\nKlient2");
            Console.WriteLine("...wywołuje Funkcja1:");
            klient2.Funkcja1("Klient2");
            Thread.Sleep(10);
            Console.WriteLine("...kontynuacja po Funkcji1");
            Console.WriteLine("...wywołuje Funkcja2:");
            klient2.Funkcja2("Klient2");
            Thread.Sleep(10);
            Console.WriteLine("...kontynuacja po Funkcji2");

            klient2.Close();
            Console.WriteLine("Koniec Klient2");
            Console.ReadLine();
        }
    }
}
