using CarRepairShop.Application.Car.Interfaces;
using CarRepairShop.Application.Car.Requests;
using CarRepairShop.Application.Car.ViewModels;
using CarRepairShop.Domain.Interfaces;

namespace CarRepairShop.Application.Car.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public Task<IEnumerable<CarViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CarViewModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Add(CarAddRequest request)
        {
            throw new NotImplementedException();
        }

        public Task Update(CarUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task Delete(CarDeleteRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
