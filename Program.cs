using apbd_cw2_s33333.Common;
using apbd_cw2_s33333.Models;
using apbd_cw2_s33333.Services;

namespace RentalSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Konfiguracja zależności
            var penaltyCalc = new StandardPenaltyCalc();
            var system = new RentalService(penaltyCalc);

            Console.WriteLine("=== INICJALIZACJA SYSTEMU ===");
            // 11. Dodanie sprzętu
            var macbook = new Laptop("MacBook Pro", 16, "M2");
            var epson = new Projector("Epson 4K", 3000, "3840x2160");
            var sony = new Camera("Sony A7 III", 24, true);
            var brokenLaptop = new Laptop("Dell XPS", 8, "i5");
            
            system.AddEquipment(macbook);
            system.AddEquipment(epson);
            system.AddEquipment(sony);
            system.AddEquipment(brokenLaptop);
            system.MarkEquipmentAsUnavailable(brokenLaptop);

            // 12. Dodanie użytkowników
            var student = new Student("Jan", "Kowalski");
            var employee = new Employee("Anna", "Nowak");
            system.AddUser(student);
            system.AddUser(employee);

            Console.WriteLine("\n=== 13. POPRAWNE WYPOŻYCZENIE ===");
            var result1 = system.RentEquipment(student, macbook, 5);
            PrintResult(result1, "Wypożyczenie MacBooka przez Jana");

            // Zapychamy limit studenta (ma limit 2)
            system.RentEquipment(student, epson, 3);

            Console.WriteLine("\n=== 14. NIEPOPRAWNE OPERACJE ===");
            var resultLimit = system.RentEquipment(student, sony, 2);
            PrintResult(resultLimit, "Próba wypożyczenia 3. sprzętu przez studenta");

            var resultUnavailable = system.RentEquipment(employee, brokenLaptop, 5);
            PrintResult(resultUnavailable, "Próba wypożyczenia niedostępnego sprzętu");

            Console.WriteLine("\n=== 15 & 16. ZWROTY (Terminowy i Nieterminowy) ===");
            var activeRentals = system.GetActiveUserRentals(student).ToList();
            
            // Zwrot na czas (Macbook)
            var onTimeRental = activeRentals[0];
            system.ReturnEquipment(onTimeRental, DateTime.Now.AddDays(2));
            Console.WriteLine($"Zwrócono: {onTimeRental.Equipment.Name}, Kara: {onTimeRental.PenaltyFee} zł");

            // Zwrot po terminie (Epson) - 3 dni opóźnienia
            var lateRental = activeRentals[1];
            system.ReturnEquipment(lateRental, lateRental.DueDate.AddDays(3));
            Console.WriteLine($"Zwrócono: {lateRental.Equipment.Name}, Kara: {lateRental.PenaltyFee} zł (Opóźniony!)");

            Console.WriteLine("\n=== 17. RAPORT KOŃCOWY ===");
            Console.WriteLine($"Wszystkie sprzęty: {system.GetAllEquipment().Count()}");
            Console.WriteLine($"Sprzęty dostępne do wypożyczenia: {system.GetAvailableEquipment().Count()}");
            
            Console.WriteLine("\nNaciśnij dowolny klawisz, aby zakończyć...");
            Console.ReadKey();
        }

        static void PrintResult(Result result, string operationName)
        {
            if (result.IsSuccess)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[SUKCES] {operationName}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[BŁĄD] {operationName}: {result.ErrorMessage}");
            }
            Console.ResetColor();
        }
    }
}