using apbd_cw2_s33333.Common;
using apbd_cw2_s33333.Interface;
using apbd_cw2_s33333.Models;

namespace apbd_cw2_s33333.Services;

public class RentalService
{
    private readonly List<Equipment> _equipments = new();
    private readonly List<User> _users = new();
    private readonly List<Rental> _rentals = new();
    private readonly IPenaltyCalc _penaltyCalc;

    public RentalService(IPenaltyCalc penaltyCalc)
    {
        _penaltyCalc = penaltyCalc;
    }
    
    public void AddUser(User user) =>  _users.Add(user);
    public void AddEquipment(Equipment equipment) =>  _equipments.Add(equipment);

    public Result RentEquipment(User user, Equipment equipment, int daysToRent)
    {
        if (equipment.Status != EquipmentStatus.Available)
            return Result.Failure($"Item '{equipment.Name}' jest niedostepny.");

        int activeRentalsCount = _rentals.Count(r => r.User.Id == user.Id && r.isActive);
        if (activeRentalsCount >= user.MaxRentals)
            return Result.Failure($"User '{user.Firstname}' osiagnal limit wypozyczen");

        equipment.Status = EquipmentStatus.Rented;
        var rental = new Rental(user, equipment, daysToRent);
        _rentals.Add(rental);
        
        return Result.Success();
    }

    public Result ReturnEquipment(Rental rental, DateTime returnDate)
    {
        if (!rental.isActive)
            return Result.Failure("Wypozyczenie zostalo juz zakonczone.");

        var penalty = _penaltyCalc.CalculatePenalty(rental.DueDate, returnDate);
        rental.MarkAsReturned(returnDate, penalty);
        rental.Equipment.Status = EquipmentStatus.Available;
        
        return Result.Success();
    }

    public Result MarkEquipmentAsUnavailable(Equipment equipment)
    {
        if (equipment.Status == EquipmentStatus.Rented)
            return Result.Failure("Status wypozyczonego itema nie moze byc zmieniony na niedostepny.");
        
        equipment.Status = EquipmentStatus.Unavailable;
        return Result.Success();
    }
}