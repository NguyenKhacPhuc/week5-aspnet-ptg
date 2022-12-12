using OderApp.DataSource.Entities;
using OderApp.Models;
using CatagoryEntity = OderApp.DataSource.Entities.Catagory;
using CatagoryModel = OderApp.Models.Catagory;
using RoleEntity = OderApp.DataSource.Entities.Role;
using RoleModel = OderApp.Models.Role;

namespace OderApp.Helper
{
    public static class ConvertObject
    {
        public static Account ConvertToAccount(this AccountEntity accountEntity)
        {
            return new Account(accountEntity.Email, accountEntity.Password, accountEntity.Role);

        }
        
        public static Configuration ConvertToConfiguration(this ConfigurationEntity  configurationEntity)
        {
            return new Configuration(configurationEntity.Policy, configurationEntity.Rules, configurationEntity.Address);

        }

        public static MenuItem ConvertToMenuItem(this MenuItemEntity menuItemEntity)
        {
            return new MenuItem(menuItemEntity.Id, menuItemEntity.Name, menuItemEntity.Price, Enum.GetName(typeof(Category), menuItemEntity.Category).ToLower());
        }

        public static Item? ConvertToItem(this ItemEntity? itemEntity)
        {
            if (itemEntity != null)
            {
                return new Item(itemEntity.Id, itemEntity.Name, itemEntity.Quantity, itemEntity.Price, itemEntity.Catagory.ConvertToCatagory());
            }
            else return null;

        }

        public static User? ConvertToUser(this UserEntity? userEntity)
        {
            if (userEntity != null)
            {
                return new User(userEntity.Id, userEntity.Name, userEntity.Email, userEntity.Role.ConvertToRole());
            }
            else return null;
        }

        public static ItemEntity ConvertToItemEntity(this Item item)
        {
            return new ItemEntity(
                item.Id,
                item.Name,
                item.Quantity,
                item.Price,
                item.Catagory.ConvertToCatagoryEntity()
            );
        }

        public static UserEntity ConvertToUserEntity(this User user)
        {
            return new UserEntity (
                user.Id,
                user.Name,
                user.Email,
                user.Role.ConvertToRoleEntity()
            );
        }

        private static CatagoryModel ConvertToCatagory(this CatagoryEntity catagoryEntity)
        {
            switch(catagoryEntity)
            {
                case CatagoryEntity.Drink:
                    return CatagoryModel.Drink;
                default:
                    return CatagoryModel.Food;
            };
        }

        private static RoleModel ConvertToRole(this RoleEntity roleEntity)
        {
            switch (roleEntity)
            {
                case RoleEntity.Admin:
                    return RoleModel.Admin;
                default:
                    return RoleModel.Customer;
            };
        }

        private static CatagoryEntity ConvertToCatagoryEntity(this CatagoryModel catagoryModel)
        {
            switch (catagoryModel)
            {
                case CatagoryModel.Drink:
                    return CatagoryEntity.Drink;
                default:
                    return CatagoryEntity.Food;
            };
        }

        private static RoleEntity ConvertToRoleEntity(this RoleModel roleModel)
        {
            switch (roleModel)
            {
                case RoleModel.Admin:
                    return RoleEntity.Admin;
                default:
                    return RoleEntity.Customer;
            };
        }
    }
}
