
using DO;
using DalApi;
using System.Runtime.CompilerServices;
namespace DalTest;

public static class Initialization
{
    private static IDal? s_dal;

    private static void creaProduct()
    {
        s_dal.Product.Create(new Product(0, "milk", Category.Milky, 4.5, 50));
        s_dal.Product.Create(new Product(0, "chocolate", Category.Milky, 3, 30));
        s_dal.Product.Create(new Product(0, "delicacy", Category.Milky, 2.5, 20));
        s_dal.Product.Create(new Product(0, "tomato", Category.FruitVegetables, 4, 30));
        s_dal.Product.Create(new Product(0, "cucumber", Category.FruitVegetables, 5, 30));
        s_dal.Product.Create(new Product(0, "carrot", Category.FruitVegetables, 3, 30));
        s_dal.Product.Create(new Product(0, "candy\r\n", Category.Sweets, 1, 100));
        s_dal.Product.Create(new Product(0, "Bamba", Category.Sweets, 4, 60));
        s_dal.Product.Create(new Product(0, "Beasley", Category.Sweets, 5.5, 70));
        s_dal.Product.Create(new Product(0, "potato chips\r\n", Category.Sweets, 3.5, 70));
        s_dal.Product.Create(new Product(0, "bread", Category.Breads, 5, 30));
        s_dal.Product.Create(new Product(0, "buns", Category.Breads, 11, 25));
        s_dal.Product.Create(new Product(0, "pita bread\r\n", Category.Breads, 14, 20));
        s_dal.Product.Create(new Product(0, "Bleach", Category.Cleanliness, 18, 10));
        s_dal.Product.Create(new Product(0, "Window spray", Category.Cleanliness, 14, 20));

    }

    private static void createSale()
    {
        s_dal.Sale.Create(new Sale(0,1000, 10, 20, false, new DateTime(2024, 10, 15), new DateTime(2025, 11, 15)));
        s_dal.Sale.Create(new Sale(0,1100, 20, 25, true, new DateTime(2024, 10, 20), new DateTime(2025, 11, 20)));
        s_dal.Sale.Create(new Sale(0,1200, 23, 40, false, new DateTime(2024, 11, 01), new DateTime(2025, 10, 01)));
    }

    private static void createCustomer()
    {
        s_dal.Customer.Create(new Customer(111, "shani", 123456, "jerusalem"));
        s_dal.Customer.Create(new Customer(222, "teila", 123456, "tel aviv"));
        s_dal.Customer.Create(new Customer(333, "miri", 123456,null));
    }
    public static void Initialize()
    {
       s_dal = DalApi.Factory.Get;
        creaProduct();
        createCustomer();   
        createSale();

    }
}
