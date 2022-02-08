using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.Models
{
    public class OrderPruducts
    {
        public OrderPruducts()
        {
            Orders = new Orders();
            Products = new Products();
        }
        public int OrderID { get; set; }

        public Orders Orders { get; set; }

        public int PruductID { get; set; }

        public Products Products { get; set; }

        public int Quantity { get; set; }
    }
}
