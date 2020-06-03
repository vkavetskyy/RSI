using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;

namespace MojWebSerwis
{
    [ServiceContract]
    public interface IRestService1
    {
        //XML
        [OperationContract]
        [WebGet(UriTemplate = "/Car")]
        List<Car> getAll();

        [OperationContract]
        [WebGet(UriTemplate = "/Car/{id}", ResponseFormat = WebMessageFormat.Xml)]
        Car getById(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Car", Method = "POST", RequestFormat = WebMessageFormat.Xml)]
        string add(Car car);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Car/{id}", Method = "DELETE")]
        string delete(string id);

        //JSON
        [OperationContract]
        [WebGet(UriTemplate = "/json/Car", ResponseFormat = WebMessageFormat.Json)]
        List<Car> getJsonAll();

        [OperationContract]
        [WebGet(UriTemplate = "/json/Car/{id}", ResponseFormat = WebMessageFormat.Json)]
        Car getJsonById(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/Car", Method = "POST", RequestFormat = WebMessageFormat.Json)]
        string addJson(Car car);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/Car/{id}", Method = "DELETE")]
        string deleteJson(string id);

        //Modyfikacja
        [OperationContract]
        [WebInvoke(UriTemplate = "/Car", Method = "PUT", RequestFormat = WebMessageFormat.Xml)]
        string update(Car car);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/Car", Method = "PUT", RequestFormat = WebMessageFormat.Json)]
        string updateJson(Car car);
    }

    [DataContract]
    public class Car
    {
        [DataMember(Order = 0)]
        public int car_id;
        [DataMember(Order = 1)]
        public string car_manufacturerS;
        [DataMember(Order = 2)]
        public bool car_bool;
        [DataMember(Order = 3)]
        public double car_engineD;
    }
}
