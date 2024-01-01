using KR_1.Database.Entity;
using KR_1.Database.Repository.Base;

namespace KR_1.Database.Repository;

public class UserRepository : IUserRepository
{
    private readonly DbContext dbcontext;
    public UserRepository(DbContext dbcontext)
    {
        this.dbcontext = dbcontext;
    }
    public void Create(UserEntity user)
    {
        dbcontext.Users.Add(user);
    }

    public void Delete(int Id)
    {
        
        dbcontext.Users.Remove(ReadAccountbyId(Id));
    }

    public UserEntity ReadAccountbyId(int searchId)
    {
        foreach (UserEntity user in Read())
        {
            if (user.Id == searchId)
            {
                return user;
            }
        }
        return null;
    }

    public UserEntity ReadAccountbyLogin(string searchLogin)
    {
        foreach (UserEntity user in Read())
        {
            if (user.Login == searchLogin)
            {
                return user;
            }
        }
        return null;
    }

    public UserEntity ReadAccountbyPassword(string searchPassword)
    {
        foreach (UserEntity user in Read())
        {
            if (user.Login == searchPassword)
            {
                return user;
            }
        }
        return null;
    }

    public IEnumerable<UserEntity> Read()
    {
        return dbcontext.Users;
    }

    public void Update(UserEntity user)
    {
        dbcontext.Users.Remove(ReadAccountbyId(user.Id));
        dbcontext.Users.Add(user);
    }
}
