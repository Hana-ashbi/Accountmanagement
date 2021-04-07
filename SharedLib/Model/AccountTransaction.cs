using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib.Model
{
    public class AccountTransaction
    {
        public string UserId { get; set; }
        public string AccountId { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }

        public decimal Balance { get; set; }
    }
    public class Transaction
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string UserId { get; set; }
        public DateTime Created_At { get; set; }
        public decimal Amount { get; set; }
    }
}
