using System;
using System.Linq;

class Program
{
	static void Main()
	{
		const int daysInWeek = 7;
		int[] minTemperatures = new int[daysInWeek];
		int[] maxTemperatures = new int[daysInWeek];
		Random random = new Random();

		for (int i = 0; i < daysInWeek; i++)
		{
			minTemperatures[i] = random.Next(-10, 16);
			maxTemperatures[i] = random.Next(16, 36);
		}

		Console.WriteLine("Hőmérsékleti adatok a héten:");
		for (int i = 0; i < daysInWeek; i++)
		{
			Console.WriteLine($"Nap {i + 1}: Min = {minTemperatures[i]}°C, Max = {maxTemperatures[i]}°C");
		}

		double averageMinTemperature = minTemperatures.Average();
		double averageMaxTemperature = maxTemperatures.Average();
		Console.WriteLine($"\nÁtlagos minimum hőmérséklet a héten: {averageMinTemperature:F2}°C");
		Console.WriteLine($"Átlagos maximum hőmérséklet a héten: {averageMaxTemperature:F2}°C");

		int hottestDay = Array.IndexOf(maxTemperatures, maxTemperatures.Max()) + 1;
		int coldestDay = Array.IndexOf(minTemperatures, minTemperatures.Min()) + 1;
		Console.WriteLine($"\nA legmelegebb nap: {hottestDay}. nap (Max: {maxTemperatures[hottestDay - 1]}°C)");
		Console.WriteLine($"A leghidegebb nap: {coldestDay}. nap (Min: {minTemperatures[coldestDay - 1]}°C)");
	}
}