namespace AdventOfCode2024.Class
{
	public static class Day2
	{
		public static int GetPart1Result(string filename)
		{
			int unsafeReport = 0;
			string text = Helper.GetFileContent(filename);

			foreach(string line in text.Split("\r\n"))
			{
				List<int> list = line.Split(" ").Select(int.Parse).ToList();
				if(!IsReportSafe(list))
				{
					unsafeReport++;
				}
			}
			return text.Split("\n").Count() - unsafeReport;
		}
		public static int GetPart2Result(string filename)
		{
			int unsafeReport = 0;
			string text = Helper.GetFileContent(filename);

			foreach (string line in text.Split("\r\n"))
			{
				int unsafeReportInList = 0;
				List<int> list = line.Split(" ").Select(int.Parse).ToList();
				if (!IsReportSafe(list))
				{
					for(int i = 0; i < list.Count; i++)
					{
						List<int> copyList = new List<int>(list);
						copyList.RemoveAt(i);
						if(!IsReportSafe(copyList))
						{
							unsafeReportInList++;
						}
					}
					if(unsafeReportInList == list.Count)
						unsafeReport++;
				}
			}
			return text.Split("\n").Count() - unsafeReport;
		}

		private static bool IsReportSafe(List<int> list)
		{
			bool increase = false;
			bool decrease = false;
			for (int i = 0; i < list.Count() - 1; i++)
			{
				if (i == 0 && list[0] > list[1])
					decrease = true;
				else if (i == 0 && list[1] > list[0])
					increase = true;
				else if (i == 0)
				{
					return false;
				}

				int difference = list[i] - list[i + 1];
				if (int.Abs(difference) < 1 || int.Abs(difference) > 3)
				{
					return false;
				}
				else if (increase && difference > 0)
				{
					return false;
				}
				else if (decrease && difference < 0)
				{
					return false;
				}
			}
			return true;
		}
	}
}
