namespace Intro;

public class UserRole
{
    public int UserRoleId { get; set; }
    public string userNameRef { get; set; }
    public string roleNameRef { get; set; }
    
    public override string ToString()
    {
        return $"{userNameRef} with role => {roleNameRef}";
    }
}
