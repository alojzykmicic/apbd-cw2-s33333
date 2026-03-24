namespace apbd_cw2_s33333.Models;

public abstract class User
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Firstname { get; }
    public string Lastname { get; }

    public abstract int MaxRentals { get; }
    
    protected User(string firstname, string lastname)
    {
        Firstname = firstname;
        Lastname = lastname;
    }
}