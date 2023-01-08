using CarRepairShop.API.Helpers;
using CarRepairShop.Application.Order.Interfaces;

namespace CarRepairShop.API.Controllers
{
    public class CarsController : RouteBaseController
    {
        private readonly IOrderService _service;

        public CarsController(IOrderService service)
        {
            _service = service;
        }
    }
}
