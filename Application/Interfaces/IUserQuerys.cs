using Domain.Models.User;

namespace Application.Interfaces
{
    public interface IUserQuerys
    {
        Task<User> GetByIdAsync(User id);
        Task<List<User>> GetAsync();

    }
}
