using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main()
	{
		List<string> words = new List<string>
		{
			"alma", "banán", "szőlő", "narancs", "barack", "görögdinnye", "sárgadinnye",
			"körte", "ananász", "eper", "málna", "kiwi",
			"mangó", "papaya", "szilva", "meggy", "apricot", "kókusz",
			"citrom", "lime", "gránátalma", "uborka", "répa",
		};

		Console.WriteLine("Egyszerű keresőmotor szimuláció");
		Console.WriteLine("Írd be a keresendő szót vagy kifejezést:");

		string searchQuery = Console.ReadLine().ToLower();

		List<string> results = words.Where(w => w.Contains(searchQuery)).ToList();

		if (results.Count > 0)
		{
			Console.WriteLine("\nTalálatok:");
			foreach (string word in results)
			{
				Console.WriteLine(word);
			}
		}
		else
		{
			Console.WriteLine("\nNincsenek találatok a megadott kifejezésre.");
		}
	}
}
