using OderApp.DataSource.Entities;
using OderApp.Models;
namespace OderApp.Helper
{
    public static class ConvertObject
    {
        public static Account ConvertToAccount(this AccountEntity accountEntity)
        {
            return new Account(accountEntity.Email, accountEntity.Password, accountEntity.Decentralization);

        }
    }
}
