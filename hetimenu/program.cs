using System;
using System.Collections.Generic;

class Program
{
	static void Main()
	{
		Dictionary<string, List<string>> weeklyMenu = new Dictionary<string, List<string>>()
		{
			{"Hétfő", new List<string>()},
			{"Kedd", new List<string>()},
			{"Szerda", new List<string>()},
			{"Csütörtök", new List<string>()},
			{"Péntek", new List<string>()},
			{"Szombat", new List<string>()},
			{"Vasárnap", new List<string>()}
		};

		bool running = true;

		while (running)
		{
			Console.WriteLine("Válassz egy lehetőséget:");
			Console.WriteLine("1. Étel hozzáadása a menühöz");
			Console.WriteLine("2. Étel módosítása a menüben");
			Console.WriteLine("3. Étel törlése a menüből");
			Console.WriteLine("4. Teljes menü megtekintése");
			Console.WriteLine("5. Kilépés");

			string choice = Console.ReadLine();

			switch (choice)
			{
				case "1":
					AddDish(weeklyMenu);
					break;
				case "2":
					ModifyDish(weeklyMenu);
					break;
				case "3":
					DeleteDish(weeklyMenu);
					break;
				case "4":
					DisplayMenu(weeklyMenu);
					break;
				case "5":
					running = false;
					break;
				default:
					Console.WriteLine("Érvénytelen választás. Próbáld újra.");
					break;
			}

			Console.WriteLine();
		}
	}

	static void AddDish(Dictionary<string, List<string>> menu)
	{
		string day = GetDayFromUser();
		if (day != null)
		{
			Console.WriteLine($"Írd be az ételt, amit hozzá szeretnél adni a(z) {day} napi menühöz:");
			string dish = Console.ReadLine();
			menu[day].Add(dish);
			Console.WriteLine("Az étel sikeresen hozzáadva a menühöz.");
		}
	}

	static void ModifyDish(Dictionary<string, List<string>> menu)
	{
		string day = GetDayFromUser();
		if (day != null)
		{
			if (menu[day].Count > 0)
			{
				Console.WriteLine($"Válaszd ki a módosítani kívánt ételt a(z) {day} napi menüből:");
				DisplayDayMenu(menu, day);
				int index = GetIndexFromUser(menu[day]);

				if (index >= 0)
				{
					Console.WriteLine("Írd be az új ételt:");
					string newDish = Console.ReadLine();
					menu[day][index] = newDish;
					Console.WriteLine("Az étel sikeresen módosítva.");
				}
			}
			else
			{
				Console.WriteLine("Nincs elérhető étel ezen a napon.");
			}
		}
	}

	static void DeleteDish(Dictionary<string, List<string>> menu)
	{
		string day = GetDayFromUser();
		if (day != null)
		{
			if (menu[day].Count > 0)
			{
				Console.WriteLine($"Válaszd ki a törölni kívánt ételt a(z) {day} napi menüből:");
				DisplayDayMenu(menu, day);
				int index = GetIndexFromUser(menu[day]);

				if (index >= 0)
				{
					menu[day].RemoveAt(index);
					Console.WriteLine("Az étel sikeresen törölve.");
				}
			}
			else
			{
				Console.WriteLine("Nincs elérhető étel ezen a napon.");
			}
		}
	}

	static void DisplayMenu(Dictionary<string, List<string>> menu)
	{
		Console.WriteLine("A heti menü:");
		foreach (var day in menu.Keys)
		{
			Console.WriteLine($"{day}:");
			if (menu[day].Count > 0)
			{
				foreach (var dish in menu[day])
				{
					Console.WriteLine($"  - {dish}");
				}
			}
			else
			{
				Console.WriteLine("  Nincs étel a menüben.");
			}
		}
	}

	static void DisplayDayMenu(Dictionary<string, List<string>> menu, string day)
	{
		for (int i = 0; i < menu[day].Count; i++)
		{
			Console.WriteLine($"{i + 1}. {menu[day][i]}");
		}
	}

	static string GetDayFromUser()
	{
		Console.WriteLine("Válaszd ki a napot (Hétfő, Kedd, Szerda, Csütörtök, Péntek, Szombat, Vasárnap):");
		string day = Console.ReadLine();
		if (IsValidDay(day))
		{
			return char.ToUpper(day[0]) + day.Substring(1).ToLower();
		}
		else
		{
			Console.WriteLine("Érvénytelen nap. Próbáld újra.");
			return null;
		}
	}

	static bool IsValidDay(string day)
	{
		string[] validDays = { "Hétfő", "Kedd", "Szerda", "Csütörtök", "Péntek", "Szombat", "Vasárnap" };
		return Array.Exists(validDays, d => d.Equals(day, StringComparison.OrdinalIgnoreCase));
	}

	static int GetIndexFromUser(List<string> dishes)
	{
		if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= dishes.Count)
		{
			return index - 1;
		}
		else
		{
			Console.WriteLine("Érvénytelen választás. Próbáld újra.");
			return -1;
		}
	}
}
