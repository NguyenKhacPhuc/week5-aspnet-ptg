
using OderApp.DataSource.Entities;
using OderApp.Helper;

namespace OderApp.DataSource.Dao
{
    public interface MenuDao
    {
        public Task Insert(MenuItemEntity data);
        public Task<List<MenuItemEntity>> GetAll();
        public Task Update(MenuItemEntity data);
        public Task Delete(string id);
        public Task<List<MenuItemEntity>> GetMenuByCategory(int category);

    }


    public class MenuDaoImpl : MenuDao
    {
        private readonly FileJsonHandler _fileJsonHandler;
        public MenuDaoImpl(FileJsonHandler fileJsonHandler)
        {
            _fileJsonHandler = fileJsonHandler;
        }
        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<MenuItemEntity> Get(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MenuItemEntity>> GetAll()
        {
            return await _fileJsonHandler.readFile<List<MenuItemEntity>>(Constant.MENU_STORE_PATH_FILE);
        }

        public Task Insert(MenuItemEntity data)
        {
            throw new NotImplementedException();
        }

        public Task Update(MenuItemEntity data)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MenuItemEntity>> GetMenuByCategory(int category)
        {
            var menu = await GetAll();
            return menu.FindAll(menuItem => menuItem.Category == category);
        }
    }
}
