namespace Intro;

class User
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool IsEmailConfirmed { get; set; }

    public override string ToString()
    {
        return $"{UserName} {Password} {Email} {IsEmailConfirmed}";
    }
}