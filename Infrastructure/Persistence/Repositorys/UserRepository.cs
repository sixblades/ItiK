using Application.Interfaces;
using Domain.Models.User;

namespace Infrastructure.Persistence.Repositorys
{
    internal class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _contex;

        public UserRepository(ApplicationDBContext context)
        {
            _contex = context ?? throw new ArgumentException(nameof(context));
        }

        public async Task RecordUser(User user) => await _contex.Users.AddAsync(user);


        public Task UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(string id)
        {
            throw new NotImplementedException();
        }
    }
}
