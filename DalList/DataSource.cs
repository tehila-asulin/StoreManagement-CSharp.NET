

using DO;

namespace Dal;

internal static class DataSource
{
    internal static List<Product> products = new List<Product>();
    internal static List<Sale> sales = new List<Sale>();
    internal static List<Customer> customers = new List<Customer>();

    internal static class Config
    {
        internal const int MinCodeProduct= 1000;
        internal const int MinCodeSale = 10;

        private static int CodeProduct= MinCodeProduct;
        private static int CodeSale = MinCodeSale;

        public static int GetCodeProduct 
        { 
            get {
                return CodeProduct += 100;
            }
           
        }
        public static int GetCodeSale
        {
            get
            {

                return CodeSale += 10;
            }
        }


    }


}
