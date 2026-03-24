Uruchomienie programu ma miejsce przez Program.cs który jest demonstracją działania. (\*ja odpalałem w Riderze)

\-Kod podzieliłem w taki a nie inny sposób bo nawyki z jezyka java i wydawalo się to logiczne: podzial na modele/obiekty i warstwę logiki oraz interface i szablon wyników pomiędzy wydawal się naturalny

\-kohezja: RentalService.cs odpowiada za transakcję a User.cs z podklasami przechowuje swoje limity

\-coupling: interface IPenaltyCalc.cs matematycznie liczy kare, dzięki czemu RentalService.cs może zostać nienaruszone w przypadku zmiany w sposobie naliczania kar.

\-odpowiedzialnosc klas: przede wszystkim oddzielenie danych od logiki



