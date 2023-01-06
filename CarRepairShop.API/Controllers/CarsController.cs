using CarRepairShop.API.Helpers;
using CarRepairShop.Application.Car.Interfaces;

namespace CarRepairShop.API.Controllers
{
    public class CarsController : RouteBaseController
    {
        private readonly ICarService _service;

        public CarsController(ICarService service)
        {
            _service = service;
        }
    }
}
