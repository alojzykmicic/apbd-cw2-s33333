namespace apbd_cw2_s33333.Models;

public class Employee : User
{
    public override int MaxRentals => 5;
    public Employee(string firstname, string lastname) : base(firstname, lastname) { }
}