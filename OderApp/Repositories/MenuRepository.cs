using OderApp.DataSource.Dao;
using OderApp.DataSource.Entities;

namespace OderApp.Repositories
{
    public interface IMenuRepository
    {
        public Task<List<ItemEntity>> GetAll();
        public Task<List<ItemEntity>> GetMenuByCategory(int category);
    }

    public class MenuRepositoryImpl : IMenuRepository
    {
        private readonly MenuDao _menuDao;
        public MenuRepositoryImpl(MenuDao menuDao)
        {
            _menuDao = menuDao;
        }
        public async Task<List<ItemEntity>> GetAll()
        {
            return await _menuDao.GetAll();
        }

        public async Task<List<ItemEntity>> GetMenuByCategory(int category)
        {
            return await _menuDao.GetMenuByCategory(category);
        }
    }
}
