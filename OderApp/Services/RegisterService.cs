using OderApp.Models;
using OderApp.Repositories;
using OderApp.Helper;

using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Linq;
using System.Diagnostics.Metrics;

namespace OderApp.Services
{
    public interface RegisterService
    {

        public Task<Result<Account>> Register(string email, string password, int decentralization);


    }
    public class RegisterServiceImpl : RegisterService
    {
        private readonly IAccountRepository _accountRepository;

        private readonly string[] specialCharacter = new[] { "$", "@", "#" };
        public RegisterServiceImpl(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;

        }

        public async Task<Result<Account>> Register(string email, string password, int decentralization)
        {
            //Validate 
            if (email != null && password != null && decentralization != null)
            {
                // Validate email
                if (!IsValidEmail(email))
                {
                    Console.WriteLine("Email Invalid");
                    return new Result<Account>(HttpStatusCode.Forbidden, null, "Email is in valid");
                }

                // Validate password
                if (!IsValidPassword(password))
                {
                    Console.WriteLine("Password Invalid");
                    return new Result<Account>(HttpStatusCode.Forbidden, null, "Password is in valid");
                }

                await _accountRepository.addAccount(email: email, password: password, decentralization: decentralization);

                return new Result<Account>(HttpStatusCode.OK, new Account(email, password, decentralization), "Successfully Register");

            }

            return new Result<Account>(HttpStatusCode.Forbidden, null, "Missing Information");
        }

        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if(trimmedEmail.Length < 6)
            {
                return false;
            }

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        bool IsValidPassword(string password)
        {
            var trimmedPassword = password.Trim();
            int numberOfUpperCase = 0;
            int numberOfLowerCase = 0;
            int numberOfDigit = 0;
            bool isSpecialCharacter = false;

            if (trimmedPassword.Length < 8)
            {
                return false;
            }

            for (int i = 0; i < trimmedPassword.Length; i++)
            {
                for (int j = 0; j < specialCharacter.Length; j++)
                {
                    if (trimmedPassword.Contains(specialCharacter[j]))
                    {
                        isSpecialCharacter = true;
                    }
                }
                if (char.IsUpper(trimmedPassword[i]))
                {
                    numberOfUpperCase++;
                }
                if (char.IsLower(trimmedPassword[i]))
                {
                    numberOfLowerCase++;
                }
                if (char.IsDigit(trimmedPassword[i]))
                {
                    numberOfDigit++;
                }
            }

            if (isSpecialCharacter == false) return false;
            if (numberOfUpperCase < 2) return false;
            if (numberOfLowerCase < 4) return false;
            if (numberOfDigit < 3) return false;
            return true;
        }

    }
}