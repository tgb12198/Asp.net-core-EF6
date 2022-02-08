using database;
using database.Models;
using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace services
{
    public class OrderService : IOrderService
    {
        private readonly CoreContext _context;

        public OrderService(CoreContext context)
        {
            _context = context;
        }

        public bool CreateOrder(CreateOrder createOrder)
        {
            var order = new Orders();
            order.CustomerName= createOrder.CustomerName;
            order.OrderDate= DateTime.Now;
            order.DeliveryAddress= createOrder.DeliveryAddress;
            order.DeliveryDate= Convert.ToDateTime(createOrder.DeliveryDate);
            var ops = new List<OrderPruducts>();
            foreach (var item in createOrder.Products)
            {
                var orderPruducts = new OrderPruducts();
                orderPruducts.PruductID = item.ProductID;
                orderPruducts.Quantity = item.Quantity;
               ops.Add(orderPruducts);
            }
            order.OrderPruducts = ops;
            _context.Orders.Add(order);
            return _context.SaveChanges() > 0;
        }

        public List<OrderView> GetOrederList()
        {
            var orders = new List<OrderView>();
            var list = _context.Orders.Include(o=>o.OrderPruducts).ToList();
            list.ForEach(o =>orders.Add(new OrderView() { 
                CustomerName = o.CustomerName,
                OrderID = o.OrderID,
                OrderDate=o.OrderDate.ToString("yyyy-MM-dd"),
                DeliveryDate=o.DeliveryDate.ToString("yyyy-MM-dd"),
                DeliveryAddress=o.DeliveryAddress,
                ProductCount = o.OrderPruducts.Sum(o=>o.Quantity)
            }));
            return orders;
        }
    }
}
