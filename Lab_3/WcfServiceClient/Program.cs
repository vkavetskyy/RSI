using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceClient.ServiceReference1;
using WcfServiceClient.ServiceReference2;

namespace WcfServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            OpisClient klient1 = new OpisClient();
            Isrv111Client klient2 = new Isrv111Client();

            klient1.Open();

            String wynik = klient1.dajOpis("Kavetskyy", "Vladyslav", 231295);
            Console.WriteLine("{0}", wynik);

            Console.WriteLine("Naciśnij <ENTER> aby zakończyć pierwsze połączenie...");
            Console.WriteLine();
            Console.ReadLine();
            klient1.Close();

            klient2.Open();
            long wynik2 = klient2.proc111("Kavetskyy", 231295, 231295);
            Console.WriteLine("{0}", wynik2);
            Console.WriteLine("Naciśnij <ENTER> aby zakończyć drugie połączenie...");
            Console.WriteLine();
            Console.ReadLine();
            klient2.Close();
        }
    }
}
