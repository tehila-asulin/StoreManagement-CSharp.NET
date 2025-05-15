using DalApi;
using DalXml;
using DO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Dal
{
    internal class SaleImplementation : ISale
    {
        static string filePath = @"../xml/sales.xml";
        XmlSerializer serializer = new XmlSerializer(typeof(List<Sale>));
        List<Sale> list;

        //public int Create(Sale item)
        //{
        //    using (StreamReader sr = new StreamReader(filePath))
        //    {
        //        int nextId = Config.CodeSale;
        //        item.BarcodeSale = nextId;
        //        list = serializer.Deserialize(sr) as List<Sale>;
        //        list.Add(item);
        //    }
        //    using (StreamWriter sw = new StreamWriter(filePath))
        //    {
        //        serializer.Serialize(sw, list);
        //    }
        //    return item.BarcodeSale;
        //}
        public int Create(Sale item)    
        {
            int nextId = 0;
            using (StreamReader sr = new StreamReader(filePath))
            {
                 nextId = Config.CodeSale;
                list = serializer.Deserialize(sr) as List<Sale>;

                // צור מופע חדש עם כל הנתונים הקיימים של item + ברקוד חדש
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
            using (StreamReader sr = new StreamReader(filePath))
            {
                list = serializer.Deserialize(sr) as List<Sale>;
            }
            return list.FirstOrDefault(sale => sale.BarcodeSale == id);
        }

        public Sale? Read(Func<Sale, bool> filter)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                list = serializer.Deserialize(sr) as List<Sale>;
            }
            return list.FirstOrDefault(filter);
        }

        public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
        {
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
            Delete(item.BarcodeSale);
            Create(item);
        }
    }
}
