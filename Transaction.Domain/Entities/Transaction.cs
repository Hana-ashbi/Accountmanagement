using System;
using System.Collections.Generic;
using System.Text;
using Transaction.Domain.Common;

namespace Transaction.Domain.Entities
{

    public class AccountTransaction : BaseEntity
    {
        public string UserId { get; set; }
        public string AccountId { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
    public class Transaction : BaseEntity
    {
        public string AccountId { get; set; }
        public string UserId { get; set; }
        public DateTime Created_At { get; set; }
        public decimal Amount { get; set; }
    }
}
