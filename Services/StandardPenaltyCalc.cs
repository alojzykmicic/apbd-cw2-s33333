using apbd_cw2_s33333.Interface;

namespace apbd_cw2_s33333.Services;

public class StandardPenaltyCalc : IPenaltyCalc
{
    private const decimal DailyPenaltyRate = 10.0m;

    public decimal CalculatePenalty(DateTime dueDate, DateTime actualReturnDate)
    {
        if (actualReturnDate <= dueDate) return 0;

        var delay = (actualReturnDate - dueDate).Days;
        return delay * DailyPenaltyRate;
    }
}