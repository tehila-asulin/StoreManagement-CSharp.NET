using DalApi;
using DO;
using System.ComponentModel.Design;
using System.Reflection;
using System.Runtime.InteropServices;
using Tools;

namespace Dal;

internal class ProductImplementation:Iproduct
{
    public int Create(Product item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"insert product in  id:{item.Barcode}");
        Product product = item with { Barcode = DataSource.Config.GetCodeProduct };
        DataSource.products.Add(product);   
        return product.Barcode;
    }
    public Product? Read(int barcode)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read product int id: {barcode}");
        
        Product product;
        product = DataSource.products.FirstOrDefault(x => x.Barcode == barcode);
        if (product == null)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"not found  product in this id: {barcode}");
            throw new DalIdNotFoundException("this code is not exist");
        }
            
        else
            return product;

    }
    public Product? Read(Func<Product, bool> filter)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read product");
        Product p = DataSource.products.FirstOrDefault(x => filter(x));
        if (p == null)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"not found product");
            throw new DalIdNotFoundException("this product not exist");
        }      
        else
            return p;
    }
    public List<Product> ReadAll(Func<Product, bool>? filter = null)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read all products");
        if (filter == null)
        {
            List<Product> list = new List<Product>(DataSource.products);
            return list;
        }
        else
        {
            var q = DataSource.products.Where(x => filter(x));
            return q.ToList();
        }
    }
    public void Update(Product item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"update product in id: {item.Barcode}");
        Delete(item.Barcode);
        DataSource.products.Add(item);
    }
    public void Delete(int barcode)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"delete product in id:{barcode}");
        Product product = Read(barcode);
        DataSource.products.Remove(product);

    }

}
