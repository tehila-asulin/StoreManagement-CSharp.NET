using DalApi;
using DalXml;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dal
{
    internal class ProductImplementation : Iproduct
    {
        const string filePath = @"..\xml\products.xml";
        //const string PRODUCTS = "Products";
        const string PRODUCT = "Product";
        const string PRODUCTID = "barcode";
        const string PRODUCTNAME = "productName";
        const string CATEGORY = "category";
        const string PRICE = "price";
        const string QUANTITYONSTOCK = "quantityInStock";
        public int Create(Product item)
        {
            XElement productXml = XElement.Load(filePath);
            int nextId = Config.CodeProduct;
            var arrayOfProduct = productXml.Element("ArrayOfProduct");
            if (arrayOfProduct == null)
            {
                arrayOfProduct = new XElement("ArrayOfProduct");
                productXml.Add(arrayOfProduct);
            }
            arrayOfProduct.Add(new XElement(PRODUCT,
                new XElement(PRODUCTID, nextId),
                new XElement(PRODUCTNAME, item.ProductName),
                new XElement(PRICE, item.Price),
                new XElement(QUANTITYONSTOCK, item.QuantityStock),
                new XElement(CATEGORY, item.Category)));
            productXml.Save(filePath);
            return nextId;
        }

        public void Delete(int id)
        {
            XElement productXml = XElement.Load(filePath);
            productXml.Descendants(PRODUCTID).First(p => int.Parse(p.Value) == id).Parent.Remove();
            productXml.Save(filePath);
        }

        public Product? Read(int barcode)
        {
            XElement productXml = XElement.Load(filePath);
            XElement xml = productXml.Descendants(PRODUCTID).First(p => int.Parse(p.Value) == barcode).Parent;
            Product product = new Product(int.Parse(xml.Element(PRODUCTID).Value),
                                    xml.Element(PRODUCTNAME).Value,
                                     (Category)Enum.Parse(typeof(Category), xml.Element(CATEGORY).Value),
                                    double.Parse(xml.Element(PRICE).Value),
                                    int.Parse(xml.Element(QUANTITYONSTOCK).Value)
                                   );
            return product;
        }

        public Product? Read(Func<Product, bool> filter)
        {
            XElement productXml = XElement.Load(filePath);
            var products = productXml.Descendants(PRODUCT)
                            .Select(p => new Product(
                                    int.Parse(p.Element(PRODUCTID).Value),
                                    p.Element(PRODUCTNAME).Value,
                                    (Category)Enum.Parse(typeof(Category), p.Element(CATEGORY).Value),
                                    double.Parse(p.Element(PRICE).Value),
                                    int.Parse(p.Element(QUANTITYONSTOCK).Value)));

            return products.FirstOrDefault(filter);
        }

        public List<Product> ReadAll(Func<Product, bool>? filter = null)
        {
            XElement productXml = XElement.Load(filePath);
            var products = productXml.Descendants("Product")
                .Select(p => new Product(
                                    int.Parse(p.Element(PRODUCTID).Value),
                                    p.Element(PRODUCTNAME).Value,
                                    (Category)Enum.Parse(typeof(Category), p.Element(CATEGORY).Value),
                                    double.Parse(p.Element(PRICE).Value),
                                    int.Parse(p.Element(QUANTITYONSTOCK).Value))).ToList();
            return filter != null ? products.Where(filter).ToList() : products;
        }

        public void Update(Product item)
        {
            XElement productXml = XElement.Load(filePath);
            XElement s = productXml.Descendants("barcode").First(id => int.Parse(id.Value) == item.Barcode).Parent;
            s.Element(PRICE).SetValue(item.Price);
            s.Element(PRODUCTNAME).SetValue(item.ProductName);
            s.Element(QUANTITYONSTOCK).SetValue(item.QuantityStock);
            s.Element(CATEGORY).SetValue(item.Category);
            productXml.Save(filePath);
        }
    }
}
