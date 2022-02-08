using database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public  class CreateOrder
    {
        public string CustomerName { get; set; } = string.Empty;

        public string DeliveryAddress { get; set; } = string.Empty;

        public string DeliveryDate { get; set; }

        public List<Product> Products { get; set; }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
