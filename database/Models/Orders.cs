using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.Models
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; } = string.Empty;

        [StringLength(200)]
        public string DeliveryAddress { get; set; } = string.Empty;

        public DateTime DeliveryDate { get; set; }

        public virtual ICollection<OrderPruducts> OrderPruducts { get; set; }

        public Orders()
        {
            OrderPruducts = new List<OrderPruducts>();
        }
    }
}
