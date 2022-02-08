using database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database
{
    public class DatabaseInitializer
    {
        public  void Seed(CoreContext context)
        {
            GetProducts().ForEach(u => context.Products.Add(u));
            GetOrders().ForEach(u => context.Orders.Add(u));
        }

        private static List<Products> GetProducts()
        {
            var _list = new List<Products>();
            _list.Add(new Products() { ProductID = 1, Name = "beef", Price = 65m });
            _list.Add(new Products() { ProductID = 2, Name = "chicken", Price = 30.0m });
            _list.Add(new Products() { ProductID = 3, Name = "apple", Price = 5.5m });
            _list.Add(new Products() { ProductID = 4, Name = "orange", Price = 10.9m });
            return _list;
        }



        private static List<Orders> GetOrders()
        {
            var _list = new List<Orders>();
            var orderPruducts_1 = new List<OrderPruducts>();
            orderPruducts_1.Add(new OrderPruducts() { OrderID = 1, PruductID = 1, Quantity = 10 });
            orderPruducts_1.Add(new OrderPruducts() { OrderID = 1, PruductID = 2, Quantity = 15 });
            var order1 = new Orders()
            {
                OrderID = 1,
                CustomerName = "Tom",
                DeliveryDate = DateTime.Now,
                DeliveryAddress = "XingFu Street 88 No.",
                OrderPruducts = orderPruducts_1,
            };

            var orderPruducts_2 = new List<OrderPruducts>();
            orderPruducts_2.Add(new OrderPruducts() { OrderID = 2, PruductID = 2, Quantity = 18 });
            orderPruducts_2.Add(new OrderPruducts() { OrderID = 2, PruductID = 4, Quantity = 100 });
            var order2 = new Orders()
            {
                OrderID = 1,
                CustomerName = "Lucy",
                DeliveryDate = DateTime.Now,
                DeliveryAddress = "Central Street 66 No.",
                OrderPruducts = orderPruducts_1,
            };
            _list.Add(order2);
            return _list;
        }
    }
}
