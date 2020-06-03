using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MojWebSerwis
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class RestService1 : IRestService1
    {
        private static List<Car> cars;

        RestService1()
        {
            cars = new List<Car>()
            {
                new Car { car_id = 1, car_manufacturerS = "BMW", car_bool = true, car_engineD = 3.0 },
                new Car { car_id = 2, car_manufacturerS = "Audi", car_bool = false, car_engineD = 2.5 },
                new Car { car_id = 3, car_manufacturerS = "VW", car_bool = true, car_engineD = 1.4}
            };
        }

        //XML
        public List<Car> getAll()
        {
            return cars;
        }

        public Car getById(string id)
        {
            int intId = int.Parse(id);
            int idx = cars.FindIndex(b => b.car_id == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);
            return cars.ElementAt(idx);
        }

        public string add(Car car)
        {
            if (car == null)
                throw new WebFaultException<string>("400: Bad Request", HttpStatusCode.BadRequest);
            int idx = cars.FindIndex(b => b.car_id == car.car_id);
            if (idx == -1)
            {
                cars.Add(car);
                return "Added item with ID = " + car.car_id;
            }
            else
                throw new WebFaultException<string>("409: Conflict", HttpStatusCode.Conflict);
        }

        public string delete(string id)
        {
            int intId = int.Parse(id);
            int idx = cars.FindIndex(b => b.car_id == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);
            cars.RemoveAt(idx);
            return "Removed Car with ID = " + id;
        }

        //JSON
        public List<Car> getJsonAll()
        {
            return cars;
        }

        public Car getJsonById(string id)
        {
            int intId = int.Parse(id);
            int idx = cars.FindIndex(b => b.car_id == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);
            return cars.ElementAt(idx);
        }

        public string addJson(Car car)
        {
            if (car == null)
                throw new WebFaultException<string>("400: Bad Request", HttpStatusCode.BadRequest);
            int idx = cars.FindIndex(b => b.car_id == car.car_id);
            if (idx == -1)
            {
                cars.Add(car);
                return "Added item with ID = " + car.car_id;
            }
            else
                throw new WebFaultException<string>("409: Conflict", HttpStatusCode.Conflict);
        }

        public string deleteJson(string id)
        {
            int intId = int.Parse(id);
            int idx = cars.FindIndex(b => b.car_id == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);
            cars.RemoveAt(idx);
            return "Removed Car with ID = " + id;
        }

        //Modyfikacja
        public string update(Car car)
        {
            if (car == null)
                throw new WebFaultException<string>("400: Bad Request", HttpStatusCode.BadRequest);
            var idx = cars.FirstOrDefault(b => b.car_id == car.car_id);
            if (idx != null)
            {
                idx.car_id = car.car_id;
                idx.car_manufacturerS = car.car_manufacturerS;
                idx.car_bool = car.car_bool;
                idx.car_engineD = car.car_engineD;
                return "Updated Car with ID = " + idx.car_id;
            }
            else
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);
        }

        public string updateJson(Car car)
        {
            if (car == null)
                throw new WebFaultException<string>("400: Bad Request", HttpStatusCode.BadRequest);
            var idx = cars.FirstOrDefault(b => b.car_id == car.car_id);
            if (idx != null)
            {
                idx.car_id = car.car_id;
                idx.car_manufacturerS = car.car_manufacturerS;
                idx.car_bool = car.car_bool;
                idx.car_engineD = car.car_engineD;
                return "Updated Car with ID = " + idx.car_id;
            }
            else
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);
        }
    }
}
