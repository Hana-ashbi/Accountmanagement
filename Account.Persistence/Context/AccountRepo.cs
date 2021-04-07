using Account.Application.interfaces;
using Account.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Persistence.Context
{
    public class AccountRepo : DbContext, IAccountRepo
    {
        public AccountRepo(DbContextOptions<AccountRepo> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAccount> Accounts { get; set; }

        public async Task<User> GetUserByID(string ID)
        {
            return await Users.Include(x => x.Accounts).Where(x => x.Id == ID).FirstOrDefaultAsync();
        }

        public async Task<int> SaveUser(User user)
        {
            Entry(user).State = EntityState.Modified;
            return await base.SaveChangesAsync();
        }

        public async Task<int> CreateUser(User user)
        {
            Users.Add(user);
            return await base.SaveChangesAsync();
        }
    }
}
