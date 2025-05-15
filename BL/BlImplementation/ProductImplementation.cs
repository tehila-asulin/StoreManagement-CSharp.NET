using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    internal class ProductImplementation : IProduct
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        int IProduct.Create(Product item)
        {
            try
            {
                return _dal.Product.Create(item.ConversBoProductToDoProduct());
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        void IProduct.Delete(int id)
        {
            try
            {
                _dal.Product.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        Product? IProduct.Read(int id)
        {
            try
            {
                DO.Product doRes = _dal.Product.Read(id);
                return doRes.ConversDoProductToBoProduct();
            }
            catch (Exception e)
            {
                return null;
            }

        }

        Product? IProduct.Read(Func<Product, bool> filter)
        {
            try
            {
                DO.Product product = _dal.Product.Read(c => filter(c.ConversDoProductToBoProduct()));
                return product.ConversDoProductToBoProduct();
            }
            catch
            {
                return null;
            }

        }

        List<Product> IProduct.ReadAll(Func<Product, bool>? filter)
        {
            if (filter == null)


                return _dal.Product.ReadAll().Select(p => p.ConversDoProductToBoProduct()).ToList();
            return _dal.Product.ReadAll(p => filter(p.ConversDoProductToBoProduct())).Select(p => p.ConversDoProductToBoProduct()).ToList();

        }

        void IProduct.SaleIsValide(int code, bool isFavorite)
        {

        }

        void IProduct.Update(Product item)
        {
            try
            {
                _dal.Product.Update(item.ConversBoProductToDoProduct());
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
    }
}
