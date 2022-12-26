using OderApp.Models;
using OderApp.Repositories;
using OderApp.Helper;

using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Linq;
using System.Diagnostics.Metrics;
using System.Data;
using OderApp.DataSource.Entities;
using Role = OderApp.Models.Role;

namespace OderApp.Services
{
    public interface RegisterService
    {

        public Task<Result<User>> Register(string name, string email, string password, int role);


    }
    public class RegisterServiceImpl : RegisterService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;

        private readonly string[] specialCharacter = new[] { "$", "@", "#" };
        public RegisterServiceImpl(IAccountRepository accountRepository, IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;

        }

        public async Task<Result<User>> Register(string name, string email, string password, int role)
        {
            //Validate 
            if (name !=  null && email != null && password != null && role != null)
            {
                // Validate email
                if (!IsValidEmail(email))
                {
                    Console.WriteLine("Email Invalid");
                    return new Result<User>(HttpStatusCode.Forbidden, null, "Email is in valid");
                }

                // Validate password
                if (!IsValidPassword(password))
                {
                    Console.WriteLine("Password Invalid");
                    return new Result<User>(HttpStatusCode.Forbidden, null, "Password is in valid");
                }

                await _userRepository.AddUser(new UserEntity(name:name, email: email, role: role));

                //for testing
                return new Result<User>(HttpStatusCode.OK, new User(name ,email, role), "Successfully Register");

            }

            return new Result<User>(HttpStatusCode.Forbidden, null, "Missing Information");
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