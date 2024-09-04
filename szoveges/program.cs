using System;
using System.IO;
 
class Program
{
    static void Main()
    {
        string filePath = "szoveg.txt";
        bool running = true;
 
        while (running)
        {
            Console.WriteLine("Válassz egy lehetőséget:");
            Console.WriteLine("1. Szöveg bevitele és mentése fájlba");
            Console.WriteLine("2. Fájl tartalmának betöltése és megjelenítése");
            Console.WriteLine("3. Kilépés");
 
            string choice = Console.ReadLine();
 
            switch (choice)
            {
                case "1":
                    WriteToFile(filePath);
                    break;
                case "2":
                    ReadFromFile(filePath);
                    break;
                case "3":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Érvénytelen választás. Próbáld újra.");
                    break;
            }
 
            Console.WriteLine();
        }
    }
 
    static void WriteToFile(string filePath)
    {
        Console.WriteLine("Írj be a szöveget, amit el szeretnél menteni:");
        string inputText = Console.ReadLine();
 
        try
        {
            File.WriteAllText(filePath, inputText);
            Console.WriteLine("A szöveg sikeresen elmentve a következő fájlba: " + filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hiba történt a fájl mentése közben: " + ex.Message);
        }
    }
 
    static void ReadFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                string fileContent = File.ReadAllText(filePath);
                Console.WriteLine("A fájl tartalma:");
                Console.WriteLine(fileContent);
            }
            else
            {
                Console.WriteLine("A fájl nem található.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hiba történt a fájl betöltése közben: " + ex.Message);
        }
    }
}
