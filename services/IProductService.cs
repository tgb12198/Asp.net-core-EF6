using database.Models;
using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    public interface IProductService
    {
        List<Products> GetProductList(Search search, out int totalCount);
        Products GetProductById(int id);
        bool AddProduct(Products product);
        bool UpdateProduct(Products product);
        List<SelectModel> GetProducts(string query = "");
    }
}
