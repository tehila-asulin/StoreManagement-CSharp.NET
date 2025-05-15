using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface ISale
    {
        int Create(Sale item); //Creates new entity object in DAL
        Sale? Read(int id); //Reads entity object by its ID 
        Sale? Read(Func<Sale, bool> filter);
        List<Sale> ReadAll(Func<Sale, bool>? filter = null); //stage 1 only, Reads all entity objects
        void Update(Sale item); //Updates entity object
        void Delete(int id);
    }
}
