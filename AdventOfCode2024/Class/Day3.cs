using System.ComponentModel.Design;

namespace AdventOfCode2024.Class
{
	public static class Day3
	{

		public static long GetPotentialMulValue(string mulString)
		{
			string firstNumber = "";
			string lastNumber = "";
			bool afterComma = false;

			if (mulString.Length < 8)
				return 0;

			if(!(mulString[0] == 'm' && mulString[1] == 'u' && mulString[2] == 'l' && mulString[3] == '('))
				return 0;
			
			for(int i = 4; i < mulString.Length; i++)
			{
				if("0123456789".Contains(mulString[i]))
				{
					if (afterComma)
						lastNumber = lastNumber + mulString[i];
					else
						firstNumber = firstNumber + mulString[i];
				}
				else if(mulString[i] == ',')
				{
					afterComma = true;
				}
				else if(mulString[i] == ')' && afterComma)
				{
					return int.Parse(firstNumber) * int.Parse(lastNumber);
				}
				else
				{
					return 0;
				}
			}
			return 0;
		}

		public static long GetPart1Result(string filename)
		{
			long total = 0;
			int lastMIndex = -1;
			int lastParenthesesIndex = -1;
			bool check = false;
			string text = Helper.GetFileContent(filename);

			for(int i = 0; i < text.Length; i++)
			{
				if(text[i] == 'm')
				{
					lastMIndex = i;
					lastParenthesesIndex = -1;
				}
				if(text[i] == ')')
				{
					lastParenthesesIndex = i;
					check = true;
				}
				if(lastMIndex != -1 && lastParenthesesIndex != -1 && check == true)
				{
					var temp = text[lastMIndex..(lastParenthesesIndex + 1)];
					total += GetPotentialMulValue(text[lastMIndex..(lastParenthesesIndex + 1)]);
					check = false;
					lastMIndex = -1;
					lastParenthesesIndex = -1;
				}
			}
			return total;
		}
		public static long GetPart2Result(string filename)
		{
			long total = 0;
			int lastMIndex = -1;
			int lastParenthesesIndex = -1;
			bool isMulEnabled = true;
			bool check = false;
			string text = Helper.GetFileContent(filename);

			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] == 'm')
				{
					lastMIndex = i;
					lastParenthesesIndex = -1;
				}
				if (text[i] == ')')
				{
					char t =  (char)(text[i - 3]);
					if(i - 3 > 0 && text[i - 3] == 'd' && text[i - 2] == 'o' && text[i - 1] == '(')
					{
						isMulEnabled = true;
					}
					else if(i - 6 > 0 && text[i - 6] == 'd' && text[i - 5] == 'o' && text[i - 4] == 'n' && text[i - 3] == '\'' && text[i - 2] == 't' && text[i - 1] == '(')
					{
						isMulEnabled = false;
					}
					else
					{
						lastParenthesesIndex = i;
						check = true;
					}
				}
				if (lastMIndex != -1 && lastParenthesesIndex != -1 && check == true && isMulEnabled == true)
				{
					total += GetPotentialMulValue(text[lastMIndex..(lastParenthesesIndex + 1)]);
					check = false;
					lastMIndex = -1;
					lastParenthesesIndex = -1;
				}
			}
			return total;
		}
	}
}
