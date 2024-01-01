using KR_1.Database.Entity;

namespace KR_1.Database.Repository.Base;

public interface IUserRepository
{
    public void Create(UserEntity user);
    public IEnumerable<UserEntity> Read();
    public void Update(UserEntity user);
    public void Delete(int Id);
    public UserEntity ReadAccountbyId(int searchId);
    public UserEntity ReadAccountbyLogin(string searchLogin);
    public UserEntity ReadAccountbyPassword(string searchPassword);
}
