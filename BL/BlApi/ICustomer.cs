using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface ICustomer
    {
        int Create(Customer item); //Creates new entity object in DAL
        Customer? Read(int id); //Reads entity object by its ID 
        Customer? Read(Func<Customer, bool> filter);
        List<Customer> ReadAll(Func<Customer, bool>? filter = null); //stage 1 only, Reads all entity objects
        void Update(Customer item); //Updates entity object
        void Delete(int id);
        bool IsCustomerExist();
    }
}
