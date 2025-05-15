using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
   public static class Tools
    {

        public static string ToStringProperty<T>(this T obj)
        {
            if (obj == null) return "null";

            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            List<string> propertyStrings = new List<string>();

            foreach (var property in properties)
            {
                object value = property.GetValue(obj);
                if (value is IEnumerable)
                {
                    List<string> listItems = new List<string>();
                    foreach (var item in (IEnumerable)value)
                    {
                        listItems.Add(item?.ToString());
                    }
                    propertyStrings.Add($"{property.Name}: [{string.Join(", ", listItems)}]");
                }
                else
                {
                    propertyStrings.Add($"{property.Name}: {value?.ToString()}");
                }
            }

            return string.Join(", ", propertyStrings);
        }



        public static DO.Product ConversBoProductToDoProduct(this BO.Product product)
        {
            return new DO.Product(product.Barcode, product.ProductName, (DO.Category)product.Category, product.Price, product.QuantityStock);
        }


        public static BO.Product ConversDoProductToBoProduct(this DO.Product product)
        {
            return new BO.Product(product.Barcode, product.ProductName, (BO.Category)product.Category, product.Price, product.QuantityStock);
        }


        public static DO.Customer ConversBoCustomerToDoCustomer(this BO.Customer customer)
        {
            return new DO.Customer(customer.Id, customer.Name, customer.Phone, customer.Address);
        }

        public static BO.Customer ConversDoCustomerToBoCustomer(this DO.Customer customer)
        {
            return new BO.Customer(customer.Id, customer.Name, customer.Phone, customer.Address);
        }

        public static DO.Sale ConversBoSaleToDoSale(this BO.Sale sale)
        {
            return new DO.Sale(sale.BarcodeSale,sale.ProductId,sale.RequiredItems,sale.TotalPrice,sale.IsCustomersClub,sale.BeginingSale,sale.EndSale);

        }

        public static BO.Sale ConversDoSaleToBoSale(this DO.Sale sale)
        {
            return new BO.Sale(sale.BarcodeSale, sale.ProductId, sale.RequiredItems, sale.TotalPrice, sale.IsCustomersClub, sale.BeginingSale, sale.EndSale);

        }




    }
}
