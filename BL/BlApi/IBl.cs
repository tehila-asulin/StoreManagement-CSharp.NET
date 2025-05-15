
using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IBl
    {
        public ICustomer customer { get; }
        public ISale sale { get; }
        public IProduct product { get; }
        public IOrder order { get; }
    }
}
