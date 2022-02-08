using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class OrderView
    {
        public int OrderID { get; set; }

        public string OrderDate { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string DeliveryAddress { get; set; } = string.Empty;

        public string DeliveryDate { get; set; }

        public int ProductCount { get; set; }
    }
}
