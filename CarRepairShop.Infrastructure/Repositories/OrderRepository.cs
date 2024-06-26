﻿using CarRepairShop.Domain.Enums;
using CarRepairShop.Domain.Interfaces;
using CarRepairShop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShop.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context) =>
            _context = context;

        public async Task<IEnumerable<Order>> GetAll()
            => await _context.Orders.ToListAsync();

        public async Task<Order> Get(int id) =>
            await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);

        public async Task Add(Order order)
        {
            order.OrderStatus = (OrderStatus)1;
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            _context.Orders.Remove(entity!);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetUserOrders(string userId)
            => await _context.Orders.Where(x => x.CreatedBy == userId).ToListAsync();
    }
}