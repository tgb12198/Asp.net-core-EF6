using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.Models
{
    public class OrderPruducts
    {
        public int OrderID { get; set; }

        public virtual Orders Orders { get; set; }

        public int PruductID { get; set; }

        public virtual Products Products { get; set; }

        public int Quantity { get; set; }
    }
}
