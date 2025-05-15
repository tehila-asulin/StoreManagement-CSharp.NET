using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal sealed class DalXml : IDal
    {
        public Icustomer Customer => new CustomerImplementation();
        public Iproduct Product => new ProductImplementation();
        public ISale Sale => new SaleImplementation();

        private static readonly DalXml instance = new DalXml();
        public static DalXml Instance
        {
            get
            {
                return instance;
            }
        }
        private DalXml() { }
    }
}
