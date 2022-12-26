using OderApp.DataSource.Entities;
using OderApp.Models;
using CategoryEntity = OderApp.DataSource.Entities.Category;
using CategoryModel = OderApp.Models.Category;
using RoleEntity = OderApp.DataSource.Entities.Role;
using RoleModel = OderApp.Models.Role;

namespace OderApp.Helper
{
    public static class ConvertObject
    {
        public static Account ConvertToAccount(this AccountEntity accountEntity)
        {
            return new Account(
                accountEntity.Email,
                accountEntity.Password,
                accountEntity.Role
            );
        }

        public static Configuration ConvertToConfiguration(this ConfigurationEntity configurationEntity)
        {
            return new Configuration(
                configurationEntity.Policy,
                configurationEntity.Rules,
                configurationEntity.Address
            );
        }

        public static Item ConvertToItemModel(this ItemEntity itemEntity)
        {
            return new Item(
                itemEntity.Id,
                itemEntity.Name,
                itemEntity.Quantity,
                itemEntity.Price,
                itemEntity.Category
            );
        }

        public static ItemEntity ConvertToItemEntity(this Item item)
        {
            return new ItemEntity(
                item.Id,
                item.Name,
                item.Quantity,
                item.Price,
                item.Category
            );
        }

        public static User ConvertToUserModel(this UserEntity userEntity)
        {
            return new User(
                userEntity.Id,
                userEntity.Name,
                userEntity.Email,
                userEntity.Role);
        }

        public static UserEntity ConvertToUserEntity(this User user)
        {
            return new UserEntity(
                user.Id,
                user.Name,
                user.Email,
                user.Role
            );
        }
    }
}