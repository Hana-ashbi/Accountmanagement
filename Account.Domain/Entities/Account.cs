using Account.Domain.Common;
using SharedLib.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Domain.Entities
{
    public enum AccountStatus
    {
        ACTIVE,
        INACTIVE
    };

    public class UserAccount : BaseEntity
    {
        public string UserId { get; set; }
        public AccountStatus Status { get; set; }
        public DateTime Created_At { get; set; }

        public bool ShouldCreateInitialTransaction(decimal initialCredit)
        {
            if (initialCredit == 0)
            {
                return false;
            }

            return true;
        }
    }
}
