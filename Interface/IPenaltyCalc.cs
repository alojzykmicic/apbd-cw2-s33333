namespace apbd_cw2_s33333.Interface;

public interface IPenaltyCalc
{
    decimal CalculatePenalty(DateTime dueDate, DateTime actualReturnDate);
}