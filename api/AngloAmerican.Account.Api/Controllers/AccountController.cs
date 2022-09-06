using AngloAmerican.Account.Services;
using AngloAmerican.Account.Services.Definition.Defitinitions;
using AngloAmerican.Account.Services.Definitions.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AngloAmerican.Account.Api.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAddressRepository _IAddressRepository;
        public AccountController(IAccountRepository accountRepository, IAddressRepository addressRepository)
        {
            this._accountRepository = accountRepository;
            this._IAddressRepository = addressRepository;
        }

          /* TODO
            - Create a REST API to get all the accounts
                For every account you need to use AddressService to load an address (City and PostCode)
                You can use AccountResponse class
         */

        [HttpGet]
        public IEnumerable<AccountResponse> Get()
        {
            var accounts = _accountRepository.GetAllAccounts();
            List<AccountResponse> accountsData = new List<AccountResponse>();
            foreach (var account in accounts)
            {
                //Get account Address
                var address = this._IAddressRepository.GetAddress();

                //Get Account Type Id
                var accountTypeId = GetAccountType(account.Balance);

                AccountResponse accountResponse = new AccountResponse() { FirstName = account.FirstName, LastName = account.LastName, Balance = account.Balance, Address=address, TypeId=accountTypeId };
                accountsData.Add(accountResponse);
            }
            return accountsData;
        }

        private int GetAccountType(int balance)
        {
            int accountTypeId = 0;
            if (balance < 5000)
                accountTypeId = 1;
            else if (balance >= 5000 && balance < 10000)
                accountTypeId = 2;
            else if (balance >= 10000)
                accountTypeId = 3;

            return accountTypeId;
        }

        /* 
          - Create a REST API to save an account 
                Call BalanceChecker to verify if you can save
                You can use AccountRequest class as a payload
         */

        [HttpPost]
        public IActionResult Post([FromBody] AccountModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var res = _accountRepository.Add(model);
                    if (res.Exception == null)
                    {
                        return CreatedAtAction("Get", new { id = res.Id }, model);
                    }
                    else
                    {
                        var exception = new Exception(res.Exception.ToString());
                        return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                    }
                }
                catch (Exception ex)
                {

                    var result = StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                    return result;
                }
            
            }
            return BadRequest(ModelState);

        }
    }
}