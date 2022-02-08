using database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Products>().HasData(
                    new Products() { ProductID = 1, Name = "beef", Price = 65m },
                    new Products() { ProductID = 2, Name = "chicken", Price = 30.0m },
                    new Products() { ProductID = 3, Name = "apple", Price = 5.5m },
                    new Products() { ProductID = 4, Name = "orange", Price = 10.9m }
            );

           /* var orderPruducts_1 = new List<OrderPruducts>();
            orderPruducts_1.Add(new OrderPruducts() { OrderID = 1, PruductID = 1, Quantity = 10 });
            orderPruducts_1.Add(new OrderPruducts() { OrderID = 1, PruductID = 2, Quantity = 15 });

            var orderPruducts_2 = new List<OrderPruducts>();
            orderPruducts_2.Add(new OrderPruducts() { OrderID = 2, PruductID = 2, Quantity = 18 });
            orderPruducts_2.Add(new OrderPruducts() { OrderID = 2, PruductID = 4, Quantity = 100 });

            modelBuilder.Entity<Orders>().HasData(
             new Orders() { OrderID = 1, CustomerName ="Tom",DeliveryDate=DateTime.Now,DeliveryAddress="Xingfu Street 80 No.", OrderPruducts = orderPruducts_1 },
             new Orders() { OrderID = 2, CustomerName ="Lucy",DeliveryDate=DateTime.Now,DeliveryAddress="Center Street 66 No.", OrderPruducts = orderPruducts_2 }
            );*/
        }
    }
}
