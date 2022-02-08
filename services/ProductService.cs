using database;
using database.Models;
using Microsoft.EntityFrameworkCore;
using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    public class ProductService : IProductService
    {
        private readonly CoreContext _context;

        public ProductService(CoreContext context)
        {
            _context = context;
        }

        public bool AddProduct(Products product)
        {
            if (product.ProductID > 0)// add
            {
                return UpdateProduct(product);
            }
            else//edit
            {
                _context.Add(product);
                return _context.SaveChanges() > 0;
            }
        }

        public Products GetProductById(int id)
        {
            var product = _context.Products.Where(o => o.ProductID == id).FirstOrDefault();
            return product ?? new Products();
        }

        public List<Products> GetProductList(Search search, out int totalCount)
        {
            var list = new List<Products>();
            if (search.IsOrdered == 0)
            {
                var productIds = _context.OrderPruducts.Select(o => o.PruductID).ToList();
                list = _context.Products.Where(o => !productIds.Contains(o.ProductID)).ToList();
            }
            else if (search.IsOrdered == 1)
            {
                var productIds = _context.OrderPruducts.Select(o => o.PruductID).ToList();
                list = _context.Products.Where(o => productIds.Contains(o.ProductID)).ToList();
            }
            else
            {
                list = _context.Products.Skip(search.PageIndex - 1).Take(search.PageSize).ToList();
            }

            totalCount = list.Count();
            return list;
        }

        public List<SelectModel> GetProducts(string query = "")
        {
            var list = new List<SelectModel>();
            var products = _context.Products.ToList();
            if (!string.IsNullOrEmpty(query))
            {
                products = products.Where(m => m.Name.Contains(query)).ToList();
            }
            products.ForEach(p => list.Add(new SelectModel
            {
                value = p.ProductID,
                label = p.Name
            }));
            return list;
        }

        public bool UpdateProduct(Products product)
        {
            var old = _context.Products.Where(o => o.ProductID == product.ProductID).FirstOrDefault();
            if (old != null)
            {
                old.Name = product.Name;
                old.Price = product.Price;
            }
            _context.Entry(product);
            return _context.SaveChanges() > 0;
        }
    }
}
