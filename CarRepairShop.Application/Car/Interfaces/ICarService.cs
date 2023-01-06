using CarRepairShop.Application.Car.Requests;
using CarRepairShop.Application.Car.ViewModels;

namespace CarRepairShop.Application.Car.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarViewModel>> GetAll();

        Task<CarViewModel> Get(int id);

        Task Add(CarAddRequest request);

        Task Update(CarUpdateRequest request);

        Task Delete(CarDeleteRequest request);
    }
}
