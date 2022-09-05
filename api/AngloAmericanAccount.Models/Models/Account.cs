using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngloAmerican.Account.Api.Data.Models
{
    public class Account
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AccountType { get; set; }
        public decimal AccountBalance { get; set; }
        public string AccountAddress { get; set; }
    }
}
