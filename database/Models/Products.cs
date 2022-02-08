using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public virtual ICollection<OrderPruducts> OrderPruducts { get; set; }

        public Products()
        {
            OrderPruducts = new List<OrderPruducts>();
        }
    }
}
