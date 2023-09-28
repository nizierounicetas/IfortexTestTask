using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementation
{
    public class ConditionsOrderService : IOrderService
    {
        private ApplicationDbContext dbContext;

        public ConditionsOrderService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Order> GetOrder()
        {
            return dbContext.Orders.OrderByDescending(o => o.Price).FirstOrDefaultAsync();
        }

        public Task<List<Order>> GetOrders()
        {
            return dbContext.Orders.Where(o => o.Quantity > 10).ToListAsync();
        }
    }
}
