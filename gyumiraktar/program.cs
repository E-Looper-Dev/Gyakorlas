using System;
using System.Collections.Generic;

class Program
{
	static void Main()
	{
		Dictionary<string, int> fruitInventory = new Dictionary<string, int>();
		bool running = true;

		while (running)
		{
			Console.WriteLine("Gyümölcsraktár kezelő rendszer");
			Console.WriteLine("1. Gyümölcs hozzáadása");
			Console.WriteLine("2. Készlet csökkentése");
			Console.WriteLine("3. Teljes készlet megjelenítése");
			Console.WriteLine("4. Kilépés");
			Console.Write("Válassz egy lehetőséget: ");

			string choice = Console.ReadLine();

			switch (choice)
			{
				case "1":
					AddFruit(fruitInventory);
					break;

				case "2":
					RemoveFruit(fruitInventory);
					break;

				case "3":
					DisplayInventory(fruitInventory);
					break;

				case "4":
					running = false;
					break;

				default:
					Console.WriteLine("Érvénytelen választás. Próbáld újra.");
					break;
			}

			Console.WriteLine();
		}
	}

	static void AddFruit(Dictionary<string, int> inventory)
	{
		Console.Write("Add meg a gyümölcs nevét: ");
		string fruitName = Console.ReadLine().ToLower();

		Console.Write("Add meg a mennyiséget: ");
		if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
		{
			if (inventory.ContainsKey(fruitName))
			{
				inventory[fruitName] += quantity;
				Console.WriteLine($"{quantity} {fruitName} hozzáadva a készlethez. Jelenlegi mennyiség: {inventory[fruitName]}.");
			}
			else
			{
				inventory[fruitName] = quantity;
				Console.WriteLine($"{quantity} {fruitName} hozzáadva a készlethez.");
			}
		}
		else
		{
			Console.WriteLine("Érvénytelen mennyiség.");
		}
	}

	static void RemoveFruit(Dictionary<string, int> inventory)
	{
		Console.Write("Add meg a gyümölcs nevét: ");
		string fruitName = Console.ReadLine().ToLower();

		if (inventory.ContainsKey(fruitName))
		{
			Console.Write("Add meg a csökkenteni kívánt mennyiséget: ");
			if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
			{
				if (inventory[fruitName] >= quantity)
				{
					inventory[fruitName] -= quantity;
					Console.WriteLine($"{quantity} {fruitName} eltávolítva a készletből. Jelenlegi mennyiség: {inventory[fruitName]}.");
					if (inventory[fruitName] == 0)
					{
						inventory.Remove(fruitName);
						Console.WriteLine($"{fruitName} készlete elfogyott, eltávolítva a raktárból.");
					}
				}
				else
				{
					Console.WriteLine($"Nincs elegendő {fruitName} a készletben. Jelenlegi mennyiség: {inventory[fruitName]}.");
				}
			}
			else
			{
				Console.WriteLine("Érvénytelen mennyiség.");
			}
		}
		else
		{
			Console.WriteLine($"{fruitName} nem található a készletben.");
		}
	}

	static void DisplayInventory(Dictionary<string, int> inventory)
	{
		if (inventory.Count > 0)
		{
			Console.WriteLine("Jelenlegi készlet:");
			foreach (var item in inventory)
			{
				Console.WriteLine($"{item.Key}: {item.Value}");
			}
		}
		else
		{
			Console.WriteLine("A raktár üres.");
		}
	}
}
