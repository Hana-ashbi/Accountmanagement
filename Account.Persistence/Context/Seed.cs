using Account.Domain.Entities;
using System.Threading.Tasks;

namespace Account.Persistence.Context
{
    public static class Seed
    {
        public static async Task<int> Start(AccountRepo context)
        {
            return await context.CreateUser(new User { Id = "1", Name = "Hana", Surname = "Ahmed" });
        }
    }
}
