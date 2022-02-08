using Microsoft.AspNetCore.Mvc;
using model;
using Newtonsoft.Json;
using s3647446_a3.HttpUtils;

namespace s3647446_a3.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetOrderList()
        {
            var result = HttpHelper.HttpGet("https://localhost:7096/api/orderapi/getorderlist");
            var orders = JsonConvert.DeserializeObject<List<OrderView>>(result);
            return Json(orders);
        }

        public IActionResult CreateOrder([FromBody] CreateOrder create)
        {
            var result = HttpHelper.HttpPost("https://localhost:7096/api/orderapi/CreateOrder", JsonConvert.SerializeObject(create));
            return Json(new {message="success"});
        }
    }
}
