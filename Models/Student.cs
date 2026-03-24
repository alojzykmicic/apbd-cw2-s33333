namespace apbd_cw2_s33333.Models;

public class Student : User
{
    public override int MaxRentals => 2;

    public Student(string firstname, string lastname) : base(firstname, lastname) { }
}