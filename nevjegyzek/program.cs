using System;
using System.Collections.Generic;

class Program
{
	static void Main()
	{
		Dictionary<string, string> contacts = new Dictionary<string, string>();
		bool running = true;

		while (running)
		{
			Console.WriteLine("Válassz egy lehetőséget:");
			Console.WriteLine("1. Névjegy hozzáadása");
			Console.WriteLine("2. Névjegy törlése");
			Console.WriteLine("3. Névjegy módosítása");
			Console.WriteLine("4. Névjegyek megtekintése");
			Console.WriteLine("5. Kilépés");

			string choice = Console.ReadLine();

			switch (choice)
			{
				case "1":
					AddContact(contacts);
					break;
				case "2":
					DeleteContact(contacts);
					break;
				case "3":
					ModifyContact(contacts);
					break;
				case "4":
					DisplayContacts(contacts);
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

	static void AddContact(Dictionary<string, string> contacts)
	{
		Console.WriteLine("Írd be a nevet:");
		string name = Console.ReadLine();
		if (contacts.ContainsKey(name))
		{
			Console.WriteLine("Ez a névjegy már létezik.");
		}
		else
		{
			Console.WriteLine("Írd be a telefonszámot:");
			string phoneNumber = Console.ReadLine();
			contacts.Add(name, phoneNumber);
			Console.WriteLine("A névjegy sikeresen hozzáadva.");
		}
	}

	static void DeleteContact(Dictionary<string, string> contacts)
	{
		Console.WriteLine("Írd be a törölni kívánt névjegy nevét:");
		string name = Console.ReadLine();
		if (contacts.ContainsKey(name))
		{
			contacts.Remove(name);
			Console.WriteLine("A névjegy sikeresen törölve.");
		}
		else
		{
			Console.WriteLine("Ez a névjegy nem található.");
		}
	}

	static void ModifyContact(Dictionary<string, string> contacts)
	{
		Console.WriteLine("Írd be a módosítani kívánt névjegy nevét:");
		string name = Console.ReadLine();
		if (contacts.ContainsKey(name))
		{
			Console.WriteLine("Írd be az új telefonszámot:");
			string newPhoneNumber = Console.ReadLine();
			contacts[name] = newPhoneNumber;
			Console.WriteLine("A névjegy sikeresen módosítva.");
		}
		else
		{
			Console.WriteLine("Ez a névjegy nem található.");
		}
	}

	static void DisplayContacts(Dictionary<string, string> contacts)
	{
		if (contacts.Count > 0)
		{
			Console.WriteLine("Névjegyek:");
			foreach (var contact in contacts)
			{
				Console.WriteLine($"Név: {contact.Key}, Telefonszám: {contact.Value}");
			}
		}
		else
		{
			Console.WriteLine("A névjegyzék üres.");
		}
	}
}
