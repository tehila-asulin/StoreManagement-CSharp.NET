//using BlApi;
//using static BO.Tools;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using BO;
//using DO;


//namespace BlImplementation
//{
//    public class OrderImplementation : IOrder
//    {
//        private DalApi.IDal _dal = DalApi.Factory.Get;
//        //    public List<BO.SaleInProduct> AddProductToOrder(BO.Order order, int productId, int amount)
//        //    {
//        //        //??
//        //        var product = _dal.Product.Read(productId);
//        //        if (product == null)
//        //        {
//        //            throw new Exception("המוצר לא נמצא");
//        //        }
//        //        var foundProductInOrder = order.ProductsInOrder.FirstOrDefault(p => p.ProductId == productId);
//        //        if (foundProductInOrder != null)
//        //        {
//        //            if (foundProductInOrder.AmountOfOrder + amount > product.QuantityStock)
//        //            {
//        //                throw new Exception("אין מספיק במלאי");
//        //            }
//        //            foundProductInOrder.AmountOfOrder += amount;
//        //        }
//        //        else
//        //        {
//        //            if (amount > product.QuantityStock)
//        //            {
//        //                throw new Exception("אין מספיק במלאי");
//        //            }
//        //            var newProductInOrder = new BO.ProductInOrder
//        //            {
//        //                ProductId = product.Barcode,
//        //                AmountOfOrder = amount,
//        //                BasePrice = product.Price,
//        //                ProductName = product.ProductName,
//        //            };
//        //            order.ProductsInOrder.Add(newProductInOrder);
//        //            foundProductInOrder = newProductInOrder;
//        //        }
//        //        SearchSaleForProduct(foundProductInOrder, false);
//        //        CalcTotalPriceForProduct(foundProductInOrder);
//        //        CalcTotalPrice(order);
//        //        return foundProductInOrder.SalesOfProduct;
//        //    }

//        //    //public void CalcTotalPrice(BO.Order order)
//        //    //{
//        //    //    order.TotalPrice += (from product in order.ProductsInOrder
//        //    //                         select product.BasePrice).Sum();
//        //    //}

//        //    //public void CalcTotalPriceForProduct(BO.ProductInOrder productForCalc)
//        //    //{
//        //    //    int count = productForCalc.AmountOfOrder;
//        //    //    List<SaleInProduct> saleInProducts = new List<SaleInProduct>();
//        //    //    var sales = productForCalc.SalesOfProduct
//        //    //        .Where(sale => sale.CountForSale >= count)
//        //    //        .Select(sale =>
//        //    //        {
//        //    //            double sum = count / sale.CountForSale * sale.Price;
//        //    //            count -= (int)(count / sale.CountForSale);
//        //    //            saleInProducts.Add(sale);
//        //    //            return new { sale, sum };
//        //    //        })
//        //    //        .TakeWhile(x => count > 0)
//        //    //        .ToList();
//        //    //    double total = sales.Sum(x => x.sum) + (count * productForCalc.BasePrice);
//        //    //    productForCalc.TotalPrice = total;
//        //    //    productForCalc.SalesOfProduct = sales.Select(x => x.sale).ToList();
//        //    //}

//        //    //public void DoOrder(BO.Order order)
//        //    //{

//        //    //    try
//        //    //    {
//        //    //        int cnt = order.ProductsInOrder
//        //    //                   .Sum(p => p.AmountOfOrder);
//        //    //        // _dal.product.ReadAll().All(p=>p.Id==order.ProductsInOrder.ForEach(o=>o.))

//        //    //    }
//        //    //    catch
//        //    //    {

//        //    //    }
//        //    //}

//        //    public void SearchSaleForProduct(BO.ProductInOrder product, bool isPreferred)
//        //    {
//        //        try
//        //        {
//        //            product.SalesOfProduct = _dal.Sale.ReadAll(s => s.ProductId == product.ProductId
//        //            && s.BeginingSale <= DateTime.Now && s.EndSale >= DateTime.Now
//        //            && product.AmountOfOrder >= s.RequiredItems
//        //            && (isPreferred || s.IsCustomersClub))

//        //                .Select(s => new BO.SaleInProduct() { SaleId = s.ProductId, CountForSale = s.RequiredItems, IsSaleForAllCustomers = s.IsCustomersClub, Price = s.TotalPrice })
//        //                .OrderBy(s => s.Price)
//        //                .ToList();
//        //        }
//        //        catch (Exception ex)
//        //        {
//        //            Console.WriteLine(ex.Message);


//        //        }
//        //    }

//        //    public void CalcTotalPriceForProduct(BO.ProductInOrder product)
//        //    {
//        //        double totalPrice = product.BasePrice * product.AmountOfOrder;


//        //        foreach (var sale in product.SalesOfProduct)
//        //        {
//        //            if (product.AmountOfOrder >= sale.CountForSale)
//        //            {
//        //                totalPrice -= sale.Price;
//        //                product.AmountOfOrder -= sale.CountForSale;
//        //            }
//        //            if (product.AmountOfOrder == 0) break;
//        //        }

//        //        product.TotalPrice = totalPrice;
//        //    }

//        //    public void CalcTotalPrice(BO.Order order)
//        //    {
//        //        double totalPrice = 0;
//        //        foreach (var product in order.ProductsInOrder)
//        //        {
//        //            totalPrice += product.TotalPrice;
//        //        }
//        //        order.TotalPrice = totalPrice;
//        //    }

//        //    public void DoOrder(BO.Order order)
//        //    {
//        //        var update = order.ProductsInOrder.Select(p =>
//        //        {
//        //            var x = _dal.Product.Read(p.ProductId);
//        //            if (x.QuantityStock < p.AmountOfOrder)
//        //                throw new Exception("אין מספיק מלאי למוצר");
//        //            return x with { QuantityStock = x.QuantityStock - p.AmountOfOrder };
//        //        }).ToList();
//        //        foreach (var x in update)
//        //        {
//        //            _dal.Product.Update(x);
//        //        }

//        //    }

//        public List<BO.SaleInProduct> AddProductToOrder(BO.Order order, int productId, int amount)
//        {
//            var product = _dal.Product.Read(productId) ?? throw new Exception("המוצר לא נמצא");

//            var foundProductInOrder = order.ProductsInOrder.FirstOrDefault(p => p.ProductId == productId);
//            if (foundProductInOrder != null)
//            {
//                if (foundProductInOrder.AmountOfOrder + amount > product.QuantityStock)
//                    throw new Exception("אין מספיק במלאי");

//                foundProductInOrder.AmountOfOrder += amount;
//            }
//            else
//            {
//                if (amount > product.QuantityStock)
//                    throw new Exception("אין מספיק במלאי");

//                var newProductInOrder = new BO.ProductInOrder
//                {
//                    ProductId = product.Barcode,
//                    AmountOfOrder = amount,
//                    BasePrice = product.Price,
//                    ProductName = product.ProductName
//                };
//                order.ProductsInOrder.Add(newProductInOrder);
//                foundProductInOrder = newProductInOrder;
//            }

//            SearchSaleForProduct(foundProductInOrder, false);
//            CalcTotalPriceForProduct(foundProductInOrder);
//            CalcTotalPrice(order);

//            return foundProductInOrder.SalesOfProduct;
//        }

//        public void SearchSaleForProduct(BO.ProductInOrder product, bool isPreferred)
//        {
//            product.SalesOfProduct = _dal.Sale.ReadAll(s =>
//                s.ProductId == product.ProductId &&
//                s.BeginingSale <= DateTime.Now &&
//                s.EndSale >= DateTime.Now &&
//                product.AmountOfOrder >= s.RequiredItems &&
//                (isPreferred || s.IsCustomersClub)
//            ).Select(s => new BO.SaleInProduct
//            {
//                SaleId = s.ProductId,
//                CountForSale = s.RequiredItems,
//                IsSaleForAllCustomers = s.IsCustomersClub,
//                Price = s.TotalPrice
//            })
//            .OrderBy(s => s.Price) // הנחה הכי משתלמת בראש
//            .ToList();
//        }

//        //public void CalcTotalPriceForProduct(BO.ProductInOrder product)
//        //{
//        //    int count = product.AmountOfOrder;
//        //    double total = 0;
//        //    var usedSales = new List<BO.SaleInProduct>();

//        //    foreach (var sale in product.SalesOfProduct)
//        //    {
//        //        if (count >= sale.CountForSale)
//        //        {
//        //            total += sale.Price;
//        //            count -= sale.CountForSale;
//        //            usedSales.Add(sale);
//        //        }
//        //    }

//        //    // יתרה במחיר מלא
//        //    total += count * product.BasePrice;

//        //    product.TotalPrice = total;
//        //    product.SalesOfProduct = usedSales;
//        //}
//        public void CalcTotalPriceForProduct(BO.ProductInOrder product)
//        {
//            double totalPrice = 0;
//            int remaining = product.AmountOfOrder;
//            var usedSales = new List<BO.SaleInProduct>();

//            foreach (var sale in product.SalesOfProduct)
//            {
//                if (remaining >= sale.CountForSale)
//                {
//                    totalPrice += sale.Price;
//                    remaining -= sale.CountForSale;
//                    usedSales.Add(sale);
//                    break; // רק מבצע אחד מותר לשימוש
//                }
//            }

//            // שאר המוצרים במחיר מלא
//            totalPrice += remaining * product.BasePrice;

//            product.TotalPrice = totalPrice;
//            product.SalesOfProduct = usedSales;
//        }

//        public void CalcTotalPrice(BO.Order order)
//        {
//            order.TotalPrice = order.ProductsInOrder.Sum(p => p.TotalPrice);
//        }

//        public void DoOrder(BO.Order order)
//        {
//            var updates = order.ProductsInOrder.Select(p =>
//            {
//                var prod = _dal.Product.Read(p.ProductId);
//                if (prod.QuantityStock < p.AmountOfOrder)
//                    throw new Exception("אין מספיק מלאי למוצר");
//                return prod with { QuantityStock = prod.QuantityStock - p.AmountOfOrder };
//            });

//            foreach (var updated in updates)
//                _dal.Product.Update(updated);
//        }


//    }
//}
using BlApi;
using BO;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace BlImplementation
{
    public class OrderImplementation : IOrder
    {
        private readonly DalApi.IDal _dal = DalApi.Factory.Get;
        private BO.Customer currentCustomer;

        public List<SaleInProduct> AddProductToOrder(Order order, int productId, int amount,int idCustomer)
        {

            var product = _dal.Product.Read(productId) ?? throw new Exception("המוצר לא נמצא");

            var existing = order.ProductsInOrder.FirstOrDefault(p => p.ProductId == productId);
            if (existing != null)
            {
                if (existing.AmountOfOrder + amount > product.QuantityStock)
                    throw new Exception("אין מספיק במלאי");
                existing.AmountOfOrder += amount;
            }
            else
            {
                if (amount > product.QuantityStock)
                    throw new Exception("אין מספיק במלאי");

                existing = new ProductInOrder
                {
                    ProductId = product.Barcode,
                    ProductName = product.ProductName,
                    BasePrice = product.Price,
                    AmountOfOrder = amount
                };
                order.ProductsInOrder.Add(existing);
            }

            bool isPreferred = _dal.Customer.Read(idCustomer) != null;
            SearchSaleForProduct(existing, isPreferred);
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
                product.AmountOfOrder >= s.RequiredItems&&
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
                .OrderBy(s => s.Price) // הנחה הכי משתלמת בראש
                .ToList();
        }

        public void CalcTotalPriceForProduct(ProductInOrder product)
        {
            int quantity = product.AmountOfOrder;
            double total = 0;
            var appliedSales = new List<SaleInProduct>();

            foreach (var sale in product.SalesOfProduct)
            {
                if (quantity >= sale.CountForSale)
                {
                    total += sale.Price;
                    quantity -= sale.CountForSale;
                    appliedSales.Add(sale);
                    break; // הפעל רק מבצע אחד!
                }
            }

            total += quantity * product.BasePrice;

            product.TotalPrice = total;
            product.SalesOfProduct = appliedSales;

        }
        //public void CalcTotalPriceForProduct(BO.ProductInOrder productForCalc)
        //{
        //    int count = productForCalc.AmountOfOrder;
        //    double total = 0;
        //    List<SaleInProduct> usedSales = new List<SaleInProduct>();

        //    foreach (var sale in productForCalc.SalesOfProduct)
        //    {
        //        if (count < sale.CountForSale)
        //            continue;

        //        int times = count / sale.CountForSale;
        //        total += times * sale.CountForSale * sale.Price;
        //        count -= times * sale.CountForSale;
        //        usedSales.Add(sale);

        //        if (count == 0)
        //            break;
        //    }
        //    total += count * productForCalc.BasePrice;
        //    productForCalc.TotalPrice = total;
        //    productForCalc.SalesOfProduct = usedSales;
        //}
        public void CalcTotalPrice(Order order)
        {
            order.TotalPrice = order.ProductsInOrder.Sum(p => p.TotalPrice);
        }

        public void DoOrder(Order order)
        {
            var updates = order.ProductsInOrder.Select(p =>
            {
                var product = _dal.Product.Read(p.ProductId);
                if (product.QuantityStock < p.AmountOfOrder)
                    throw new Exception("אין מספיק מלאי למוצר");

                return product with { QuantityStock = product.QuantityStock - p.AmountOfOrder };
            });

            foreach (var updated in updates)
            {
                _dal.Product.Update(updated);
            }
        }
    }
}



