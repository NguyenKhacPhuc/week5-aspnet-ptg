using OderApp.DataSource.Entities;

namespace OderApp.DataSource.Dao
{
    public interface ItemDao
    {
        public Task<ItemEntity?> Insert(ItemEntity data);
        public Task<List<ItemEntity>> GetAll();
        public Task<ItemEntity?> Update(ItemEntity data);
        public Task<ItemEntity?> Delete(string id);
    }

    public class ItemDaoImpl : ItemDao
    {
        private const string STORE_PATH_FILE = @"D:\InputPackageManagerTestData1.json";

        private readonly FileJsonHandler _fileJsonHandler;

        public ItemDaoImpl(FileJsonHandler fileJsonHandler)
        {
            _fileJsonHandler = fileJsonHandler;
        }

        public async Task<ItemEntity?> Delete(string id)
        {
            var items = (await _fileJsonHandler.readFile<IEnumerable<ItemEntity>>(STORE_PATH_FILE)).ToList();
            if (items.Any(p => p.Id.Equals(id))) {
                var item = items.Find(p => p.Id.Equals(id));
                if (item != null) {
                    items.Remove(item);
                    await _fileJsonHandler.writeFile(STORE_PATH_FILE, items);
                    return item;
                }
            }
            return null;
        }


        public async Task<List<ItemEntity>> GetAll()
        {
            var items = await _fileJsonHandler.readFile<IEnumerable<ItemEntity>>(STORE_PATH_FILE);
            return items.ToList();
        }

        public async Task<ItemEntity?> Insert(ItemEntity data)
        {
            var items = (await _fileJsonHandler.readFile<IEnumerable<ItemEntity>>(STORE_PATH_FILE)).ToList();
            if (!items.Any(p => p.Id.Equals(data.Id)))
            {
                items.Add(data);
                await _fileJsonHandler.writeFile(STORE_PATH_FILE, items);
                return data;
            }
            return null;
        }

        public async Task<ItemEntity?> Update(ItemEntity data)
        {
            var items = (await _fileJsonHandler.readFile<IEnumerable<ItemEntity>>(STORE_PATH_FILE)).ToList();
            if (items.Any(p => p.Id.Equals(data.Id)))
            {
                items.RemoveAt(items.FindIndex(p => p.Id.Equals(data.Id)));
                items.Add(data);
                await _fileJsonHandler.writeFile(STORE_PATH_FILE, items);
                return data;
            }
            return null;
        }
    }
}
