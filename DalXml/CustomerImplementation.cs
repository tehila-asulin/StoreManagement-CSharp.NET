using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            try
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                      MethodBase.GetCurrentMethod().Name,
                                      $"insert customer in id:{item.Id}");

                using (StreamReader sr = new StreamReader(filePath))
                {
                    list = serializer.Deserialize(sr) as List<Customer>;
                    if (list.Any(c => c.Id == item.Id))
                        throw new DalIdExistException($"Customer with id {item.Id} already exists.");
                    list.Add(item);
                }
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    serializer.Serialize(sw, list);
                }
                return item.Id;
            }
            catch (Exception ex)
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                      MethodBase.GetCurrentMethod().Name,
                                      $"Exception: {ex.Message}");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                      MethodBase.GetCurrentMethod().Name,
                                      $"delete customer in id:{id}");
                using (StreamReader sr = new StreamReader(filePath))
                {
                    list = serializer.Deserialize(sr) as List<Customer>;
                    var customer = list.FirstOrDefault(c => c.Id == id);
                    if (customer == null)
                        throw new DalIdNotFoundException($"Customer with id {id} not found.");
                    list.Remove(customer);
                }
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    serializer.Serialize(sw, list);
                }
            }
            catch (Exception ex)
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                      MethodBase.GetCurrentMethod().Name,
                                      $"Exception: {ex.Message}");
                throw;
            }
        }

        public Customer? Read(int id)
        {
            try
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                      MethodBase.GetCurrentMethod().Name,
                                      $"read customer in id: {id}");
                using (StreamReader sr = new StreamReader(filePath))
                {
                    list = serializer.Deserialize(sr) as List<Customer>;
                }
                var customer = list.FirstOrDefault(c => c.Id == id);
                if (customer == null)
                    throw new DalIdNotFoundException($"Customer with id {id} not found.");
                return customer;
            }
            catch (Exception ex)
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                      MethodBase.GetCurrentMethod().Name,
                                      $"Exception: {ex.Message}");
                throw;
            }
        }

        public Customer? Read(Func<Customer, bool> filter)
        {
            try
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                      MethodBase.GetCurrentMethod().Name,
                                      $"read customer");
                using (StreamReader sr = new StreamReader(filePath))
                {
                    list = serializer.Deserialize(sr) as List<Customer>;
                }
                return list.FirstOrDefault(filter);
            }
            catch (Exception ex)
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                      MethodBase.GetCurrentMethod().Name,
                                      $"Exception: {ex.Message}");
                throw;
            }
        }

        public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
        {
            try
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                      MethodBase.GetCurrentMethod().Name,
                                      $"read all customers");
                using (StreamReader sr = new StreamReader(filePath))
                {
                    list = serializer.Deserialize(sr) as List<Customer>;
                }
                if (filter != null)
                    return list?.Where(filter).ToList() ?? new List<Customer>();
                return list;
            }
            catch (Exception ex)
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                      MethodBase.GetCurrentMethod().Name,
                                      $"Exception: {ex.Message}");
                throw;
            }
        }

        public void Update(Customer item)
        {
            try
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                      MethodBase.GetCurrentMethod().Name,
                                      $"update customer in id:{item.Id}");
                Delete(item.Id);
                Create(item);
            }
            catch (Exception ex)
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                      MethodBase.GetCurrentMethod().Name,
                                      $"Exception: {ex.Message}");
                throw;
            }
        }
    }
}
