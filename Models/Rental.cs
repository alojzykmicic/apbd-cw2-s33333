namespace apbd_cw2_s33333.Models;

public class Rental
{
    public Guid Id { get; } = Guid.NewGuid();
    public User User { get; }
    public Equipment Equipment { get; }
    public DateTime RentDate { get; }
    public DateTime DueDate { get; }
    public DateTime? ReturnDate { get; private set; }
    public decimal PenaltyFee { get; private set; } = 0;

    public bool isActive => ReturnDate == null;

    public Rental(User user, Equipment equipment, int daysToRent)
    {
        User = user;
        Equipment = equipment;
        RentDate = DateTime.Now;
        DueDate = DateTime.Now.AddDays(daysToRent);
    }

    public void MarkAsReturned(DateTime returnDate, decimal penalty)
    {
        ReturnDate = returnDate;
        PenaltyFee = penalty;
    }
}