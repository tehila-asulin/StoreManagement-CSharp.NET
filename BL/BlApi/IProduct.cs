using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IProduct
    {
        int Create(Product item); //Creates new entity object in DAL
        Product? Read(int id); //Reads entity object by its ID 
        Product? Read(Func<Product, bool> filter);
        List<Product> ReadAll(Func<Product, bool>? filter = null); //stage 1 only, Reads all entity objects
        void Update(Product item); //Updates entity object
        void Delete(int id);
       
    }
}
