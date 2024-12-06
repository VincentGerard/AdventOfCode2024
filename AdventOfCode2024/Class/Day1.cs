namespace AdventOfCode2024.Class
{
	public static class Day1
	{
		public static int GetPart1Result(string filename)
		{
			int result = 0;
			List<int> list1 = new List<int>();
			List<int> list2 = new List<int>();

			string text = Helper.GetFileContent(filename);

			foreach (var line in text.Split("\r\n"))
			{
				string[] array = line.Split("  ");
				list1.Add(int.Parse(array[0]));
				list2.Add(int.Parse(array[1]));
			}

			list1 = list1.Order().ToList();
			list2 = list2.Order().ToList();

			for(int i = 0; i < list1.Count; i++)
			{
				if(list1[i] > list2[i])
				{
					result += list1[i] - list2[i];
				}
				else
				{
					result += list2[i] - list1[i];
				}
			}
			return result;
		}

		public static long GetPart2Result(string filename)
		{
			long result = 0;
			List<int> list1 = new List<int>();
			List<int> list2 = new List<int>();
			string text = Helper.GetFileContent(filename);

			foreach (var line in text.Split("\r\n"))
			{
				string[] array = line.Split("  ");
				list1.Add(int.Parse(array[0]));
				list2.Add(int.Parse(array[1]));
			}

			list1 = list1.Order().Distinct().ToList();
			list2 = list2.Order().ToList();

			foreach (int item in list1)
			{
				result += item * list2.Count(x => x == item);
			}
			return result;
		}
	}
}
