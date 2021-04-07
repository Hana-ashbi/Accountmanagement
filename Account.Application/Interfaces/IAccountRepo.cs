using Account.Domain.Entities;
using System.Threading.Tasks;

namespace Account.Application.interfaces
{
    public interface IAccountRepo
    {
        Task<User> GetUserByID(string ID);
        Task<int> SaveUser(User user);
    }
}
