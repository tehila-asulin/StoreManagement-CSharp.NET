using BlApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    internal class Bl : IBl
    {
        public ICustomer customer => new CustomerImplementation();

        public BlApi.ISale sale => new SaleImplementation();

        public BlApi.IProduct product => new ProductImplementation();

        public IOrder order =>  new OrderImplementation();
    }
}
