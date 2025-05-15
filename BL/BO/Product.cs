using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Product
    {
       public int Barcode { get; init; }
        public string ProductName { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public int QuantityStock { get; set; }

        public List<SaleInProduct> ListOfSale { get; set; } = new List<SaleInProduct>();


        public Product(int barcode, string productName, Category category, double price, int quantityStock)
        {
            this.Barcode = barcode;
            this.ProductName = productName;
            this.Category = category;
            this.Price = price;
            this.QuantityStock = quantityStock;
        }
        public Product() { }
    }
}
