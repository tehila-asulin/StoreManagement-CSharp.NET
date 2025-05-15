
namespace DO;
//המוצרים הקיימים בחנות

public record Product(
    int Barcode,
    string ProductName,
    Category Category,
    double Price,
    int QuantityStock)
{
    public Product():this(000,"bbb",Category.Breads,0.00,00 )
    {
        
    }
}

