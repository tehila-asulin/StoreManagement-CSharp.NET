using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dal
{
    internal class CustomerImplementation : Icustomer
    {
        static string filePath = @"../xml/customers.xml";
        XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
        List<Customer> list;
        public int Create(Customer item)
        {
            using(StreamReader sr = new StreamReader(filePath))
            {
                list = serializer.Deserialize(sr) as List<Customer>;
                list.Add(item);
            }
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                serializer.Serialize(sw, list);
            }
            return item.Id;
        }
        public void Delete(int id)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
             
                list = serializer.Deserialize(sr) as List<Customer>;
                list.Remove(list.FirstOrDefault(customer => customer.Id == id));
            }
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                serializer.Serialize(sw, list);
            }
        }

        public Customer? Read(int id)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                list = serializer.Deserialize(sr) as List<Customer>;
            }
            return list.FirstOrDefault(customer => customer.Id == id);
        }

        public Customer? Read(Func<Customer, bool> filter)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                list = serializer.Deserialize(sr) as List<Customer>;
            }
            return list.FirstOrDefault(filter);
        }

        public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                list = serializer.Deserialize(sr) as List<Customer>;
            }
            if (filter != null)
                return list?.Where(filter!).ToList() ?? throw new Exception();
            return list;
        }

        public void Update(Customer item)
        {

            Delete(item.Id);
            Create(item);
        }
    }
}
