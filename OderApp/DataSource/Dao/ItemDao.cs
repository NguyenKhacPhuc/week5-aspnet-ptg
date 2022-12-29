using OderApp.DataSource.Entities;

namespace OderApp.DataSource.Dao
{
    public interface ItemDao
    {
        public Task Insert(ItemEntity data);
        public Task<List<ItemEntity>> GetAll();
        public Task Update(ItemEntity data);
        public Task Delete(string id);
    }
}
