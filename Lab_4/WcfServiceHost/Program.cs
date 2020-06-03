using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary;

namespace WcfServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //Krok 1: Utwórz URI dla bazowego serwisu.
            Uri baseAddress = new Uri("http://localhost:34506/Lab4");

            //Krok 2: Utwórz instancje serwisu.
            ServiceHost mojHost = new ServiceHost(typeof(KalkulatorLZ), baseAddress);

            Uri baseAddress2 = new Uri("http://localhost:34506/Lab4_2");
            ServiceHost mojHost2 = new ServiceHost(typeof(MojSerwis2), baseAddress2);

            try
            {
                //Krok 3: Dodaj endpoint.
                WSHttpBinding mojBinding = new WSHttpBinding();
                mojHost.AddServiceEndpoint(typeof(IKalkulatorLZ), mojBinding, "IKalkulatorLZ");

                mojHost2.AddServiceEndpoint(typeof(IOWSerwis), mojBinding, "IOWSerwis");

                //Krok 4: Ustaw wymiane metadanych.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                mojHost.Description.Behaviors.Add(smb);
                mojHost2.Description.Behaviors.Add(smb);

                //Krok 5: Uruchom serwis.
                mojHost.Open();
                mojHost2.Open();
                Console.WriteLine("--->Host uruchomiony.");
                Console.WriteLine("--->Naciśnij <ENTER> aby zakończyć.\n");
                Console.ReadLine(); //Czekam na zamknięcie
                mojHost.Close();
                mojHost2.Close();
                Console.WriteLine("--->Host zakończył działanie.");
            }
            catch (CommunicationException e)
            {
                Console.WriteLine("Wyjątek: {0}", e.Message);
                mojHost.Abort();
                mojHost2.Abort();
            }
        }
    }
}
