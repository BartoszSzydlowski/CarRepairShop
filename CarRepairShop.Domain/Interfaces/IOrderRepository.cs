using CarRepairShop.Domain.Models;

namespace CarRepairShop.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();

        Task<Order> Get(int id);

        Task Add(Order order);

        Task Update(Order order);

        Task Delete(int id);
    }
}