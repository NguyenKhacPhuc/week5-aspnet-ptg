
using OderApp.DataSource.Entities;
using OderApp.Helper;

namespace OderApp.DataSource.Dao
{
    public interface MenuDao
    {
        public Task Insert(ItemEntity data);
        public Task<List<ItemEntity>> GetAll();
        public Task Update(ItemEntity data);
        public Task Delete(string id);
        public Task<List<ItemEntity>> GetMenuByCategory(int category);

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

        public Task<ItemEntity> Get(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ItemEntity>> GetAll()
        {
            return await _fileJsonHandler.readFile<List<ItemEntity>>(Constant.MENU_STORE_PATH_FILE);
        }

        public Task Insert(ItemEntity data)
        {
            throw new NotImplementedException();
        }

        public Task Update(ItemEntity data)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ItemEntity>> GetMenuByCategory(int category)
        {
            var menu = await GetAll();
            return menu.FindAll(menuItem => menuItem.Category == category);
        }
    }
}
