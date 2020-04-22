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
            Uri baseAddress = new Uri("http://localhost:34506/Kavetskyy");

            //Krok 2: Utwórz instancje serwisu.
            ServiceHost mojHost = new ServiceHost(typeof(Us111), baseAddress);

            try
            {
                //Krok 3: Dodaj endpoint.
                WSHttpBinding mojBinding = new WSHttpBinding();
                mojHost.AddServiceEndpoint(typeof(Isrv111), mojBinding, "Us111");

                //Krok 4: Ustaw wymiane metadanych.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                mojHost.Description.Behaviors.Add(smb);

                //Krok 5: Uruchom serwis.
                mojHost.Open();
                Console.WriteLine("Serwis uruchomiony.");
                Console.WriteLine("Naciśnij <ENTER> aby zakończyć...");
                Console.WriteLine();
                Console.ReadLine();
                mojHost.Close();
            }
            catch (CommunicationException e)
            {
                Console.WriteLine("Wyjątek: {0}", e.Message);
                mojHost.Abort();
            }
        }
    }
}
