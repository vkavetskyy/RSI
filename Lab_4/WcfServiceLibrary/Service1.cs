using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WcfServiceLibrary
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie i pliku konfiguracji.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }

    public class KalkulatorLZ : IKalkulatorLZ
    {
        public LiczbaZ DodajLZ(LiczbaZ n1, LiczbaZ n2)
        {
            Console.WriteLine("...wywołano DodajLZ(...)");
            return new LiczbaZ(n1.czescR + n2.czescR, n1.czescU + n2.czescU);
        }
    }

    [ServiceBehavior (ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class OWSerwis : IOWSerwis
    {
        public void Funkcja1(String s1)
        {
            Console.WriteLine("...{0}: Funkcja1 - Start", s1);
            Thread.Sleep(4 * 1000); //4 Sekundy
            Console.WriteLine("...{0}: Funkcja1 - Stop", s1);
            return;
        }

        public void Funkcja2(String s2)
        {
            Console.WriteLine("...{0}: Funkcja2 - Start", s2);
            Thread.Sleep(2 * 1000); //2 Sekundy
            Console.WriteLine("...{0}: Funkcja2 - Stop", s2);
            return;
        }
    }
}
