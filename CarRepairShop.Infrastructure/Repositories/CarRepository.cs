using CarRepairShop.Domain.Interfaces;
using CarRepairShop.Domain.Models;

namespace CarRepairShop.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Car> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Add(Car car)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Car car)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}