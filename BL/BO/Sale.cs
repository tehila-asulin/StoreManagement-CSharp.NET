using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Sale
    {
        public int BarcodeSale { get; init; }
        public int ProductId { get; init; }
        public int RequiredItems { get; set; }
        public int TotalPrice { get; set; }
        public bool IsCustomersClub { get; set; }
        public DateTime BeginingSale { get; set; }
        public DateTime EndSale { get; set; }


        public Sale(int barcodeSale, int productId, int requiredItems, int totalPrice, bool isCustomersClub, DateTime beginingSale, DateTime endSale)
        {
            this.BarcodeSale = barcodeSale; 
            this.ProductId = productId;
            this.RequiredItems = requiredItems;
            this.TotalPrice = totalPrice;
            this.IsCustomersClub = isCustomersClub;
            this.BeginingSale = beginingSale;
            this.EndSale = endSale;

        }
        public Sale() { }



    }
}
