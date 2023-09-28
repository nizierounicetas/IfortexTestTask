using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementation
{
    public class ConditionsUserService : IUserService
    {
        private ApplicationDbContext dbContext;

        public ConditionsUserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<User> GetUser()
        {
            return dbContext.Users.Include(u => u.Orders).OrderByDescending(u => u.Orders.Count).FirstOrDefaultAsync();
        }

        public Task<List<User>> GetUsers()
        {
            return dbContext.Users.Where(u => u.Status == Enums.UserStatus.Inactive).ToListAsync();
        }
    }
}
