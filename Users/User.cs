using System.ComponentModel;
using System.Transactions;

namespace KR_1.Users;

public class User
{
    public User(int id, string name, int balance, string login, string password)
    {
        UserId = id;
        UserName = name;
        Balance = balance;
        Login = login;
        Password = password;

    }
    public User(string name, string login, string password)
    {
        UserId = LastId + 1;
        UserName = name;
        Balance = 0;
        LastId = UserId;
        Login = login;
        Password = password;
    }
    public int UserId { get; set; }
    public static int LastId { get; set; } = 3;
    public string UserName { get; set; }
    public int Balance { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    static public User CurrentUser { get; set; }

    public string GetInfo()
    {
        return $"{UserId}, {UserName}, {Balance}";
    }
}
