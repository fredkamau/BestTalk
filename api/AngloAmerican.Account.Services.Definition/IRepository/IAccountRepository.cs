using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AngloAmerican.Account.Services.Definition.Defitinitions
{
    public interface IAccountRepository
    {
        List<AccountModel> GetAllAccounts();
        Task Add(AccountModel accountModel);
    }
}
