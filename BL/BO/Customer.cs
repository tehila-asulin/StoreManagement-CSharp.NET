using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Customer
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string? Address { get; set; }


        public Customer(int id,string name,int phone,string address) 
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Address = address;

        }
        public Customer() { }

    }
}
