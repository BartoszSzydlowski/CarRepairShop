using CarRepairShop.Domain.Models;

namespace CarRepairShop.Domain.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAll();

        Task<Car> Get(int id);

        Task Add(Car car);

        Task Update(Car car);

        Task Delete(int id);
    }
}