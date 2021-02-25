using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace productEntity
{
    public class Product
    {
       
        public int pid { get; set; }
        public string pname { get; set; }
        public int price { get; set; }

        public Product()
        {

        }
        public Product(int id,string name,int price)
        {
            this.pid = id;
            this.pname = name;
            this.price = price;
        }
    }
}
