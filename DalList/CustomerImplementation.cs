
namespace Dal;
using DO;
using DalApi;
using System.Runtime.InteropServices;
using System.Reflection.Metadata.Ecma335;
using System.Reflection;
using Tools;

internal class CustomerImplementation : Icustomer
{

    public int Create(Customer item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"insert customer in id:{item.Id}");
  
        bool c = DataSource.customers.Any(x => x.Id == item.Id);
        if (c)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "This customer exists in this id");
            throw new DalIdExistException("this code is exist");
        }
        else
            DataSource.customers.Add(item);
        return item.Id;
    }
    public Customer? Read(int id)
    {

        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read customer in id: {id}");
        Customer customer;
     

        customer = DataSource.customers.FirstOrDefault(x => x.Id == id);
        if (customer == null)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"not found  customer in this id: {id}");
            throw new DalIdNotFoundException("this code is not exist");
        }
            
        else
            return customer;    
    }
    public Customer? Read(Func<Customer, bool> filter)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read customer");
        Customer c = DataSource.customers.FirstOrDefault(x => filter(x));
        if (c == null)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"not found customer");
            throw new DalIdNotFoundException("this customer not exist");
        }   
        else
            return c;
    }
    public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read all customers");
        if (filter == null)
        {
            List<Customer> list = new List<Customer>(DataSource.customers);
            return list;
        }
        else
        {
            var q = DataSource.customers.Where(x => filter(x));
            return q.ToList();
        }
    }
    public void Update(Customer item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"update customer in id:{item.Id}");
        Delete(item.Id);
        DataSource.customers.Add(item);
    }
    public void Delete(int id)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"delete customer in id:{id}");
        Customer customer = Read(id);
        DataSource.customers.Remove(customer);

    }
}
