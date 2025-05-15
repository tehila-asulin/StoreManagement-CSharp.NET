using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Tools;

namespace Dal
{
    internal class CustomerImplementation : Icustomer
    {
        static string filePath = @"../xml/customers.xml";
        XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
        List<Customer> list;
        public int Create(Customer item)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"insert customer in id:{item.Id}");
            using (StreamReader sr = new StreamReader(filePath))
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
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"delete customer in id:{id}");
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
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read customer in id: {id}");
            using (StreamReader sr = new StreamReader(filePath))
            {
                list = serializer.Deserialize(sr) as List<Customer>;
            }
            return list.FirstOrDefault(customer => customer.Id == id);
        }

        public Customer? Read(Func<Customer, bool> filter)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read customer");
            using (StreamReader sr = new StreamReader(filePath))
            {
                list = serializer.Deserialize(sr) as List<Customer>;
            }
            return list.FirstOrDefault(filter);
        }

        public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read all customers");
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
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"update customer in id:{item.Id}");
            Delete(item.Id);
            Create(item);
        }
    }
}

