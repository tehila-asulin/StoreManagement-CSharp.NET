
using DalApi;
using DO;
using System.Runtime.CompilerServices;

namespace DalTest
{
    public delegate void CreateUpdateDel();
    internal class Program
    {
        private readonly static IDal s_dal = DalApi.Factory.Get;
        private static int printMainMenue()
        {
            int selection = 0;
            Console.WriteLine("to product press 1");
            Console.WriteLine("to customers press 2");
            Console.WriteLine("to sales press 3");
            Console.WriteLine("to delete all directories in log press 4");
            Console.WriteLine("to exit press 0");
            if (!(int.TryParse(Console.ReadLine(), out selection))) selection = -1;
            return selection;
        }
        private static int PrintSubMenu(string s)
        {
            int selection = 1;

            Console.WriteLine($"to add {s} press 1");
            Console.WriteLine($"to show {s} press 2");
            Console.WriteLine($"to show all {s} press 3");
            Console.WriteLine($"to update {s} press 4");
            Console.WriteLine($"to delete {s} press 5");
            Console.WriteLine("to back press 0");
            if (!(int.TryParse(Console.ReadLine(), out selection))) selection = -1;
            return selection;
        }

        public static void SubMenu<T>(string item, ICrud<T> crud, CreateUpdateDel createDel, CreateUpdateDel updateDel)
        {
            int select = PrintSubMenu(item);
            while (select != 0)
            {
                switch (select)
                {
                    case 1:
                        createDel();
                        break;
                    case 2:
                        Read(crud);
                        break;
                    case 3:
                        ReadAll(crud);
                        break;
                    case 4:
                        updateDel();
                        break;
                    case 5:
                        Delete(crud);
                        break;
                    default:
                        Console.WriteLine("בחירה שגויה");
                        break;
                }
                select = PrintSubMenu(item); //הדפסת תת תפריט
            }
        }

        
        private static void UpdateProduct()
        {
            try
            {
                Console.WriteLine("press code of product");
                int code;
                if (!(int.TryParse(Console.ReadLine(), out code))) code = -1;
                Console.WriteLine(s_dal.Product.Read(code));
                Product product = AskProducts(code);
                s_dal.Product.Update(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        private static void AddProducts()
        {
            Product product = AskProducts();
            int code = s_dal.Product.Create(product);
            product = product with { Barcode = code };
            Console.WriteLine("create");
            Console.WriteLine(product);

        }
        private static Product AskProducts(int code = 0)
        {
            int Barcode;
            string productName;
            Category category;
            double price;
            int quantityStock;
            int select;
            Console.WriteLine("press ProductName");
            productName = Console.ReadLine();
            Console.WriteLine("category:  Milky press1, Cleanliness press2, Sweets press 3, Breads press 4, FruitVegetables press 5 ");
            if (!(int.TryParse(Console.ReadLine(), out select))) select = -1;
            switch (select)
            {
                case 1:
                    category = Category.Milky;
                    break;
                case 2:
                    category = Category.Cleanliness;
                    break;
                case 3:
                    category = Category.Sweets;
                    break;
                case 4:
                    category = Category.Breads;
                    break;
                case 5:
                    category = Category.FruitVegetables;
                    break;
                default:
                    category = Category.Milky;
                    break;
            }
            Console.WriteLine("press price");
            if (!(double.TryParse(Console.ReadLine(), out price))) price = -1;
            Console.WriteLine("press quantityStock ");
            if (!(int.TryParse(Console.ReadLine(), out quantityStock))) quantityStock = -1;
            Product product = new Product(code, productName, category, price, quantityStock);
            return product;
        }

      
        private static void UpdateCustomer()
        {
            try
            {
                Console.WriteLine("press code of Customer");
                int code;
                if (!(int.TryParse(Console.ReadLine(), out code))) code = -1;
                Console.WriteLine(s_dal.Customer.Read(code));
                Customer customer = AskCustomer(code);
                s_dal.Customer.Update(customer);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

        }
        private static void AddCustomer()
        {
            Customer customer = AskCustomer();
            int code = s_dal.Customer.Create(customer);
            customer = customer with { Id = code };
            Console.WriteLine("create");
            Console.WriteLine(customer);
        }
        private static Customer AskCustomer(int code = 0)
        {
            int Id;
            string Name;
            int Phone;
            string Address;
            Console.WriteLine("press id");
            if (!(int.TryParse(Console.ReadLine(), out Id))) Id = -1;
            Console.WriteLine("press phone");
            if (!(int.TryParse(Console.ReadLine(), out Phone))) Phone = -1;
            Console.WriteLine("press customer name");
            Name = Console.ReadLine();
            Console.WriteLine("press customer address");
            Address = Console.ReadLine();
            Customer customer = new Customer(Id, Name, Phone, Address);
            return customer;
        }

        
        private static void UpdateSale()
        {
            try
            {
                Console.WriteLine("press code of Sale");
                int code;
                if (!(int.TryParse(Console.ReadLine(), out code))) code = -1;
                Console.WriteLine(s_dal.Sale.Read(code));
                Sale sale = AskSale(code);
                s_dal.Sale.Update(sale);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

        }
        private static void AddSale()
        {
            Sale sale = AskSale();
            int code = s_dal.Sale.Create(sale);
            sale = sale with { BarcodeSale = code };
            Console.WriteLine("create");
            Console.WriteLine(sale);
        }
        private static Sale AskSale(int code = 0)
        {
            int BarcodeSale;
            int ProductId;
            int RequiredItems;
            int TotalPrice;
            bool IsCustomersClub;
            DateTime BeginingSale;
            DateTime EndSale;
            int day;
            int select;
            Console.WriteLine("press ProductId");
            if (!(int.TryParse(Console.ReadLine(), out ProductId))) ProductId = -1;
            Console.WriteLine("press RequiredItems");
            if (!(int.TryParse(Console.ReadLine(), out RequiredItems))) RequiredItems = -1;
            Console.WriteLine("press TotalPrice");
            if (!(int.TryParse(Console.ReadLine(), out TotalPrice))) TotalPrice = -1;
            Console.WriteLine("IsCustomersClub? 0/1");
            select = int.Parse(Console.ReadLine());
            switch (select)
            {
                case 0:
                    IsCustomersClub = true;
                    break;
                case 1:
                    IsCustomersClub = false;
                    break;
                default:
                    IsCustomersClub = false;
                    break;
            }
            Console.WriteLine("how many days fron today the sale begin");
            if (!int.TryParse(Console.ReadLine(), out day)) day = 0;
            BeginingSale = DateTime.Now.AddDays(day);
            Console.WriteLine("how many days fron the begining the sale finish");
            if (!int.TryParse(Console.ReadLine(), out day)) day = 0;
            EndSale = BeginingSale.AddDays(day);
            Sale s = new Sale(0, ProductId, RequiredItems, TotalPrice, IsCustomersClub, BeginingSale, EndSale);
            return s;
        }

        private static void Read<T>(ICrud<T> crud)
        {
            try
            {
                Console.WriteLine("enter code");
                int code = int.Parse(Console.ReadLine());
                Console.WriteLine(crud.Read(code));
            }
            catch (Exception e)
            {
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        private static void ReadAll<T>(ICrud<T> crud)
        {
            foreach (var item in crud.ReadAll())
            {
                Console.WriteLine(item);
            }
        }
        private static void Delete<T>(ICrud<T> crud)
        {
            try
            {
                Console.WriteLine("enter code");
                int code = int.Parse(Console.ReadLine());
                crud.Delete(code);
            }
            catch (Exception e)
            {
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        //static readonly BlApi.IBl s_bl = BlApi.Factory.Get();

        static void Main(string[] args)
        {
            Console.WriteLine("Would you like to initialize data? (yes/no)");
            string initResponse = Console.ReadLine()?.ToLower();

            if (initResponse == "yes")
            {
                Initialization.Initialize();
            }
            int select = printMainMenue();
            try
            {
                while (select != 0)
                {
                    switch (select)
                    {
                        case 1:
                            Console.WriteLine("product");
                            SubMenu("product",s_dal.Product, AddProducts, UpdateProduct);
                            break;
                        case 2:
                            Console.WriteLine("customer");
                            SubMenu("customer", s_dal.Customer, AddCustomer, UpdateCustomer);
                            break;
                        case 3:
                            Console.WriteLine("sale");
                            SubMenu("sale", s_dal.Sale, AddSale, UpdateSale);
                            break;
                        case 4:
                            Tools.LogManager.DeleteLog();
                            break;
                        default:
                            Console.WriteLine("worg selection ,try again");
                            break;
                    }
                    select = printMainMenue();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();


            ///  catch איך יודעים איזה סוג שגיאה לתפוס מה צריך לכתוב בו
            ///  read,readall,create האם זה נכון?
            /// פונקציה מחיקה log האם זה נכון
            /// האם לעשות גם תיקיות לפי השנים
        }
    }

}


