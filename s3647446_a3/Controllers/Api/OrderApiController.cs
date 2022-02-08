using Microsoft.AspNetCore.Mvc;
using model;
using services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace s3647446_a3.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderApiController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderApiController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/<OrderApiController>
        [HttpGet]
        public List<OrderView> GetOrderList()
        {
            var orders = _orderService.GetOrederList();
            return orders;
        }

        // POST api/<OrderApiController>
        [HttpPost]
        public bool CreateOrder([FromBody] CreateOrder createOrder)
        {
            var result = _orderService.CreateOrder(createOrder);
            return result;
        }
    }
}
