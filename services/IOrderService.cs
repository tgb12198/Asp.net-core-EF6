using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    public interface IOrderService
    {
        List<OrderView> GetOrederList();

        bool CreateOrder(CreateOrder createOrder);
    }
}
