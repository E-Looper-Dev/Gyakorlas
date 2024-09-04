using System;
 
class Program
{
    static void Main()
    {
        // A mozi terem helyeinek mátrixa (5 sor és 5 oszlop a példa kedvéért)
        char[,] seats = new char[5, 5];
 
        // Helyek inicializálása ('O' = szabad, 'X' = foglalt)
        InitializeSeats(seats);
 
        bool running = true;
 
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mozijegy-foglalási rendszer");
            DisplaySeats(seats);
 
            Console.WriteLine("\nVálassz egy lehetőséget:");
            Console.WriteLine("1. Jegy foglalása");
            Console.WriteLine("2. Foglalás visszamondása");
            Console.WriteLine("3. Kilépés");
 
            string choice = Console.ReadLine();
 
            switch (choice)
            {
                case "1":
                    BookSeat(seats);
                    break;
                case "2":
                    CancelBooking(seats);
                    break;
                case "3":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Érvénytelen választás. Próbáld újra.");
                    break;
            }
 
            Console.WriteLine("\nNyomj meg egy gombot a folytatáshoz...");
            Console.ReadKey();
        }
    }
 
    static void InitializeSeats(char[,] seats)
    {
        for (int i = 0; i < seats.GetLength(0); i++)
        {
            for (int j = 0; j < seats.GetLength(1); j++)
            {
                seats[i, j] = 'O'; // 'O' jelöli a szabad helyet
            }
        }
    }
 
    static void DisplaySeats(char[,] seats)
    {
        Console.WriteLine("Moziterem helyei:");
        for (int i = 0; i < seats.GetLength(0); i++)
        {
            for (int j = 0; j < seats.GetLength(1); j++)
            {
                Console.Write(seats[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
 
    static void BookSeat(char[,] seats)
    {
        Console.WriteLine("Add meg a foglalni kívánt hely sorának számát (1-től 5-ig):");
        if (int.TryParse(Console.ReadLine(), out int row) && row > 0 && row <= seats.GetLength(0))
        {
            Console.WriteLine("Add meg a foglalni kívánt hely oszlopának számát (1-től 5-ig):");
            if (int.TryParse(Console.ReadLine(), out int col) && col > 0 && col <= seats.GetLength(1))
            {
                if (seats[row - 1, col - 1] == 'O')
                {
                    seats[row - 1, col - 1] = 'X'; // 'X' jelöli a foglalt helyet
                    Console.WriteLine("Sikeres foglalás!");
                }
                else
                {
                    Console.WriteLine("Ez a hely már foglalt.");
                }
            }
            else
            {
                Console.WriteLine("Érvénytelen oszlopszám.");
            }
        }
        else
        {
            Console.WriteLine("Érvénytelen sorszám.");
        }
    }
 
    static void CancelBooking(char[,] seats)
    {
        Console.WriteLine("Add meg a visszamondani kívánt hely sorának számát (1-től 5-ig):");
        if (int.TryParse(Console.ReadLine(), out int row) && row > 0 && row <= seats.GetLength(0))
        {
            Console.WriteLine("Add meg a visszamondani kívánt hely oszlopának számát (1-től 5-ig):");
            if (int.TryParse(Console.ReadLine(), out int col) && col > 0 && col <= seats.GetLength(1))
            {
                if (seats[row - 1, col - 1] == 'X')
                {
                    seats[row - 1, col - 1] = 'O'; // A hely visszaállítása szabadra
                    Console.WriteLine("Sikeres visszamondás!");
                }
                else
                {
                    Console.WriteLine("Ez a hely már szabad.");
                }
            }
            else
            {
                Console.WriteLine("Érvénytelen oszlopszám.");
            }
        }
        else
        {
            Console.WriteLine("Érvénytelen sorszám.");
        }
    }
}
