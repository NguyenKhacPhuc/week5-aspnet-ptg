using Microsoft.EntityFrameworkCore;
using OderApp.DataSource.Entities;

namespace OderApp.DataSource.Database;

public class DBItemDaoImpl : Dao.ItemDao
{
    private readonly OrderDbContext _dbContext;

    public DBItemDaoImpl(OrderDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ItemEntity?> Insert(ItemEntity data)
    {
        try
        {
            _dbContext.Item.Add(data);
            await _dbContext.SaveChangesAsync();
            return data;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<List<ItemEntity>> GetAll()
    {
        return await _dbContext.Item.ToListAsync();
    }

    public async Task<ItemEntity?> Update(ItemEntity data)
    {
        try
        {
            _dbContext.Item.Update(data);
            await _dbContext.SaveChangesAsync();
            return data;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<ItemEntity?> Delete(string id, bool isClearAll)
    {
        try
        {
            var item = await _dbContext.Item.FindAsync(id);
            if (!isClearAll)
            {
                var isExistedQuality = (item.Quantity - 1) > 1;
                if (isExistedQuality)
                {
                    item.Quantity -= 1;
                    return await Update(item);
                }
            }

            _dbContext.Item.Remove(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}