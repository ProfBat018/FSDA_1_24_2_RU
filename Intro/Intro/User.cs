namespace Intro;
using static BCrypt.Net.BCrypt;

class User
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool IsEmailConfirmed { get; set; } = false;

    public override string ToString()
    {
        return $"{UserName} {Password} {Email} {IsEmailConfirmed}";
    }

    public User()
    {
        
    }

    public User(string userName, string password, string email)
    {
        UserName = userName;
        Password = HashPassword(password);
        Email = email;
    }
}