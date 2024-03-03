using Application.Interfaces;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Querys
{
    public class UserQuerys : IUserQuerys
    {
        private readonly ApplicationDBContext _context;

        public UserQuerys(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAsync()
        {
            var users = new List<User>();
            users.AddRange(_context.Users);
            return users;
        }
        public async Task<User> GetByIdAsync(User id) => await _context.Users.SingleOrDefaultAsync(c => c.Id.Equals(id));


    }
}
