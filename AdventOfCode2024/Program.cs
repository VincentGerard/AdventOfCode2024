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
				Console.WriteLine("31.	Day 3 Part 1");
				Console.WriteLine("32.	Day 3 Part 2");
				Console.WriteLine("41.	Day 4 Part 1");
				Console.WriteLine("42.	Day 4 Part 2");

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
					Console.WriteLine("\nDay 1 Part 2 Result: " + Day1.GetPart2Result("Input\\day1.txt"));
				}
				else if(input == "21")
				{
					Console.WriteLine("\nDay 2 Part 1 Result: " + Day2.GetPart1Result("Input\\day2.txt"));
				}
				else if(input == "22")
				{
					Console.WriteLine("\nDay 2 Part 2 Result: " + Day2.GetPart2Result("Input\\day2.txt"));
				}
				else if(input == "31")
				{
					Console.WriteLine("\nDay 3 Part 1 Result: " + Day3.GetPart1Result("Input\\day3.txt"));
				}
				else if(input == "32")
				{
					Console.WriteLine("\nDay 3 Part 2 Result: " + Day3.GetPart2Result("Input\\day3.txt"));
				}
				else if(input == "41")
				{
					Console.WriteLine("\nDay 4 Part 1 Result: " + Day4.GetPart1Result("Input\\day4.txt"));
				}
				else if(input == "42")
				{
					Console.WriteLine("\nDay 4 Part 2 Result: " + Day4.GetPart2Result("Input\\day4.txt"));
				}

				watch.Stop();
				var elapsedMs = watch.ElapsedMilliseconds;
				Console.WriteLine("Milliseconds: " + elapsedMs);

				Console.WriteLine("\nPress any key to continue");

			} while ((input = Console.ReadLine()) != null);
		}
	}
}