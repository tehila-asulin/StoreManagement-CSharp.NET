using DalApi;
using DalXml;
using DO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"insert sale in id:{item.BarcodeSale}");
            int nextId = 0;
            using (StreamReader sr = new StreamReader(filePath))
            {
                 nextId = Config.CodeSale;
                list = serializer.Deserialize(sr) as List<Sale>;

                
                Sale newSale = new Sale(
                    nextId,
                    item.ProductId,
                    item.RequiredItems,
                    item.TotalPrice,
                    item.IsCustomersClub,
                    item.BeginingSale,
                    item.EndSale
                );

                list.Add(newSale);
            }

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                serializer.Serialize(sw, list);
            }

            return nextId;
        }


        public void Delete(int id)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"delete sale in id:{id}");
            using (StreamReader sr = new StreamReader(filePath))
            {
                list = serializer.Deserialize(sr) as List<Sale>;
                list.Remove(list.FirstOrDefault(sale => sale.BarcodeSale == id));
            }
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                serializer.Serialize(sw, list);
            }
        }

        public Sale Read(int id)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read sale int id: {id}");
            using (StreamReader sr = new StreamReader(filePath))
            {
                list = serializer.Deserialize(sr) as List<Sale>;
            }
            return list.FirstOrDefault(sale => sale.BarcodeSale == id);
        }

        public Sale? Read(Func<Sale, bool> filter)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read sale");
            using (StreamReader sr = new StreamReader(filePath))
            {
                list = serializer.Deserialize(sr) as List<Sale>;
            }
            return list.FirstOrDefault(filter);
        }

        public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read all sales");
            using (StreamReader sr = new StreamReader(filePath))
            {
                list = serializer.Deserialize(sr) as List<Sale>;
            }
            if (filter != null)
                return list?.Where(filter!).ToList() ?? throw new Exception();
            return list;
        }

        public void Update(Sale item)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"update sale in id:{item.BarcodeSale}");
            Delete(item.BarcodeSale);
            Create(item);
        }
    }
}


