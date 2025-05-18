
using System.ComponentModel.DataAnnotations;

namespace DO;

public record Customer(int Id,string Name,int Phone,string? Address)
{

    public Customer():this(123,"aaa",563,"bbb")
    {

    }
}
