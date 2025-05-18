using static BO.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using BO;

namespace BlImplementation
{
    internal class CustomerImplementation : ICustomer
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(Customer item)
        {
            try
            {
                return _dal.Customer.Create(item.ConversBoCustomerToDoCustomer());
            }
            catch (DO.DalIdExistException ex)
            {
                throw new BLCodeExistException(ex.Message, ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _dal.Customer.Delete(id);
            }
            catch (DO.DalIdNotFoundException ex)
            {
                throw new BLIdNotExistException(ex.Message, ex);
            }
        }

        public bool IsCustomerExist(int id)
        {
            try
            {
                return Read(id) != null;
            }
            catch(Exception ex)
            {

            }
            return false;
            
        }

        public Customer? Read(int id)
        {
            try
            {
                DO.Customer doRes = _dal.Customer.Read(id);
                return doRes.ConversDoCustomerToBoCustomer();
            }
            catch (DO.DalIdNotFoundException ex)
            {
                throw new BLIdNotExistException(ex.Message, ex);
            }
        }

        public Customer? Read(Func<Customer, bool> filter)
        {
            try
            {
                DO.Customer customer = _dal.Customer.Read(c => filter(c.ConversDoCustomerToBoCustomer()));
                return customer.ConversDoCustomerToBoCustomer();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while reading customer by filter", ex);
            }
        }

        public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
        {
            try
            {
                if (filter == null)
                    return _dal.Customer.ReadAll().Select(c => c.ConversDoCustomerToBoCustomer()).ToList();
                return _dal.Customer.ReadAll(c => filter(c.ConversDoCustomerToBoCustomer())).Select(c => c.ConversDoCustomerToBoCustomer()).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while reading all customers", ex);
            }
        }

        public void Update(Customer item)
        {
            try
            {
                _dal.Customer.Update(item.ConversBoCustomerToDoCustomer());
            }
            catch (DO.DalIdNotFoundException ex)
            {
                throw new BLIdNotExistException(ex.Message, ex);
            }
        }
    }
}

