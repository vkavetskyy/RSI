using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę interfejsu „IService1” w kodzie i pliku konfiguracji.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: dodaj tutaj operacje usługi
    }

    // Użyj kontraktu danych, jak pokazano w poniższym przykładzie, aby dodać typy złożone do operacji usługi.
    // Możesz dodać pliki XSD do projektu. Po skompilowaniu projektu możesz bezpośrednio użyć zdefiniowanych w nim typów danych w przestrzeni nazw „WcfServiceLibrary.ContractType”.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]
    public class LiczbaZ
    {
        string opis = "Liczba zespolona";

        [DataMember]
        public double czescR;

        [DataMember]
        public double czescU;

        [DataMember]
        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }

        public LiczbaZ(double czesc_rz, double czesc_ur)
        {
            this.czescR = czesc_rz;
            this.czescU = czesc_ur;
        }
    }

    [ServiceContract]
    public interface IKalkulatorLZ
    {
        [OperationContract]
        LiczbaZ DodajLZ(LiczbaZ n1, LiczbaZ n2);
    }

    [ServiceContract]
    public interface IOWSerwis
    {
        [OperationContract(IsOneWay = true)]
        void Funkcja1(String s1);

        [OperationContract]
        void Funkcja2(String s2);
    }
}
