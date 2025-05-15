
using BlApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.Tools;

namespace BlImplementation
{
    internal class SaleImplementation:ISale
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(BO.Sale item)
        {
            try
            {
                return _dal.Sale.Create(item.ConversBoSaleToDoSale());
            }
            catch
            {
                throw new Exception("");
            }
          
        }

        public void Delete(int id)
        {
            try
            {
                 _dal.Sale.Delete(id);
            }
            catch
            {
                throw new Exception("");
            }
        }

        public BO.Sale? Read(int id)
        {
            try
            {
               return _dal.Sale.Read(id).ConversDoSaleToBoSale();
            }
            catch
            {
                throw new Exception("");
            }
        }

        public BO.Sale? Read(Func<BO.Sale, bool> filter)
        {
            try
            {
                return _dal.Sale.Read(s=>filter(s.ConversDoSaleToBoSale())).ConversDoSaleToBoSale();
            }
            catch
            {
                throw new Exception("");
            }
        }

        public List<BO.Sale> ReadAll(Func<BO.Sale, bool>? filter = null)
        {
            try
            {
                if (filter == null)
                    return _dal.Sale.ReadAll().Select(s => s.ConversDoSaleToBoSale()).ToList();
                else
                    return _dal.Sale.ReadAll(s => filter(s.ConversDoSaleToBoSale())).Select(s=>s.ConversDoSaleToBoSale()).ToList();
            }
            catch
            {
                throw new Exception("");
            }
        }

        public void Update(BO.Sale item)
        {
            try
            {
                 _dal.Sale.Update(item.ConversBoSaleToDoSale());
            }
            catch
            {
                throw new Exception("");
            }
        }
    }
}
