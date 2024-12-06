using AdventOfCode2024.Class;

namespace AdventOfCode2024
{
	public class Program
	{
		static void Main(string[] args)
		{
			string? input = string.Empty;

			do
			{
				Console.Clear();
				Console.WriteLine("0. Press escape to exit!");
				Console.WriteLine("11.	Day 1 Part 1");
				Console.WriteLine("12.	Day 1 Part 1");
				Console.WriteLine("21.	Day 2 Part 1");
				Console.WriteLine("22.	Day 2 Part 2");

				var watch = System.Diagnostics.Stopwatch.StartNew();
				
				if (input == "0")
				{
					System.Environment.Exit(0);
				}
				else if(input == "11")
				{
					Console.WriteLine("\nDay 1 Part 1 Result: " + Day1.GetPart1Result("Input\\day1.txt"));
				}
				else if(input == "12")
				{
					Console.WriteLine("\nDay 1 Part 1 Result: " + Day1.GetPart2Result("Input\\day1.txt"));
				}
				else if(input == "21")
				{
					Console.WriteLine("\nDay 2 Part 1 Result: " + Day2.GetPart1Result("Input\\day2.txt"));
				}
				else if(input == "22")
				{
					Console.WriteLine("\nDay 2 Part 1 Result: " + Day2.GetPart2Result("Input\\day2.txt"));
				}

				watch.Stop();
				var elapsedMs = watch.ElapsedMilliseconds;
				Console.WriteLine("Milliseconds: " + elapsedMs);

				Console.WriteLine("\nPress any key to continue");

			} while ((input = Console.ReadLine()) != null);
		}
	}
}