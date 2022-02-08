using database.Models;
using Microsoft.AspNetCore.Mvc;
using model;
using services;

namespace s3647446_a3.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetProductList([FromBody] Search search)
        {
            int totalCount = 0;
            var result = _productService.GetProductList(search, out totalCount);
            return Json(new { data = result, totalCount = totalCount });
        }

        public IActionResult GetProductById(int id)
        {
            var result = _productService.GetProductById(id);
            return Json(new { data = result });
        }

        public IActionResult SaveProduct([FromBody] Products products)
        {
            if (string.IsNullOrEmpty(products.Name))
            {
                return Json(new { message = "Product Name must be input" });
            }
            if (products.Price == 0)
            {
                return Json(new { message = "Product Price can't zero" });
            }
            var result = _productService.AddProduct(products);
            return Json(new { data = result ,message="success"});
        }

        public IActionResult GetProducts(string query="")
        {
            var result = _productService.GetProducts(query);
            return Json(result);
        }
    }
}
