using OderApp.DataSource.Dao;
using OderApp.DataSource.Entities;

namespace OderApp.Repositories
{
    public interface IMenuRepository
    {
        public Task<List<MenuItemEntity>> GetAll();
        public Task<List<MenuItemEntity>> GetMenuByCategory(int category);
    }

    public class MenuRepositoryImpl : IMenuRepository
    {
        private readonly MenuDao _menuDao;
        public MenuRepositoryImpl(MenuDao menuDao)
        {
            _menuDao = menuDao;
        }
        public async Task<List<MenuItemEntity>> GetAll()
        {
            return await _menuDao.GetAll();
        }

        public async Task<List<MenuItemEntity>> GetMenuByCategory(int category)
        {
            return await _menuDao.GetMenuByCategory(category);
        }
    }
}
