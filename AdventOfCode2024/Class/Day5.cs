namespace AdventOfCode2024.Class
{
	public static class Day5
	{
		private static int GetMiddleValueIfValid(List<int> update, List<(int n1,int n2)> rules)
		{
			foreach(var rule in rules)
			{
				int index1 = update.IndexOf(rule.n1);
				int index2 = update.IndexOf(rule.n2);

				if(index1 != - 1 && index2 != -1 && index2 < index1) 
				{
					return 0;
				}
			}
			return update.ElementAt(update.Count / 2);
		}

		public static int OrderListByRules(List<int> update, List<(int n1, int n2)> rules)
		{
            while(true)
			{
                foreach (var rule in rules)
                {
                    int index1 = update.IndexOf(rule.n1);
                    int index2 = update.IndexOf(rule.n2);

                    if (index1 != -1 && index2 != -1 && index2 < index1)
                    {
                        int temp = update[index1];
                        update[index1] = update[index2];
                        update[index2] = temp;
                    }
                }
            }
			//TODO Finish ordering the list
			return 0;
		}

		public static int GetPart1Result(string filename)
		{
			int totalMiddleValue = 0;
			string text = Helper.GetFileContent(filename);
			var rules = new List<(int n1,int n2)>() { };
			List<List<int>> updates = new List<List<int>>();
			bool afterMiddle = false;

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

					splitLine.ToList().ForEach(x => newList.Add(int.Parse(x)));

					updates.Add(newList);
                }
			}

			updates.ForEach(x => totalMiddleValue += GetMiddleValueIfValid(x, rules));

			return totalMiddleValue;
		}

		public static int GetPart2Result(string filename)
		{
            int totalMiddleValue = 0;
            string text = Helper.GetFileContent(filename);
            var rules = new List<(int n1, int n2)>() { };
            List<List<int>> updates = new List<List<int>>();
            bool afterMiddle = false;
			List<List<int>> badUpdates = new List<List<int>>();

            foreach (var line in text.Split("\r\n"))
            {
                if (line == string.Empty)
                {
                    afterMiddle = true;
                    continue;
                }
                if (afterMiddle == false)
                {
                    var splitLine = line.Split('|');
                    rules.Add((int.Parse(splitLine[0]), int.Parse(splitLine[1])));
                }
                else
                {
                    List<int> newList = new List<int>();
                    var splitLine = line.Split(",");

                    splitLine.ToList().ForEach(x => newList.Add(int.Parse(x)));
                    updates.Add(newList);
                }
            }

			foreach(var update in updates)
			{
				long result = GetMiddleValueIfValid(update, rules);
				if(result > 0)
				{
					badUpdates.Add(update);
				}
			}

            //Order bad updates
			foreach(var update in badUpdates)
			{
                

            }
            

			//Get Middle from bad updates
			

            return totalMiddleValue;
        }
	}
}
