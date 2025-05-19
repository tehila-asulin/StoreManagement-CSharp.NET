using BlApi;
using BO;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlImplementation
{
    public class OrderImplementation : IOrder
    {
        private readonly DalApi.IDal _dal = DalApi.Factory.Get;

        public List<SaleInProduct> AddProductToOrder(Order order, int productId, int amount)
        {
            var product = _dal.Product.Read(productId)
                ?? throw new BLIdNotExistException("המוצר עם הברקוד " + productId + " לא נמצא");

            var existing = order.ProductsInOrder.FirstOrDefault(p => p.ProductId == productId);
            if (existing != null)
            {
                if (existing.AmountOfOrder + amount > product.QuantityStock)
                    throw new BO.BlInvalidOperationException("אין מספיק במלאי למוצר: " + product.ProductName);
                existing.AmountOfOrder += amount;
            }
            else
            {
                if (amount > product.QuantityStock)
                    throw new BO.BlInvalidOperationException("אין מספיק במלאי למוצר: " + product.ProductName);

                existing = new ProductInOrder
                {
                    ProductId = product.Barcode,
                    ProductName = product.ProductName,
                    BasePrice = product.Price,
                    AmountOfOrder = amount
                };
                order.ProductsInOrder.Add(existing);
            }
            SearchSaleForProduct(existing, order.IsFevorite);
            CalcTotalPriceForProduct(existing);
            CalcTotalPrice(order);

            return existing.SalesOfProduct;
        }

        public void SearchSaleForProduct(ProductInOrder product, bool isPreferred)
        {
            var sales = _dal.Sale.ReadAll(s =>
                s.ProductId == product.ProductId &&
                s.BeginingSale <= DateTime.Now &&
                s.EndSale >= DateTime.Now &&
                product.AmountOfOrder >= s.RequiredItems &&
                (!s.IsCustomersClub || isPreferred)
            );

            product.SalesOfProduct = sales
                .Select(s => new SaleInProduct
                {
                    SaleId = s.ProductId,
                    CountForSale = s.RequiredItems,
                    Price = s.TotalPrice,
                    IsSaleForAllCustomers = s.IsCustomersClub
                })
                .OrderBy(s => s.Price)
                .ToList();
        }

        public void CalcTotalPriceForProduct(ProductInOrder product)
        {
            int quantity = product.AmountOfOrder;
            double total = 0;
            var appliedSales = new List<SaleInProduct>();

            foreach (var sale in product.SalesOfProduct)
            {
                
                int times = quantity / sale.CountForSale;
                if (times > 0)
                {
                    total += times * sale.Price;
                    quantity -= times * sale.CountForSale;

                    appliedSales.Add(sale); 
                }
            }

            total += quantity * product.BasePrice;

            product.TotalPrice = total;
            product.SalesOfProduct = appliedSales;
        }


        public void CalcTotalPrice(Order order)
        {
            order.TotalPrice = order.ProductsInOrder.Sum(p => p.TotalPrice);
        }

        public void DoOrder(Order order)
        {
            var updates = order.ProductsInOrder.Select(p =>
            {
                var product = _dal.Product.Read(p.ProductId)
                    ?? throw new BLIdNotExistException("המוצר עם ברקוד " + p.ProductId + " לא קיים");

                if (product.QuantityStock < p.AmountOfOrder)
                    throw new BO.BlInvalidOperationException("אין מספיק מלאי למוצר " + product.ProductName);

                return product with { QuantityStock = product.QuantityStock - p.AmountOfOrder };
            });

            foreach (var updated in updates)
            {
                _dal.Product.Update(updated);
            }
        }
    }
}
