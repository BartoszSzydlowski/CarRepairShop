using CarRepairShop.Domain.Interfaces;
using CarRepairShop.Domain.Models;

namespace CarRepairShop.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Add(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
