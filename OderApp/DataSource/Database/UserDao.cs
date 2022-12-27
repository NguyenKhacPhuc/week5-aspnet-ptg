using OderApp.DataSource.Entities;

namespace OderApp.DataSource.Database;

public class DBUserDaoImpl: Dao.UserDao
{
    private readonly OrderDbContext _dbContext;

    public DBUserDaoImpl(OrderDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<UserEntity?> UpdateUser(UserEntity data)
    {
        try
        {
            _dbContext.User.Update(data);
            await _dbContext.SaveChangesAsync();
            return data;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}