using OderApp.Models;
using OderApp.Repositories;
using OderApp.Helper;

using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace OderApp.Services
{
  public  interface LoginService
    {
        public Task<Result<Account>> Login(string email, string passWord);
        

    }
    public class LoginServiceImpl : LoginService
    {
        private readonly IAccountRepository _accountRepository;
        public LoginServiceImpl(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;

        }
        public async Task<Result<Account>> Login(string email, string passWord)
        {
            //Validate
            if(email == null || passWord == null) {

                return new Result<Account>(HttpStatusCode.Forbidden, null , "Email or passWord is in valid");
            }
          
            var result = await _accountRepository.getAccount(email, passWord);
            Account? account = result?.ConvertToAccount();
             if(account != null)
            {
                return new  Result<Account>(HttpStatusCode.OK, account, "");
            }
            return new Result<Account>(HttpStatusCode.Unauthorized, null, "Email or passWord is in valid");


        }

    }
}
