using BO;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IOrder
    {
        public List<SaleInProduct> AddProductToOrder(Order order, int productId, int amount);
       
        void CalcTotalPriceForProduct(ProductInOrder productInOrder);
        
        void CalcTotalPrice(Order order);
       
        void DoOrder(Order order);
        
        void SearchSaleForProduct(ProductInOrder produc, bool isFavorite);

    }
}
