using KR_1.Users;

namespace KR_1.Database.Service.Base;

public interface IUserService
{
    public bool UserRegistration(User user);
    public List<User> ReadAccounts();
    public User ReadAccountbyId(int searchId);
    public User ReadAccountbyLogin(string searchLogin);
    public User ReadAccountbyPassword(string searchPassword);
    public void UpdateUser(User user);
}