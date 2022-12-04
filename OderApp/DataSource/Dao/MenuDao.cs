
using OderApp.DataSource.Entities;

namespace OderApp.DataSource.Dao
{
    public interface MenuDao
    {
        public Task Insert(MenuEntity data);
        public Task<List<MenuEntity>> GetAll();
        public Task Update(MenuEntity data);
        public Task Delete(string id);
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

        public Task<MenuEntity> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MenuEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Insert(MenuEntity data)
        {
            throw new NotImplementedException();
        }

        public Task Update(MenuEntity data)
        {
            throw new NotImplementedException();
        }
    }
}
