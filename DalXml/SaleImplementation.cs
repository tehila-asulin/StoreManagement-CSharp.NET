using DalApi;
using DalXml;
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
    internal class SaleImplementation : ISale
    {
        static string filePath = @"../xml/sales.xml";
        XmlSerializer serializer = new XmlSerializer(typeof(List<Sale>));
        List<Sale> list;

        public int Create(Sale item)
        {
           
            try
            {
                int nextId = Config.CodeSale;
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                      MethodBase.GetCurrentMethod().Name,
                                      $"insert sale in id:{nextId}");

               
                using (StreamReader sr = new StreamReader(filePath))
                {
                    list = serializer.Deserialize(sr) as List<Sale>;
                    if (list.Any(s => s.BarcodeSale == nextId))
                        throw new DalIdExistException($"Sale with id {nextId} already exists.");

                    Sale sale = new Sale(nextId,item.ProductId,item.RequiredItems,item.TotalPrice,item.IsCustomersClub,item.BeginingSale,item.EndSale);
                    list.Add(sale);
                }
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    serializer.Serialize(sw, list);
                }
                return nextId;
            }
            catch (Exception ex)
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                      MethodBase.GetCurrentMethod().Name,
                                      $"Exception: {ex.Message}");
                throw;
            }
        }

        public Sale? Read(int id)
        {
            try
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                      MethodBase.GetCurrentMethod().Name,
                                      $"read sale in id: {id}");

                using (StreamReader sr = new StreamReader(filePath))
                {
                    list = serializer.Deserialize(sr) as List<Sale>;
                }
                var sale = list.FirstOrDefault(s => s.BarcodeSale == id);
                if (sale == null)
                    throw new DalIdNotFoundException($"Sale with id {id} not found.");
                return sale;
            }
            catch (Exception ex)
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                      MethodBase.GetCurrentMethod().Name,
                                      $"Exception: {ex.Message}");
                throw;
            }
        }

        public Sale? Read(Func<Sale, bool> filter)
        {
            try
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                      MethodBase.GetCurrentMethod().Name,
                                      $"read sale with filter");

                using (StreamReader sr = new StreamReader(filePath))
                {
                    list = serializer.Deserialize(sr) as List<Sale>;
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

        public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
        {
            try
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                      MethodBase.GetCurrentMethod().Name,
                                      $"read all sales");

                using (StreamReader sr = new StreamReader(filePath))
                {
                    list = serializer.Deserialize(sr) as List<Sale>;
                }
                if (filter != null)
                    return list.Where(filter).ToList();
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
        public void Delete(int id)
        {
            try
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                      MethodBase.GetCurrentMethod().Name,
                                      $"delete sale with id: {id}");

                using (StreamReader sr = new StreamReader(filePath))
                {
                    list = serializer.Deserialize(sr) as List<Sale>;
                }

                var sale = list.FirstOrDefault(s => s.BarcodeSale == id);
                if (sale == null)
                    throw new DalIdNotFoundException($"Sale with id {id} not found.");

                list.Remove(sale);

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

        public void Update(Sale item)
        {
            try
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                      MethodBase.GetCurrentMethod().Name,
                                      $"update sale in id:{item.BarcodeSale}");
                Delete(item.BarcodeSale);
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
