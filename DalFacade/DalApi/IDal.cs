using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    public interface IDal
    {
        Icustomer Customer { get; }
        Iproduct Product { get; }
        ISale Sale { get; }
    }
}
