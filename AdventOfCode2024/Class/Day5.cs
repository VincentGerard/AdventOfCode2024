namespace AdventOfCode2024.Class
{
	public static class Day5
	{
		public static int GetPart1Result(string filename)
		{
			string text = Helper.GetFileContent(filename);
			var rules = new List<(int rule1,int rule2)>() { };
			List<List<int>> updates = new List<List<int>>();
			bool afterMiddle = false;

			//Parse the rules + updates
			foreach(var line in text.Split("\r\n"))
			{
				if (line == string.Empty)
				{
					afterMiddle = true;
					continue;
				}
				if(afterMiddle == false)
				{
					var splitLine = line.Split('|');
					rules.Add((int.Parse(splitLine[0]), int.Parse(splitLine[1])));
				}
				else
				{
					List<int> newList = new List<int>();
					var splitLine = line.Split(",");
                    foreach (var item in splitLine)
                    {
						newList.Add(int.Parse(item));
                    }
					updates.Add(newList);
                }
			}

			//Calculate valid updates

			return 0;
		}

		public static int GetPart2Result(string filename)
		{
			return 0;
		}
	}
}
