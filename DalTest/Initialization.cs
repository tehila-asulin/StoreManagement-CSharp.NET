
using DO;
using DalApi;
using System.Runtime.CompilerServices;
namespace DalTest;

public static class Initialization
{
    private static IDal? s_dal;

    private static void creaProduct()
    {
        s_dal.Product.Create(new Product(0, "חלב", Category.Milky, 4.5, 50));
        s_dal.Product.Create(new Product(0, "שוקולד", Category.Milky, 3, 30));
        s_dal.Product.Create(new Product(0, "גבינה", Category.Milky, 2.5, 20));
        s_dal.Product.Create(new Product(0, "עגבניה", Category.FruitVegetables, 4, 30));
        s_dal.Product.Create(new Product(0, "מלפפון", Category.FruitVegetables, 5, 30));
        s_dal.Product.Create(new Product(0, "גזר", Category.FruitVegetables, 3, 30));
        s_dal.Product.Create(new Product(0, "סוכריה", Category.Sweets, 1, 100));
        s_dal.Product.Create(new Product(0, "במבה", Category.Sweets, 4, 60));
        s_dal.Product.Create(new Product(0, "ביסלי", Category.Sweets, 5.5, 70));
        s_dal.Product.Create(new Product(0, "צ'יפס", Category.Sweets, 3.5, 70));
        s_dal.Product.Create(new Product(0, "לחם", Category.Breads, 5, 30));
        s_dal.Product.Create(new Product(0, "לחמניה", Category.Breads, 11, 25));
        s_dal.Product.Create(new Product(0, "פיתה", Category.Breads, 14, 20));
        s_dal.Product.Create(new Product(0, "מגבונים", Category.Cleanliness, 18, 10));
        s_dal.Product.Create(new Product(0, "ספריי חלונות", Category.Cleanliness, 14, 20));

    }

    private static void createSale()
    {
        s_dal.Sale.Create(new Sale(0,1000, 10, 20, false, new DateTime(2024, 10, 15), new DateTime(2025, 11, 15)));
        s_dal.Sale.Create(new Sale(0,1100, 20, 25, true, new DateTime(2024, 10, 20), new DateTime(2025, 11, 20)));
        s_dal.Sale.Create(new Sale(0,1200, 23, 40, false, new DateTime(2024, 11, 01), new DateTime(2025, 10, 01)));
    }

    private static void createCustomer()
    {
        s_dal.Customer.Create(new Customer(111, "שני", 123456, "ירושלים"));
        s_dal.Customer.Create(new Customer(222, "תהילה", 123456, "תל אביב"));
        s_dal.Customer.Create(new Customer(333, "מירי", 123456,"חיפה"));
    }
    public static void Initialize()
    {
        s_dal = DalApi.Factory.Get;
        creaProduct();
        createCustomer();   
        createSale();

    }
}
