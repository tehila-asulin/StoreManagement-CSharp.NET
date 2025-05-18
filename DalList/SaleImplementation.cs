

using DalApi;
using DO;
using System.Reflection;
using Tools;

namespace Dal;

internal class SaleImplementation:ISale
{
    public int Create(Sale item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"insert sale in id:{item.BarcodeSale}");
        Sale sale = item with { BarcodeSale = DataSource.Config.GetCodeSale };
        DataSource.sales.Add(sale);
        return sale.BarcodeSale;
    }
    public Sale? Read(int barcodesale)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read sale int id: {barcodesale}");

        Sale sale;
        sale = DataSource.sales.FirstOrDefault(x => x.BarcodeSale == barcodesale);
        if (sale == null)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"not found  sale in this id: {barcodesale}");
            throw new DalIdNotFoundException("this code is not exist");
        }
            
        else
            return sale;
    }
    public Sale? Read(Func<Sale, bool> filter)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read sale");
        Sale s = DataSource.sales.FirstOrDefault(x => filter(x));
        if (s == null)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"not found sale");
            throw new DalIdNotFoundException("this sale not exist");
        }
           
        else
            return s;
    }
    public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read all sales");
        if (filter == null)
        {
            List<Sale> list = new List<Sale>(DataSource.sales);
            return list;
        }
        else
        {
            var q = DataSource.sales.Where(x => filter(x));
            return q.ToList();
        }

    }
    public void Update(Sale item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"update sale in id:{item.BarcodeSale}");
        Delete(item.BarcodeSale);
        DataSource.sales.Add(item);
    }
    public void Delete(int barcodesale)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"delete sale in id:{barcodesale}");
        Sale sale = Read(barcodesale);
        DataSource.sales.Remove(sale);

    }
}
