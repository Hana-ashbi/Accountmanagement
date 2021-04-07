using Account.Domain.Common;
using SharedLib.Model;
using System.Collections.Generic;

namespace Account.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<UserAccount> Accounts { get; set; }
    }


    public class UserInfo : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<AccountTransaction> Accounts { get; set; }
    }
}
