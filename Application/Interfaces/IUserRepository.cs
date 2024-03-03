using Domain.Models.User;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        public Task RecordUser(User user);
        public Task UpdateUser(User user);
        public Task DeleteUser(string id);
    }
}
